using Microsoft.EntityFrameworkCore;
using News.DAL.Entities;
using News.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Repositories
{
    public class ReactionRepository : IReactionRepository
    {
        private readonly AppDbContext _context;

        public ReactionRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task AssignToArticle(Reaction reaction, Article article)
        {
            throw new NotImplementedException();
        }

        public async Task Create(Reaction reaction)
        {
            await _context.Reactions.AddAsync(reaction);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Reaction reaction)
        {
            _context.Reactions.Remove(reaction);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Reaction>> GetAll()
        {
            var reactions = await _context.Reactions.ToListAsync();

            return reactions;
        }

        public async Task<List<ArticleReaction>> GetAllByArticle(int id)
        {
            var reactions = await _context.ArticleReactions.Where(x => x.ArticleId == id).ToListAsync();

            return reactions;
        }

        public async Task<IQueryable<Reaction>> GetAllQuery()
        {
            var query = _context.Reactions.AsQueryable();
            return query;
        }

        public async Task<Reaction> GetById(int id)
        {
            var article = await _context.Reactions.FirstOrDefaultAsync();

            return article;
        }

        public async Task Update(Reaction reaction)
        {
            _context.Reactions.Update(reaction);
            await _context.SaveChangesAsync();
        }
    }
}
