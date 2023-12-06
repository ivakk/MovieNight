using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_DataAccess.Entities;
using MovieNight_DataAccess.Controllers;

namespace MovieNight_InterfacesDAL.IEntities
{
    public interface ICategory
    {
        Category Category(int id, string name);

        Category Category();

        string ToString();

    }
}
