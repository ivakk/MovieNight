using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieNight_BusinessLogic.Services;
using MovieNight_DataAccess.Entities;


namespace MovieNight.Pages.Account
{
    public class YourAccountModel : PageModel
    {
        public void OnGet()
        {
            UserManager userManager = new UserManager();

            User? UserLogic;

            if (User.FindFirst("id") != null)
            {
                //Checks whether anyone is logged in
                try
                {
                    UserLogic = userManager.GetUserById(int.Parse(User.FindFirst("id").Value));
                    ViewData["Username"] = UserLogic.Username;
                }
                catch (ArgumentException ex)
                {
                    ViewData["Error"] = ex.Message;
                }
            }
            else
            {
                Response.Redirect("/Account/YourAccount");
            }
        }
    }
}
