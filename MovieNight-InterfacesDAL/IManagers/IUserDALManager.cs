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
        bool IsPasswordCorrect(string username, string password);

    }
}
