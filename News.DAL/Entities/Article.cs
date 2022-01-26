using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
        public virtual ICollection<ArticleComment> ArticleComment { get; set; }
        

    }
}
