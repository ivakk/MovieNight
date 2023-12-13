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

namespace MovieNight_BusinessLogic.Services
{
    public class UserManager : IUserManager
    {
        IUserDALManager controller;
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
        public bool CreateUser(User user)
        {
            return controller.InsertUser(user);
        }


        public User CheckUser(string username, string password)
        {
            if (!controller.IsPasswordCorrect(username, password))
            {
                throw new Exception();
            }

            User user = controller.GetUserByUsername(username);

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
    }
}
