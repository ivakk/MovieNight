using MovieNight_DataAccess.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_Classes;
using MovieNight_InterfacesDAL.IManagers;
using MovieNight_InterfacesLL.IServices;

namespace MovieNight_BusinessLogic.Services
{
    public class CategoryManager : ICategoryManager
    {
        ICategoryDALManager controller;

        public CategoryManager(ICategoryDALManager controller)
        {
            this.controller = controller;
        }

        public List<Category> GetAll()
        {
            return (List<Category>)controller.GetAllCategories();
        }
        public Category GetByName(string Name)
        {
            foreach (Category category in GetAll())
            {
                if (category.Name == Name)
                {
                    return category;
                }
            }
            return null;
        }
    }
}
