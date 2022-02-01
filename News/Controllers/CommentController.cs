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
    public class CommentController : ControllerBase
    {

        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetComments()
        {
            var articles = await _commentRepository.GetAll();

            return Ok(articles);
        }



        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetComment([FromRoute] int id)
        {
            var article = await _commentRepository.GetById(id);
            return Ok(article);
        }

        [HttpPost("Add")]
        //LoggedIn - si pt Admin si pt User
        [Authorize("LoggedIn")]
        public async Task<IActionResult> AddComment(ArticleComment comment)
        {
            await _commentRepository.Create(comment);
            return Ok();
        }

        [HttpDelete("Delete")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteComment(ArticleComment comment)
        {
            await _commentRepository.Delete(comment);
            return Ok();
        }

        [HttpPut("Update")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateComment(ArticleComment comment)
        {
            await _commentRepository.Update(comment);
            return Ok();
        }
    }
}
