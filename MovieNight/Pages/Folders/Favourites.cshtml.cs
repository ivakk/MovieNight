using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.TeamFoundation.TestManagement.WebApi;
using MovieNight_BusinessLogic.Services;
using MovieNight_Classes;
using MovieNight_DataAccess.Controllers;
using MovieNight_DataAccess;
using Microsoft.AspNetCore.Identity;
using MovieNight_InterfacesLL.IServices;

namespace MovieNight.Pages.Folders
{
    public class FavouritesModel : PageModel
    {
        public List<Folderkeep> Added { get; set; }
        public User LoggedInUser { get; set; }
        public User CurrentUser { get; set; }
        public int UserId { get; set; }
        public List<Movie> AddedMovies { get; set; }
        public List<Series> AddedSeries { get; set; }

        private readonly IUserManager userManager;
        private readonly IMovieManager movieManager;
        private readonly ISeriesManager seriesManager;
        private readonly IFavouritesManager favouritesManager;

        public FavouritesModel(IUserManager _userManager, IMovieManager _movieManager, ISeriesManager _seriesManager, IFavouritesManager _favouritesManager)
        {
            userManager = _userManager;
            movieManager = _movieManager;
            seriesManager = _seriesManager;
            favouritesManager = _favouritesManager;
            AddedMovies = new List<Movie>();
            AddedSeries = new List<Series>();
        }

        public void OnGet(int id)
        {
            UserId = id;
            CurrentUser = userManager.GetUserById(UserId);
            if (favouritesManager.GetFolder(id) != null)
            {
                Added = favouritesManager.GetFolder(UserId);
                foreach (var item in Added)
                {
                    if (item.Type == 0)
                    {
                        AddedMovies.Add(movieManager.GetById(item.MediaId));
                    }
                    else if (item.Type == 1)
                    {
                        AddedSeries.Add(seriesManager.GetById(item.MediaId));
                    }
                }
            }
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
