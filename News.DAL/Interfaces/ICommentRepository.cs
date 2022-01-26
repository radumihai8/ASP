using News.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<ArticleComment>> GetAll();
        Task<ArticleComment> GetById(int id);
        Task Create(ArticleComment comment);
        Task Update(ArticleComment comment);
        Task Delete(ArticleComment comment);
        Task<IQueryable<ArticleComment>> GetAllQuery();
    }
}
