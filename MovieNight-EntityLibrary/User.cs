using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_EntityLibrary
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public DateTime Birthdate { get; set; }
        public string Nationality { get; set; }

        public User(int id, string firstName, string lastName, string email, string phoneNumber, string position, DateTime birthdate, string nationality)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Position = position;
            Birthdate = birthdate;
            Nationality = nationality;
        }

        public User()
        {
        }

        protected bool Equals(User other)
        {
            return Id == other.Id && FirstName == other.FirstName && LastName == other.LastName 
                   && Email == other.Email && PhoneNumber == other.PhoneNumber 
                   && Position == other.Position && Birthdate.Equals(other.Birthdate) 
                   && Nationality == other.Nationality;
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
            return HashCode.Combine(Id, FirstName, LastName, Email, PhoneNumber,
                Position, Birthdate, Nationality);
        }
    }
}
