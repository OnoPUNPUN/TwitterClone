namespace TwitterClone.Domain.Entities
{
    public class Tweet
    {
        public Guid Id { get; private set; }
        public Guid AuthorId { get; private set; }
        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public Tweet(Guid authorId, string content)
        {
            Id = Guid.NewGuid();
            AuthorId = authorId;
            CreatedAt = DateTime.UtcNow;
            SetContent(content);
        }

        public void Edit(string newContent)
        {
            SetContent(newContent);
            UpdatedAt = DateTime.UtcNow;
        }

        private void SetContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Tweet content cannot be empty.");

            if (content.Length > 280)
                throw new ArgumentException("Tweet cannot exceed 280 characters.");

            Content = content;
        }
    }
}
