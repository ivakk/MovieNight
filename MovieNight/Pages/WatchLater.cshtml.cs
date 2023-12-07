using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieNight_BusinessLogic.Services;
using MovieNight_DataAccess.Entities;

namespace MovieNight.Pages
{
    public class WatchLaterModel : PageModel
    {
        UserManager userManager = new UserManager();

        public User UserLogic { get; set; }
        
        public void OnGet()
        {
            //Check if session exsists
            int? sessionId = HttpContext.Session.GetInt32("SessionId");
            if (sessionId == null || sessionId == 0)
            {
                Response.Redirect("/Account/Login");
            }
            else
            {
                UserLogic = userManager.GetUserById((int)sessionId);
            }
        }
    }
}
