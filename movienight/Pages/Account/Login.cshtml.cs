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
using MovieNight_InterfacesLL;
using MovieNight_BusinessLogic;
using Amazon.Runtime.Internal.Util;

namespace MovieNight.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required!")]
        public string? Username { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required!")]
        public string? Password { get; set; }
     

        private readonly IUserManager userManager;

        public LoginModel(IUserManager _userManager)
        {
            userManager = _userManager;
        }

        public void OnGet()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Account/YourAccount");
                return;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Error"] = "Something went wrong!";
                return Page();
            }


            try
            {
                if (Username != null && userManager.BannedUser(userManager.GetByUsername(Username)))
                {
                    ViewData["Error"] = "You are currently banned!";
                    return Page();
                }
                else 
                {
                    User user = userManager.CheckUser(Username, Password);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username.ToLower()),
                        new Claim("id", user.Id.ToString()),
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    HttpContext.SignInAsync(new ClaimsPrincipal(identity));

                    return RedirectToPage("/Index");
                }
            }
            catch (Exception)
            {
                ViewData["Error"] = "Check your login details!";
                return Page();
            }
        }
    }
}
