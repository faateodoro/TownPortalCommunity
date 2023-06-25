using Blog.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Context
{
    public class BlogContext : DbContext
    {
        DbSet<Post> Posts { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            
        }
    }
}
