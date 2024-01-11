using MovieNight_DataAccess.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_Classes;
using MovieNight_InterfacesDAL.IManagers;
using MovieNight_InterfacesLL.IServices;
using System.Diagnostics;

namespace MovieNight_BusinessLogic.Services
{
    public class FavouritesManager : IFavouritesManager
    {
        IFavouritesDALManager controller;

        public FavouritesManager(IFavouritesDALManager controller)
        {
            this.controller = controller;
        }

        public List<Folderkeep> GetFolder(int userId)
        {
            return controller.GetUserFolders(userId);
        }
        public void AddTo(Folderkeep folders)
        {
            controller.AddToFolders(folders);
        }
        public void RemoveFrom(Folderkeep folders)
        {
            controller.RemoveFromFolders(folders);
        }
        public bool CheckFolder(int mediaId, int userId)
        {
            if (controller.CheckUserFolder(mediaId, userId)) { return true; }
            return false;
        }
    }
}
