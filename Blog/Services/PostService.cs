using Blog.Context;
using Blog.Entities;
using Blog.Entities.Form;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Blog.Services
{
    public class PostService
    {
        private readonly BlogContext _context;

        public PostService(BlogContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Post post)
        {
            await _context.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Post>> GetAllPostsAsync()
        {
            return await _context.Posts.ToListAsync<Post>();
        }

        public async Task<IList<Post>> GetActivePostsAsync()
        {
            return await _context.Posts.Where(p => p.Active == true).ToListAsync<Post>();
        }

        public async Task<Post> GetPostAsync(uint id)
        {
            return await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> DeleteAsync(uint id)
        {
            var post = await GetPostAsync(id);
            if (post == null)
            {
                return false;
            }
            post.Unactivate();
            _context.Update(post);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(uint id, PostForm form)
        {
            var post = await GetPostAsync(id);
            if (post == null)
            {
                return false;
            }
            post.Update(form);
            _context.Update(post);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
