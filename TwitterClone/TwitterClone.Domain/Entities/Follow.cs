namespace TwitterClone.Domain.Entities
{
    public class Follow
    {
        public Guid Id { get; private set; }
        public Guid FollowerId { get; private set; }
        public Guid FolloweeId { get; private set; }
        public DateTime FollowedAt { get; private set; }

        public Follow(Guid followerId, Guid followeeId)
        {
            if (followerId == followeeId)
                throw new ArgumentException("A user cannot follow themselves.");

            Id = Guid.NewGuid();
            FollowerId = followerId;
            FolloweeId = followeeId;
            FollowedAt = DateTime.UtcNow;
        }
    }
}
