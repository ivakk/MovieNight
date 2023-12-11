using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_Classes;

namespace MovieNight_InterfacesLL.IServices
{
    public interface IUserManager
    {
        List<User> GetAllUsers();
        User CheckUser(string username, string password);
        User GetUserById(int id);
        bool CreateUser(User user);
        List<User> GetBySearch(string search);
        bool UpdateUser(User user);
        void DeleteUser(int id);
    }
}
