using Microsoft.EntityFrameworkCore;
using News.DAL.Entities;
using News.DAL.Interfaces;
using News.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Repositories
{
    public class ArticleRepository : IArticleRepository
    {

        private readonly AppDbContext _context;

        public ArticleRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Article article)
        {
            await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
        }

        public async Task AddReaction(ArticleReaction reaction)
        {
            await _context.ArticleReactions.AddAsync(reaction);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Article article)
        {
            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Article>> GetAll()
        {
            var articles = await _context.Articles.Include(x => x.Category).Include(x => x.User).ToListAsync();

            return articles;
        }

        public async Task<List<Article>> GetAllByCategory(int catId)
        {
            var articles = await _context.Articles.Include(x => x.Category).Include(x => x.User).Where(x => x.CategoryId == catId).ToListAsync();

            return articles;
        }

        public async Task<IQueryable<Article>> GetAllQuery()
        {
            var query = _context.Articles.AsQueryable();
            return query;
        }

        public async Task<Article> GetById(int id)
        {
            var article = await _context.Articles.Include(x => x.Category).Include(x => x.User).Include(x => x.ArticleComment).FirstOrDefaultAsync();

            return article;
        }

        public async Task Update(Article article)
        {
            _context.Articles.Update(article);
            await _context.SaveChangesAsync();
        }

    }
}
