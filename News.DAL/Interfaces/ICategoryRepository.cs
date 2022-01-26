using News.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<Category> GetById(int id);
        Task Create(Category category);
        Task Update(Category category);
        Task Delete(Category category);
        Task<IQueryable<Category>> GetAllQuery();
    }
}
