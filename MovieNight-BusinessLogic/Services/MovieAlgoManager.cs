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
    public class MovieAlgoManager : IMovieAlgoManager
    {
        IMovieDALManager manager;
        IUserManager userManager;
        IRatingManager ratingManager;

        public MovieAlgoManager(IMovieDALManager _manager, IUserManager _userManager, IRatingManager _ratingManager) 
        {
            manager = _manager;
            userManager = _userManager;
            ratingManager = _ratingManager;
        }
        public List<Movie> GetAll()
        {
            return (List<Movie>)manager.GetAllMovies();
        }
        public Movie GetById(int id)
        {
            return (Movie)manager.GetMovieById(id);
        }

        public List<Movie> Recommend(User user)
        {
            HashSet<Movie> recommendedMovies = new HashSet<Movie>();
            var nearbyUsers = GetNearbyUsers(user);
            List<int> moviesLikedByUser = GetMoviesLikedByUser(user.Id);

            foreach (var media in GetAll())
            {
                if (IsMatchingUserPreferences(media, moviesLikedByUser) && IsLikedByNearbyUsers(media, nearbyUsers))
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

        private List<int> GetMoviesLikedByUser(int userId)
        {
            return new List<int>(ratingManager.TotalMovie()
                .Where(rating => rating.UserId == userId && rating.Rate > 3)
                .Select(rating => rating.MediaId));
        }

        private bool IsMatchingUserPreferences(Movie media, List<int> moviesLikedByUser)
        {
            return moviesLikedByUser
                .Select(movieId => GetById(movieId))
                .Any(likedMedia => IsSimilar(media, likedMedia));
        }

        private bool IsLikedByNearbyUsers(Movie media, List<User> nearbyUsers)
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

        private bool IsSimilar(Movie media, Movie otherMedia)
        {
            return media.Category.ToString() == otherMedia.Category.ToString();
        }
        public List<Movie> SortDesc()
        {
            return (List<Movie>)manager.SortRateDesc();
        }
    }
}
