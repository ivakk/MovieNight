using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieNight_BusinessLogic.Services;
using MovieNight_Classes;
using MovieNight_DataAccess.Controllers;
using MovieNight_DataAccess;
using MovieNight_InterfacesLL.IServices;

namespace MovieNight.Pages.Account
{
    public class ProfileModel : PageModel
    {
        public User LoggedInUser { get; set; }
        public User CurrentUser { get; set; }

        private readonly IUserManager userManager;

        public ProfileModel()
        {
            userManager = new UserManager(new UserDALManager());
            CurrentUser = new User();
            LoggedInUser = new User();
        }
        public void OnGet(int userId)
        {
            CurrentUser = userManager.GetUserById(userId);
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
        public string Reason(User user)
        {
            return userManager.GetReason(user);
        }
    }
}
