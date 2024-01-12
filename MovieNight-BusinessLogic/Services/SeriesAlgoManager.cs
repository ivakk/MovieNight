using MovieNight_DataAccess.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_Classes;
using MovieNight_InterfacesLL.IServices;
using MovieNight_InterfacesDAL.IManagers;
using Microsoft.VisualStudio.Services.Common;
using System.Diagnostics;

namespace MovieNight_BusinessLogic.Services
{
    public class SeriesAlgoManager : ISeriesAlgoManager
    {
        ISeriesDALManager manager;
        IUserManager userManager;
        IRatingManager ratingManager;

        public SeriesAlgoManager(ISeriesDALManager _manager, IUserManager _userManager, IRatingManager _ratingManager) 
        {
            manager = _manager;
            userManager = _userManager;
            ratingManager = _ratingManager;
        }
        public List<Series> GetAll()
        {
            return (List<Series>)manager.GetAllSeries();
        }
        public Series GetById(int id)
        {
            return (Series)manager.GetSeriesById(id);
        }

        public List<Series> Recommend(User user)
        {
            HashSet<Series> recommendedMovies = new HashSet<Series>();
            var nearbyUsers = GetNearbyUsers(user);
            List<int> seriesLikedByUser = GetSeriesLikedByUser(user.Id);

            foreach (var media in GetAll())
            {
                if (IsMatchingUserPreferences(media, seriesLikedByUser) && IsLikedByNearbyUsers(media, nearbyUsers))
                {
                    recommendedMovies.Add(media);
                }
            }

            return recommendedMovies.ToList();
        }

        private List<User> GetNearbyUsers(User user)
        {
            return userManager.GetAllUsers()
                .Where(person => Math.Abs(CalculateAge(person.Birthday, user.Birthday)) <= 2)
                .ToList();
        }

        private List<int> GetSeriesLikedByUser(int userId)
        {
            return new List<int>(ratingManager.TotalMovie()
                .Where(rating => rating.UserId == userId && rating.Rate > 3)
                .Select(rating => rating.MediaId));
        }

        private bool IsMatchingUserPreferences(Series media, List<int> seriesLikedByUser)
        {
            return seriesLikedByUser
                .Select(movieId => GetById(movieId))
                .Any(likedMedia => IsSimilar(media, likedMedia));
        }

        private bool IsLikedByNearbyUsers(Series media, List<User> nearbyUsers)
        {
            return nearbyUsers.Any(person => ratingManager.TotalMovie()
                .Any(mr => mr.UserId == person.Id && mr.MediaId == media.Id && mr.Rate > 3));
        }

        private int CalculateAge(DateTime birthdate, DateTime userBirthdate)
        {
            int age = userBirthdate.Year - birthdate.Year;
            if (birthdate.Date > userBirthdate.AddYears(-age)) age--;
            return age;
        }

        private bool IsSimilar(Series media, Series otherMedia)
        {
            if (media != null && otherMedia != null) 
            {
                return media.Category.ToString() == otherMedia.Category.ToString();
            }
            return false;
        }
        public List<Series> SortDesc()
        {
            return (List<Series>)manager.SortRateDesc();
        }
    }
}
