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
    public class ArticleCommentConfiguration : IEntityTypeConfiguration<ArticleComment>
    {
        public void Configure(EntityTypeBuilder<ArticleComment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Content)
                .HasColumnType("nvarchar(300)")
                .HasMaxLength(300);

            builder.Property(x => x.UserId)
                .HasColumnType("decimal(5)");

            builder.Property(x => x.Date)
                .HasColumnType("datetime");

        }
    }
}
