using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Content { get; set; }
        public DateTime date { get; set; }
        public UserModel User { get; set; }
    }
}
