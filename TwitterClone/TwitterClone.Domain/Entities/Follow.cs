namespace TwitterClone.Domain.Entities
{
    public class Follow
    {
        public Guid FollowerId { get; private set; } // The user who is following
        public Guid FolloweeId { get; private set; } // The user being followed
        public DateTime FollowedAt { get; private set; }

        public Follow(Guid followerId, Guid followeeId)
        {
            if (followerId == followeeId)
                throw new ArgumentException("A user cannot follow themselves.");

            FollowerId = followerId;
            FolloweeId = followeeId;
            FollowedAt = DateTime.UtcNow;
        }
    }
}
