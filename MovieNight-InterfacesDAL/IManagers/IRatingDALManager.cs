using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_Classes;

namespace MovieNight_InterfacesDAL.IManagers
{
    public interface IRatingDALManager
    {
        Rating GetUserRate(int mediaId, int userId);
        void InsertRate(Rating rating);
        void DeleteRate(int id);
        bool CheckUserRating(int mediaId, int userId);
        void UpdateRate(Rating rating);
        int TotalRatings(int mediaId);
        int WeekRatings();
        int AvgRating(int mediaId);
    }
}
