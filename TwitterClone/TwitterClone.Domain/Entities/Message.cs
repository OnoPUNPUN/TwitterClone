namespace TwitterClone.Domain.Entities
{
    public class Message : BaseEntity
    {
        public Guid SenderId { get; private set; }
        public Guid ReceiverId { get; private set; }
        public string Content { get; private set; }
        public bool IsRead { get; private set; }
        public DateTime SentAt { get; private set; }

        public Message(Guid senderId, Guid receiverId, string content) : base()
        {
            if (senderId == receiverId)
                throw new ArgumentException("Cannot send a message to yourself.");

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Message content cannot be empty.");

            if (content.Length > 1000)
                throw new ArgumentException("Message cannot exceed 1000 characters.");

            SenderId = senderId;
            ReceiverId = receiverId;
            Content = content;
            IsRead = false;
            SentAt = DateTime.UtcNow;
        }

        public void MarkAsRead()
        {
            IsRead = true;
        }
    }
}
