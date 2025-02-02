﻿using BlogLab.Models.BlogComment;
using BlogLab.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace BlogLabWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCommentController : ControllerBase
    {
        private readonly IBlogCommentRepository _blogCommentRepository;

        public BlogCommentController(IBlogCommentRepository blogCommentRepository)
        {
            this._blogCommentRepository = blogCommentRepository;
        }


       public async Task<ActionResult<BlogComment>> Create(BlogCommentCreate blogCommentCreate)
        {
            int applicationUserId = int.Parse(User.Claims.First(i => i.Type == JwtRegisteredClaimNames.NameId).Value);

            var createdBlogComment = await _blogCommentRepository.UpsertAsync(blogCommentCreate, applicationUserId);

            return Ok(createdBlogComment);
        }

       [HttpGet("{blogId}")]
       public async Task<ActionResult<List<BlogComment>>> GetAll(int blogId)
       {
            var blogComments = await _blogCommentRepository.GetAllAsync(blogId);
            return  blogComments;
       } 

        [Authorize]
        [HttpDelete("{blogCommentId}")]
        public async Task<ActionResult<int>> Delete(int blogCommentId)
        {
            int applicationUseId = int.Parse(User.Claims.First(i => i.Type == JwtRegisteredClaimNames.NameId).Value);

            var foundBlogComment = await _blogCommentRepository.GetAsync(blogCommentId);

            if (foundBlogComment == null) return BadRequest("Comment does not exists");

            if (foundBlogComment.ApplicationUserId == applicationUseId)
            {
                var affectedRows = await _blogCommentRepository.DeleteAsync(blogCommentId);
                return Ok(affectedRows);
            }

            else
            {
                return BadRequest("This comment was not created by the current user.");
            }
        }
    }
}
