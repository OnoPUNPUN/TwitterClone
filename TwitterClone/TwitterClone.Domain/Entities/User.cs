using System.Text.RegularExpressions;

namespace TwitterClone.Domain.Entities
{
    public class User
    {
        private Guid _id;
        private string _username;
        private string _email;
        
        public Guid Id
        {
            get { return _id; }
        }

        private static readonly Regex EmailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled
        );

        public string Username
        { 
            get { return _username; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username cannot be null or empty.");
                }
                _username = value;
            }
        }

        public string Email
        { 
            get { return _email; }
            set 
            { 
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email cannot be null or empty.");
                } else if (!IsValidRegex(value))
                {
                    throw new ArgumentException("Email format is invalid.");
                }
                _email = value;
            }
        }

        static bool IsValidRegex(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return EmailRegex.IsMatch(email);
        }
    }
}
