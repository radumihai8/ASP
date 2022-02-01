using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Entities
{
    public class ArticleReaction
    {
        public int Id { get; set; }
        public int ReactionId { get; set; } 
        public int ArticleId { get; set; }
        public virtual Reaction Reaction { get; set; }
        public virtual Article Article { get; set; }
    }
}
