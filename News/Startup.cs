using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using News.BLL.Helpers;
using News.BLL.Interfaces;
using News.BLL.Managers;
using News.DAL;
using News.DAL.Entities;
using News.DAL.Interfaces;
using News.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News
{
    public class Startup
    {
        public string SpecificOrigins = "_allowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: SpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("localhost:4200", "http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                    });
            });

            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ConnString")));

            services.AddTransient<IAuthManager, AuthManager>();
            services.AddTransient<ITokenHelper, TokenHelper>();
            services.AddTransient<InitialSeed>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IReactionRepository, ReactionRepository>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "News", Version = "v1" });
            });
        

            // identity
            services.AddIdentity<User, Role>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();

            services
                .AddAuthentication(options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                    .AddJwtBearer("AuthScheme", options =>
                    {
            options.RequireHttpsMetadata = true;
            options.SaveToken = true;
            var secret = Configuration.GetSection("Jwt").GetSection("Token").Get<String>();
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                RequireExpirationTime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    {
                        context.Response.Headers.Add("Token-Expired", "true");
                    }
                    return Task.CompletedTask;
                }
            };
        });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("Admin", policy => policy.RequireRole("Admin").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());

                opt.AddPolicy("User", policy => policy.RequireRole("User").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());

                opt.AddPolicy("LoggedIn", policy => policy.RequireRole("Admin", "User").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, InitialSeed initialSeed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "News v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(SpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            initialSeed.CreateRoles();


        }
    }
}
