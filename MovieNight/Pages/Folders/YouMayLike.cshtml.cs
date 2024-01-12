using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieNight_BusinessLogic.Services;
using MovieNight_Classes;
using MovieNight_DataAccess.Controllers;
using MovieNight_InterfacesLL.IServices;
using System.Runtime.ExceptionServices;

namespace MovieNight.Pages.Folders
{
    public class YouMayLikeModel : PageModel
    {
        public User LoggedInUser { get; set; }
        public List<User> UserResults { get; set; }
        public List<Movie> MovieResults { get; set; }
        public List<Series> SeriesResults { get; set; }
        public List<Movie> MovieAlt { get; set; }
        public List<Series> SeriesAlt { get; set; }


        private readonly IUserManager userManager;
        private readonly IMovieAlgoManager movieManager;
        private readonly ISeriesAlgoManager seriesManager;
        private readonly IRatingManager ratingManager;

        public YouMayLikeModel(IUserManager _userManager, IMovieAlgoManager _movieManager, ISeriesAlgoManager _seriesManager, IRatingManager _ratingManager)
        {
            userManager = _userManager;
            movieManager = _movieManager;
            seriesManager = _seriesManager;
            ratingManager = _ratingManager;
        }
        public void OnGet()
        {

            if (User.FindFirst("id") != null)
            {
                try
                {
                    LoggedInUser = userManager.GetUserById(int.Parse(User.FindFirst("id").Value));
                    MovieResults = movieManager.Recommend(LoggedInUser);
                    SeriesResults = seriesManager.Recommend(LoggedInUser);
                    MovieAlt = movieManager.SortDesc();
                    SeriesAlt = seriesManager.SortDesc();
                    if (IsBanned(LoggedInUser))
                    {
                        RedirectToPage("/Account/Logout");
                    }
                }
                catch (ArgumentException ex)
                {
                    ViewData["Error"] = ex.Message;
                }
            }
        }

        public bool IsBanned(User user)
        {
            if (userManager.BannedUser(user) == true)
            {
                return true;
            }
            return false;
        }
        public bool IsRated(int mediaId)
        {
            return ratingManager.CheckRate(mediaId, LoggedInUser.Id);
        }
    }
}
