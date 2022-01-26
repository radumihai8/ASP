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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAll()
        {
            var categories = await(await(GetAllQuery())).ToListAsync();
            return categories;
        }

        public async Task<IQueryable<Category>> GetAllQuery()
        {
            var query = _context.Categories.AsQueryable();
            return query;
        }

        public async Task<Category> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            return category;
        }

        public async Task Update(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
