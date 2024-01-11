using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieNight_BusinessLogic.Services;
using MovieNight_Classes;
using MovieNight_DataAccess.Controllers;
using MovieNight_InterfacesLL.IServices;

namespace MovieNight.Pages.Catalogues
{
    public class SeriesModel : PageModel
    {
        public List<Series> Series { get; set; }
        public User LoggedInUser { get; set; }


        private readonly IUserManager userManager;
        private readonly ISeriesManager seriesManager;

        public SeriesModel()
        {
            userManager = new UserManager(new UserDALManager());
            seriesManager = new SeriesManager(new SeriesDALManager());
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

            Series = seriesManager.GetAll();
            Series.Reverse();
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
