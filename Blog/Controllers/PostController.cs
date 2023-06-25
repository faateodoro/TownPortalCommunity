using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult index()
        {
            return Ok("O Controller funcionou corretamente");
        }
    }
}
