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
    public class CommentRepository : ICommentRepository
    {

        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(ArticleComment comment)
        {
            await _context.ArticleComments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ArticleComment comment)
        {
            _context.ArticleComments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ArticleComment>> GetAll()
        {
            var comments = await (await (GetAllQuery())).Include(x => x.User).ToListAsync();
            return comments;
        }

        public async Task<IQueryable<ArticleComment>> GetAllQuery()
        {
            var query = _context.ArticleComments.AsQueryable();
            return query;
        }

        public async Task<ArticleComment> GetById(int id)
        {
            var article = await _context.ArticleComments.FirstOrDefaultAsync();

            return article;
        }

        public async Task Update(ArticleComment comment)
        {
            _context.ArticleComments.Update(comment);
            await _context.SaveChangesAsync();
        }

    }
}
