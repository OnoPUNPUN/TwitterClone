namespace TwitterClone.Domain.Entities
{
    public enum NotificationType
    {
        Like,
        Retweet,
        Follow,
        Mention
    }

    public class Notification
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid TriggeredById { get; private set; }
        public NotificationType Type { get; private set; }
        public Guid? TargetId { get; private set; }
        public bool IsRead { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime ModifiedAt { get; private set; }

        public Notification(Guid userId, Guid triggeredById, NotificationType type, Guid? targetId = null)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            TriggeredById = triggeredById;
            Type = type;
            TargetId = targetId;
            IsRead = false;
            CreatedAt = DateTime.UtcNow;
        }

        public void MarkAsRead()
        {
            IsRead = true;
        }
    }
}
