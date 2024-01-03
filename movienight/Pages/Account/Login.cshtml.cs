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
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Username should be between 3 and 16 letters and numbers!")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Invalid username!")] 
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required!")]
        public string? Username { get; set; }

        [BindProperty]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "Password should be between 8 and 32 symbols!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required!")]
        public string? Password { get; set; }

        [BindProperty]
        [EmailAddress(ErrorMessage = "Enter a valid email address!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required!")]
        public string? Email { get; set; }

        [BindProperty]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter a valid first name!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required!")]
        public string? FirstName { get; set; }

        [BindProperty]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter a valid last name!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required!")]
        public string? LastName { get; set; }

        [BindProperty]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Birthdate is required!")]
        public DateTime Birthdate { get; set; }

        [BindProperty]
        public string Action { get; set; }

        private readonly IUserManager userManager;

        public LoginModel()
        {
            userManager = new UserManager(new UserDALManager());
        }

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
            if (!ModelState.IsValid)
            {
                ViewData["Error"] = "Something went wrong!";
                Page();
            }


            try
            {
                if (Username != null && userManager.BannedUser(userManager.GetByUsername(Username)))
                {
                    ViewData["Error"] = "You are currently banned!";
                    Page();
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

                    Response.Redirect("/Index");
                }
            }
            catch (Exception)
            {
                ViewData["Error"] = "Check your login details!";
                Page();
            }
        }
    }
}
