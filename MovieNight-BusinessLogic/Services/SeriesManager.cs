using MovieNight_DataAccess.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_Classes;
using MovieNight_InterfacesLL.IServices;
using MovieNight_InterfacesDAL.IManagers;

namespace MovieNight_BusinessLogic.Services
{
    public class SeriesManager : ISeriesManager
    {
        ISeriesDALManager manager;

        public SeriesManager(ISeriesDALManager manager)
        {
            this.manager = manager;
        }
        public List<Series> GetAll()
        {
            return (List<Series>)manager.GetAllSeries();
        }
        public Series GetById(int id)
        {
            return (Series)manager.GetSeriesById(id);
        }

        public List<Series> GetBySearch(string search)
        {
            List<Series> result = new List<Series>();
            foreach (Series series in GetAll())
            {
                if (series.GetObjectString().Contains(search))
                {
                    result.Add(series);
                }
            }
            return result;
        }
        public void Create(Series series)
        {
            manager.CreateSeries(series);
        }
        public void Update(Series series)
        {
            manager.UpdateSeries(series);
        }
        public void Delete(int id)
        {
            manager.DeleteSeries(id);
        }
    }
}
