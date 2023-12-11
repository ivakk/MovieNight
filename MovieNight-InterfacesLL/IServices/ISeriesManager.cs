using MovieNight_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_InterfacesLL.IServices
{
    public interface ISeriesManager
    {
        List<Series> GetAll();
        Series GetById(int id);
        List<Series> GetBySearch(string search);
        void Create(Series series);
        void Update(Series series);
        void Delete(int id);
    }
}
