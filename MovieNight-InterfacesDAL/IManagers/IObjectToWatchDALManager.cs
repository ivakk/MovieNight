using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_Classes;

namespace MovieNight_InterfacesDAL.IManagers
{
    public interface IObjectToWatchDALManager
    {
        int GetNextId();
        ObjectToWatch GetObjectById(int id);
        List<ObjectToWatch> GetAllObjects();
        void UpdateObject(ObjectToWatch newObject);
        void DeleteObject(int id);
        void CreateObject(ObjectToWatch newObject);
    }
}
