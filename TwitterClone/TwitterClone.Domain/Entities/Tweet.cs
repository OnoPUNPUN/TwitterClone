namespace TwitterClone.Domain.Entities
{
    public class Tweet : BaseEntity
    {
        public Guid AuthorId { get; private set; }
        public string Content { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public Tweet(Guid authorId, string content) : base()
        {
            AuthorId = authorId;
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
