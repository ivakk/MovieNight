using MovieNight_DataAccess.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_DataAccess.Entities;

namespace MovieNight_BusinessLogic.Services
{
    public class ObjectToWatchManager
    {

        ObjectToWatchDALManager manager = new ObjectToWatchDALManager();
        public List<ObjectToWatch> GetAll()
        {
            return (List<ObjectToWatch>)manager.GetAllObjects();
        }
        public ObjectToWatch GetById(int id)
        {
            return (ObjectToWatch)manager.GetObjectById(id);
        }

        public List<ObjectToWatch> GetBySearch(string search)
        {
            List<ObjectToWatch> result = new List<ObjectToWatch>();
            foreach (ObjectToWatch Object in GetAll())
            {
                if (Object.GetObjectString().Contains(search))
                {
                    result.Add(Object);
                }
            }
            return result;
        }
        public void Create(ObjectToWatch Object)
        {
            manager.CreateObject(Object);
        }
        public void Update(ObjectToWatch Object)
        {
            manager.UpdateObject(Object);
        }
        public void Delete(int id)
        {
            manager.DeleteObject(id);
        }

    }
}
