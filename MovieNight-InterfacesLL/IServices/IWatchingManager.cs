using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_Classes;

namespace MovieNight_InterfacesLL.IServices
{
    public interface IWatchingManager
    {
        List<Folderkeep> GetFolder(int userId);
        void AddTo(Folderkeep folders);
        void RemoveFrom(Folderkeep folders);
        bool CheckFolder(int mediaId, int userId);
    }
}
