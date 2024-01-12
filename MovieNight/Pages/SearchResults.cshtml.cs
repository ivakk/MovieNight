using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieNight_BusinessLogic.Services;
using MovieNight_Classes;
using MovieNight_DataAccess.Controllers;
using MovieNight_InterfacesLL.IServices;
using System.Runtime.ExceptionServices;

namespace MovieNight.Pages
{
    public class SearchResultsModel : PageModel
    {
        public User LoggedInUser { get; set; }
        public List<User> UserResults { get; set; }
        public List<Movie> MovieResults { get; set; }
        public List<Series> SeriesResults { get; set; }

        private readonly IUserManager userManager;
        private readonly IMovieManager movieManager;
        private readonly ISeriesManager seriesManager;
        
        public SearchResultsModel(IUserManager _userManager, IMovieManager _movieManager, ISeriesManager _seriesManager)
        {
            userManager = _userManager;
            movieManager = _movieManager;
            seriesManager = _seriesManager;
        }
        public void OnGet(string search)
        {
            UserResults = userManager.Search(search);
            MovieResults = movieManager.Search(search);
            SeriesResults = seriesManager.Search(search);

            if (User.FindFirst("id") != null)
            {
                try
                {
                    LoggedInUser = userManager.GetUserById(int.Parse(User.FindFirst("id").Value));
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
    }
}
