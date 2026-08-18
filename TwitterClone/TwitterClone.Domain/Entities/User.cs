using System.Text.RegularExpressions;

namespace TwitterClone.Domain.Entities
{
    public class User : BaseEntity, IFollowable, INotifiable
    {
        private readonly HashSet<Guid> _followers = new HashSet<Guid>();
        private readonly List<Guid> _notifications = new List<Guid>();

        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Bio { get; private set; }

        private static readonly Regex EmailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled
        );

        public User(string username, string email) : base()
        {
            SetUsername(username);
            SetEmail(email);
        }

        public void SetUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be null or empty.");

            Username = username;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !EmailRegex.IsMatch(email))
                throw new ArgumentException("Invalid email format.");

            Email = email;
        }

        public void UpdateBio(string bio)
        {
            if (bio?.Length > 160)
                throw new ArgumentException("Bio cannot exceed 160 characters.");

            Bio = bio;
        }

        public void Follow(Guid userId)
        {
            if (userId == Id)
                throw new ArgumentException("A user cannot follow themselves.");

            _followers.Add(userId);
        }

        public void Unfollow(Guid userId)
        {
            _followers.Remove(userId);
        }

        public void AddNotification(Guid notificationId)
        {
            _notifications.Add(notificationId);
        }

        public IReadOnlyCollection<Guid> Followers => _followers;
        public IReadOnlyCollection<Guid> Notifications => _notifications;
    }
}
