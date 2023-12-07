using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieNight_DataAccess.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Net.Mail;

namespace MovieNight.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string? Username { get; set; }
        [BindProperty]
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
            if (string.IsNullOrWhiteSpace(Username) ||
                string.IsNullOrWhiteSpace(Password))
            {
                ViewData["Error"] = "Please fill in all fields";
                return;
            }

            try
            {
                User user = new User(Username, Password);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Username.ToLower()),
                    new Claim("id", user.Id.ToString()),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(new ClaimsPrincipal(identity));

                Response.Redirect("/Account/YourAccount");
            }
            catch (ArgumentException ex)
            {
                ViewData["Error"] = ex.Message;
            }
        }
    }
}
