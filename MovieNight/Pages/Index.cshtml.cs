using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieNight_BusinessLogic.Services;
using MovieNight_InterfacesLL.IServices;
using MovieNight_Classes;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Diagnostics.Eventing.Reader;
using Microsoft.TeamFoundation.TestManagement.WebApi;
using MovieNight_DataAccess.Controllers;

namespace MovieNight.Pages
{
    public class IndexModel : PageModel
    {
        public List<Movie> LatestMovies { get; set; }
        public List<Series> LatestSeries { get; set; }
        public User LoggedInUser { get; set; }


        private readonly IUserManager userManager;
        private readonly IMovieManager movieManager;
        private readonly ISeriesManager seriesManager;

        public IndexModel(IUserManager _userManager, IMovieManager _movieManager, ISeriesManager _seriesManager)
        {
            userManager = _userManager;
            movieManager = _movieManager;
            seriesManager = _seriesManager;
        }

        public void OnGet()
        {
            //Checks whether anyone is logged in
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

            LatestMovies = movieManager.Get7();
            LatestSeries = seriesManager.Get7();
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