using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieNight_BusinessLogic.Services;
using MovieNight_Classes;
using MovieNight_DataAccess.Controllers;
using MovieNight_InterfacesLL.IServices;

namespace MovieNight.Pages.Catalogues
{
    public class MoviesModel : PageModel
    {
        public List<Movie> Movies { get; set; }
        public User LoggedInUser { get; set; }


        private readonly IUserManager userManager;
        private readonly IMovieManager movieManager;

        public MoviesModel()
        {
            userManager = new UserManager(new UserDALManager());
            movieManager = new MovieManager(new MovieDALManager());
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

            Movies = movieManager.GetAll();
            Movies.Reverse();
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
