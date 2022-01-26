using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using News.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.Id);


            //builder.HasMany(p => p.ArticleComment)
            //    .WithOne(b => b.Article)
            //    .HasForeignKey(p => p.ArticleId);

            //builder.HasOne(p => p.User)
            //    .WithMany(b => b.Articles)
            //    .HasForeignKey(p => p.UserId);

            builder.Property(x => x.Title)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(x => x.Content)
                .HasColumnType("nvarchar(3000)")
                .HasMaxLength(3000);

            builder.Property(x => x.Date)
                .HasColumnType("datetime");
        }
    }
}
