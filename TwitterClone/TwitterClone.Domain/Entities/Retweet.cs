namespace TwitterClone.Domain.Entities
{
    public class Retweet : BaseEntity
    {
        public Guid UserId { get; private set; }
        public Guid TweetId { get; private set; }
        public string Commnet { get; private set; }
        public DateTime RetweetedAt { get; private set; }

        public Retweet(Guid userId, Guid tweetId, string comment) : base()
        {
            UserId = userId;
            TweetId = tweetId;
            Commnet = comment;
            RetweetedAt = DateTime.UtcNow;
        }
    }
}
