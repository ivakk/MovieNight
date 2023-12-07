
using Microsoft.VisualStudio.Services.Graph.Client;
using MovieNight_DataAccess.Controllers;

namespace MovieNight_DataAccess.Entities
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
        public User(string username, string password)
        {
            UserDALManager controller = new UserDALManager();

            if (!controller.IsPasswordCorrect(username, password))
            {
                throw new ArgumentException("Your login details are incorrect.");
            }

            User user = controller.GetUserByUsername(username);

            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Birthday = user.Birthday;
            Username = user.Username;
            Email = user.Email;
            PasswordHash = user.PasswordHash;
            PasswordSalt = user.PasswordSalt;
            Role = user.Role;
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
