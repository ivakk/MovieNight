using Microsoft.TeamFoundation.Test.WebApi;
using MovieNight_DataAccess;
using MovieNight_DataAccess.Controllers;
using MovieNight_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_InterfacesDAL.IManagers;
using MovieNight_InterfacesLL.IServices;
using MovieNight_InterfacesDAL;
using System.Text.RegularExpressions;

namespace MovieNight_BusinessLogic.Services
{
    public class UserManager : IUserManager
    {
        IUserDALManager controller;
        PasswordHashingManager passwordHasher = new PasswordHashingManager();
        public UserManager(IUserDALManager controller)
        {
            this.controller = controller;
        }


        public List<User> GetAllUsers()
        {
            return controller.GetAll();
        }
        public User GetUserById(int id)
        {
            return controller.GetUserById(id);
        }
        public User GetByUsername(string username)
        {
            return controller.GetUserByUsername(username);
        }
        public bool CreateUser(User user)
        {
            return controller.InsertUser(user);
        }

        public bool IsUserPasswordCorrect(string username, string password)
        {
            /// <summary>
            /// This function returns true, if the password is correct for the given username.
            /// </summary>

            // Get user by username property, 
            User user = GetByUsername(username);

            // If there is no user with the given username address, return false.
            if (user == null)
            {
                // No user found with given username.
                return false;
            }

            string hashedPasswordToCheck = passwordHasher.PassHash(password, user.PasswordSalt);

            if (user.PasswordHash == hashedPasswordToCheck)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User CheckUser(string username, string password)
        {
            if (!IsUserPasswordCorrect(username, password))
            {
                throw new Exception();
            }

            User user = GetByUsername(username);

            return user;
        }

        public List<User> GetBySearch(string search)
        {
            List<User> result = new List<User>();
            foreach (User User in GetAllUsers())
            {
                if (User.GetObjectString().Contains(search))
                {
                    result.Add(User);
                }
            }
            return result;
        }
        public bool UpdateUser(User user)
        {
            return controller.UpdateUser(user);
        }
        public void DeleteUser(int id)
        {
            controller.DeleteUser(id);
        }
        public void BanningUser(User user, string reason)
        {
            controller.BanUser(user, reason);
        }
        public void UnbanningUser(User user)
        {
            controller.UnbanUser(user);
        }
        public bool BannedUser(User bannedUser)
        {
            if(controller.IsUserBanned(bannedUser) == true) { return true; }
            return false;
        }

        public bool EmailCheck(string email)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);

            return emailRegex.IsMatch(email);
        }

        public bool UsernameExists(string username)
        {
            if (controller.ExistingUsername(username) == true) { return true; }
            return false;
        }
        public bool EmailExists(string email)
        {
            if (controller.ExistingEmail(email) == true) { return true; }
            return false;
        }
    }
}
