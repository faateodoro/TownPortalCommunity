namespace Blog.Entities
{
    public class Post
    {
        public uint Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }

    }
}
