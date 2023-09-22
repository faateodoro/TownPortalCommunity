using Blog.Entities.Form;

namespace Blog.Entities
{
    public class Post
    {
        public uint Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Post(PostForm form)
        {
            Title = form.Title;
            Description = form.Description;
            CreatedAt = DateTime.Now;
        }

        private Post()
        {
            
        }

        public void Update(PostForm form)
        {
            Title = form.Title;
            Description = form.Description;
        }
    }
}
