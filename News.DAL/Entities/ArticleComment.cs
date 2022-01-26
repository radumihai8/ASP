using News.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Entities
{
    public class ArticleComment
    {
        public int Id { get; set; }
        
        public string Content { get; set; }

        public int? ArticleId { get; set; }

        public int? UserId { get; set; }

        public virtual Article Article { get; set; }

        public DateTime Date { get; set; }
        public User User { get;  set; }
    }
}
