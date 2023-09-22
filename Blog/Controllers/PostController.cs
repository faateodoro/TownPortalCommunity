using Blog.Entities;
using Blog.Entities.Form;
using Blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostForm form)
        {
            var post = new Post(form);
            await _postService.CreateAsync(post);
            return Ok(post);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetPostsAsync();
            if (posts == null)
            {
                return NotFound();
            }
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(uint id)
        {
            var post = await _postService.GetPostAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(uint id)
        {
            var hasPost = await _postService.DeleteAsync(id);
            if (!hasPost)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(uint id, PostForm form)
        {
            var hasPost = await _postService.UpdateAsync(id, form);
            if (!hasPost)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
