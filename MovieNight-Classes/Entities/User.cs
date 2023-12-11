
using Microsoft.VisualStudio.Services.Graph.Client;

namespace MovieNight_Classes
{
    public class User
    {
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Role { get; set; }


        public User(int id, string firstName, string lastName, DateTime birthdate, string username, string email, string passwordHash, string passwordSalt, string role)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthdate;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
            Role = role;
        }

        public User()
        {
        }

        protected bool Equals(User other)
        {
            return FirstName == other.FirstName && LastName == other.LastName
                                                && Email == other.Email
                                                && Role == other.Role && Birthday.Equals(other.Birthday);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((User)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, Email, Birthday);
        }

        public string GetObjectString()
        {
            return Id.ToString() + Username + FirstName + LastName + Email + Role + Birthday.ToString();
        }
    }
}
