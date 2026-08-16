using System;

namespace TwitterClone.Domain.Entities
{
    public sealed class FriendRequestNotification : Notification
    {
        public FriendRequestNotification(Guid requesterId) : base("FriendRequest")
        {
            RequesterId = requesterId;
        }

        public Guid RequesterId { get; set; }

        public void AddMessage(string message)
        {
            Message = message;
        }

        public override string GetMessage()
        {
            if (!string.IsNullOrEmpty(Message))
                return Message;

            return $"User {RequesterId} sent a friend request.";
        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, RequesterId: {RequesterId}";
        }
    }
}
