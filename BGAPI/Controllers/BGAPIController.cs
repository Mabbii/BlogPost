using BGAPI.Data;
using BGAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Identity.Client;
using BGAPI.DTOS;

namespace BGAPI.Controllers
{
    [Route("api/blogposts")]
    [ApiController]
    public class BGAPIController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public BGAPIController(ApplicationDBContext context)
        {
            _context = context;
        }
        // GET: api/posts
        [HttpGet]

        public async Task<IActionResult> GetAllPosts()
        {
            try
            {
                var posts = await _context.BlogPosts.Select(post => new BlogPostDTO
                {
                    Title = post.Title,
                    Author = post.Author,
                    Quote = post.Quote.Length > 100 ? post.Quote.Substring(0, 100) + "...." : post.Quote
                }).ToListAsync();

                if (posts == null || !posts.Any())
                {
                    return NotFound();
                }
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internel Server error: " + ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            try
            {
                var post = await _context.BlogPosts.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (post == null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internel Server error: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] BlogPosts newposts)
        {
            try
            {
                if (newposts == null)
                {
                    return BadRequest("post data is required");
                }
                _context.BlogPosts.Add(newposts);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetPostById), new { id = newposts.Quote }, newposts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internel server error " + ex.Message);
            }
        }
    }
}
