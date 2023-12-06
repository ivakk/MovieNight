using MovieNight_DataAccess.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_DataAccess.Entities;

namespace MovieNight_BusinessLogic.Services
{
    public class SeriesManager : ObjectToWatchManager
    {
        SeriesDALManager manager = new SeriesDALManager();
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
            base.Create(series);
            manager.CreateSeries(series);
        }
        public void Update(Series series)
        {
            base.Update(series);
            manager.UpdateSeries(series);
        }
        public void Delete(int id)
        {
            base.Delete(id);
            manager.DeleteSeries(id);
        }
    }
}
