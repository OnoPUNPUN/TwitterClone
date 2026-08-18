namespace TwitterClone.Domain.Entities
{
    public class Tweet : BaseEntity, ILikable, INotifiable
    {
        public Guid AuthorId { get; private set; }
        public string Content { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        private readonly HashSet<Guid> _likes = new HashSet<Guid>();
        private readonly List<Guid> _notifications = new List<Guid>();

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

        public bool CanBeLiked()
        {
            return !string.IsNullOrWhiteSpace(Content);
        }

        public void AddNotification(Guid notificationId)
        {
            _notifications.Add(notificationId);
        }

        public IReadOnlyCollection<Guid> Likes => _likes;
        public IReadOnlyCollection<Guid> Notifications => _notifications;
    }
}
