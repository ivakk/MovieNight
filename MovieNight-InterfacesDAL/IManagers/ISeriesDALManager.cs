using MovieNight_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MovieNight_InterfacesDAL.IManagers
{
    public interface ISeriesDALManager
    {
        Series GetSeriesById(int id);
        List<Series> GetAllSeries();
        void UpdateSeries(Series newSeries);
        void DeleteSeries(int id);
        void CreateSeries(Series newSeries);
    }
}
