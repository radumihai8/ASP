using News.DAL.Entities;
using News.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Interfaces
{
    public interface IReactionRepository
    {
        Task<List<Reaction>> GetAll();
        Task<List<ArticleReaction>> GetAllByArticle(int id);
        Task<Reaction> GetById(int id);
        Task Create(Reaction reaction);
        Task AssignToArticle(Reaction reaction, Article article);
        Task Update(Reaction reaction);
        Task Delete(Reaction reaction);
        Task<IQueryable<Reaction>> GetAllQuery();
    }
}
