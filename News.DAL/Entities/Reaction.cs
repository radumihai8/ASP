using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Entities
{
    public class Reaction
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ArticleReaction> ArticleReactions { get; set; }
    }
}
