using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_Classes;

namespace MovieNight_InterfacesLL.IServices
{
    public interface IRatingManager
    {
        Rating GetRate(int mediaId, int userId);
        void PostRate(Rating rate);
        void RemoveRate(int id);
        void ChangeRate(Rating rate);
        bool CheckRate(int mediaId, int userId);
    }
}
