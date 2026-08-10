namespace TwitterClone.Domain.Entities
{
    public class Follow : BaseEntity
    {
        public Guid FollowerId { get; private set; }
        public Guid FolloweeId { get; private set; }
        public DateTime FollowedAt { get; private set; }

        public Follow(Guid followerId, Guid followeeId) : base()
        {
            if (followerId == followeeId)
                throw new ArgumentException("A user cannot follow themselves.");

            FollowerId = followerId;
            FolloweeId = followeeId;
            FollowedAt = DateTime.UtcNow;
        }
    }
}
