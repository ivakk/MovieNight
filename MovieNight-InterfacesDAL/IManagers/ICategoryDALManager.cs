using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_Classes;

namespace MovieNight_InterfacesDAL.IManagers
{
    public interface ICategoryDALManager
    {
        Category GetCategoryById(int id, SqlDataReader reader);
        List<Category> GetAllCategories();
        void UpdateCategory(Category newCategory);
        void DeleteCategory(int id);
        void InsertCategory(Category newCategory);
    }
}
