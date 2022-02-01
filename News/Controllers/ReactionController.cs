using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ReactionController : ControllerBase
    {
        private readonly IReactionRepository _reactionRepository;

        public ReactionController(IReactionRepository reactionRepository)
        {
            _reactionRepository = reactionRepository;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetArticles()
        {
            var articles = await _reactionRepository.GetAll();

            return Ok(articles);
        }

        [HttpGet("GetByArticle/{id}")]
        public async Task<IActionResult> GetAllByArticle([FromRoute] int id)
        {
            var articles = await _reactionRepository.GetAllByArticle(id);

            return Ok(articles);
        }


        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetReaction([FromRoute] int id)
        {
            var article = await _reactionRepository.GetById(id);
            return Ok(article);
        }

        [HttpPost("Add")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddReaction(Reaction reaction)
        {
            await _reactionRepository.Create(reaction);
            return Ok();
        }

        [HttpPost("Delete")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteReaction(Reaction reaction)
        {
            await _reactionRepository.Delete(reaction);
            return Ok();
        }

        [HttpPost("Update")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateReaction(Reaction reaction)
        {
            await _reactionRepository.Update(reaction);
            return Ok();
        }
    }
}
