using System;

namespace TwitterClone.Domain.Entities
{
    public sealed class CommentNotification : Notification
    {
        public CommentNotification(Guid commentByUserId, Guid commentId) : base("Comment")
        {
            CommentByUserId = commentByUserId;
            CommentId = commentId;
        }

        public Guid CommentByUserId { get; set; }
        public Guid CommentId { get; set; }

        public void AddMessage(string message)
        {
            Message = message;
        }

        public override string GetMessage()
        {
            if (!string.IsNullOrEmpty(Message))
                return Message;

            return $"User {CommentByUserId} commented (id: {CommentId}).";
        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, CommentByUserId: {CommentByUserId}, CommentId: {CommentId}";
        }
    }
}
