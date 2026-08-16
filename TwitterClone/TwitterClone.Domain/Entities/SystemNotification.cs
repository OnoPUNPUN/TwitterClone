using System;

namespace TwitterClone.Domain.Entities
{
    public sealed class SystemNotification : Notification
    {
        public SystemNotification(string systemMessage) : base("System")
        {
            Message = systemMessage;
        }

        public void UpdateMessage(string message)
        {
            Message = message;
        }

        public override string GetMessage()
        {
            return Message ?? "System notification.";
        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, SystemMessage: {Message}";
        }
    }
}
