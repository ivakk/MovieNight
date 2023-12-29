using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieNight_Classes;
using MovieNight_BusinessLogic.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Net.Mail;
using MovieNight_DataAccess.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MovieNight_InterfacesLL.IServices;

namespace MovieNight.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required]
        public string? Username { get; set; }
        [BindProperty]
        [Required]
        public string? Password { get; set; }

        public void OnGet()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Account/YourAccount");
                return;
            }
        }

        public void OnPost()
        {
            IUserManager userManager = new UserManager(new UserDALManager());

            try
            {
                User user = userManager.CheckUser(Username, Password);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username.ToLower()),
                    new Claim("id", user.Id.ToString()),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(new ClaimsPrincipal(identity));

                Response.Redirect("/Account/YourAccount");
            }
            catch (Exception)
            {
                if (userManager.BannedUser(userManager.GetByUsername(Username)))
                {
                    ViewData["Error"] = "You are currently banned!";
                }
                else
                {
                    ViewData["Error"] = "Check your account details!";
                }
            }
        }
    }
}
