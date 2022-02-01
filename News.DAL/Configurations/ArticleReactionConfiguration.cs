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
    public class ArticleReactionConfiguration : IEntityTypeConfiguration<ArticleReaction>
    {
        

        public void Configure(EntityTypeBuilder<ArticleReaction> builder)
        {
            builder.HasOne(p => p.Reaction)
                .WithMany(p => p.ArticleReactions)
                .HasForeignKey(p => p.ReactionId);

            builder.HasOne(p => p.Article)
                .WithMany(p => p.ArticleReactions)
                .HasForeignKey(p => p.ArticleId);
        }
    }
}
