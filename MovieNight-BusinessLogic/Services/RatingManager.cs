using MovieNight_DataAccess.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_Classes;
using MovieNight_InterfacesDAL.IManagers;
using MovieNight_InterfacesLL.IServices;

namespace MovieNight_BusinessLogic.Services
{
    public class RatingManager : IRatingManager
    {
        IRatingDALManager controller;

        public RatingManager(IRatingDALManager controller)
        {
            this.controller = controller;
        }

        public Rating GetRate(int mediaId, int userId)
        {
            return controller.GetUserRate(mediaId, userId);
        }
        public void PostRate(Rating rating)
        {
            controller.InsertRate(rating);
        }
        public void ChangeRate(Rating rating)
        {
            controller.UpdateRate(rating);
        }
        public void RemoveRate(int id)
        {
            controller.DeleteRate(id);
        }
        public bool CheckRate(int mediaId, int userId)
        {
            return controller.CheckUserRating(mediaId, userId);
        }
        public int GetCount(int mediaId)
        {
            return controller.TotalRatings(mediaId);
        }
        public int GetWeek()
        {
            return controller.WeekRatings();
        }
        public int GetAvgRate(int mediaId)
        {
            return controller.AvgRating(mediaId);
        }
    }
}
