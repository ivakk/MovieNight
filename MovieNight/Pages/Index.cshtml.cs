using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieNight_BusinessLogic.Services;
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
        UserManager userManager = new UserManager(new UserDALManager());

        private readonly ILogger<IndexModel> _logger;

        public User? UserLogic;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //Checks whether anyone is logged in
            if (User.FindFirst("id") != null)
            {
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
        }
    }
}