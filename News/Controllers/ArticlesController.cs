using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.DAL;
using News.DAL.Interfaces;
using News.BLL.Interfaces;
using News.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {

        private readonly IArticleRepository _articleRepository;

        public ArticlesController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetArticles()
        {
            var articles = await _articleRepository.GetAll();

            return Ok(articles);
        }

        [HttpGet("GetByCategory/{id}")]
        public async Task<IActionResult> GetArticlesByCategory([FromRoute] int id)
        {
            var articles = await _articleRepository.GetAllByCategory(id);

            return Ok(articles);
        }


        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetArticle([FromRoute] int id)
        {
            var article = await _articleRepository.GetById(id);
            return Ok(article);
        }

        [HttpPost("Add")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddArticle(Article article)
        {
            await _articleRepository.Create(article);
            return Ok();
        }

        [HttpPost("AddReaction")]
        public async Task<IActionResult> AddReaction(ArticleReaction reaction)
        {
            await _articleRepository.AddReaction(reaction);
            return Ok();
        }

        [HttpPost("Delete")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteArticle(Article article)
        {
            await _articleRepository.Delete(article);
            return Ok();
        }

        [HttpPost("Update")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateArticle(Article article)
        {
            await _articleRepository.Update(article);
            return Ok();
        }
    }
}
