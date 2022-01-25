using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News.DAL;
using News.DAL.Entities;
using News.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetCategories()
        {
            var articles = await _categoryRepository.GetAll();

            return Ok(articles);
        }


        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            var article = await _categoryRepository.GetById(id);
            return Ok(article);
        }

        [HttpPost("Add")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            await _categoryRepository.Create(category);
            return Ok();
        }

        [HttpPost("Delete")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteCategory(Category category)
        {
            await _categoryRepository.Delete(category);
            return Ok();
        }

        [HttpPost("Update")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            await _categoryRepository.Update(category);
            return Ok();
        }
    }
}
