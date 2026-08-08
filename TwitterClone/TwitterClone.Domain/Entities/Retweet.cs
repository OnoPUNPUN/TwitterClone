namespace TwitterClone.Domain.Entities
{
    public class Retweet
    {
        public Guid UserId { get; private set; }
        public Guid TweetId { get; private set; }
        public DateTime RetweetedAt { get; private set; }

        public Retweet(Guid userId, Guid tweetId)
        {
            UserId = userId;
            TweetId = tweetId;
            RetweetedAt = DateTime.UtcNow;
        }
    }
}
