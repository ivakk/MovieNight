using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_Classes;

namespace MovieNight_InterfacesDAL.IManagers
{
    public interface IUserDALManager
    {
        User GetUserById(int id);
        User GetUserByUsername(string username);
        List<User> GetAll();
        bool UpdateUser(User newUser);
        void DeleteUser(int id);
        bool InsertUser(User newUser);
        void BanUser(User banUser, string reason);
        void UnbanUser(User bannedUser);
        bool IsUserBanned(User bannedUser);
        bool ExistingUsername(string username);
        bool ExistingEmail(string email);
        List<User> GetSearch(string search);
        public string GetBanReason(User banUser);
    }
}
