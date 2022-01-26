using News.DAL.Entities;
using News.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Interfaces
{
    public interface IArticleRepository
    {
        Task<List<Article>> GetAll();
        Task<List<Article>> GetAllByCategory(int id);
        Task<Article> GetById(int id);
        Task Create(Article article);
        Task Update(Article article);
        Task Delete(Article article);
        Task<IQueryable<Article>> GetAllQuery();
    }
}
