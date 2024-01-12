using MovieNight_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_InterfacesLL.IServices
{
    public interface ISeriesAlgoManager
    {
        List<Series> GetAll();
        Series GetById(int id);
        List<Series> Recommend(User user);
        List<Series> SortDesc();
    }
}
