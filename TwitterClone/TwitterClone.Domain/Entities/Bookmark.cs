namespace TwitterClone.Domain.Entities
{
    public class Bookmark
    {
        public Guid UserId { get; private set; }
        public Guid TweetId { get; private set; }
        public DateTime BookmarkedAt { get; private set; }

        public Bookmark(Guid userId, Guid tweetId)
        {
            UserId = userId;
            TweetId = tweetId;
            BookmarkedAt = DateTime.UtcNow;
        }
    }
}
