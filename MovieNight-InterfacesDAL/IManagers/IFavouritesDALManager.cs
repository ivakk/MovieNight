using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_Classes;

namespace MovieNight_InterfacesDAL.IManagers
{
    public interface IFavouritesDALManager
    {
        List<Folderkeep> GetUserFolders(int userId);
        void AddToFolders(Folderkeep folders);
        void RemoveFromFolders(Folderkeep folders);
        bool CheckUserFolder(int mediaId, int userId);
    }
}
