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
    public class RegisterModel : PageModel
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
        [DataType(DataType.Date)]
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/\d{4}$", ErrorMessage = "Please use dd/mm/yyyy format!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Birthdate is required!")]
        public DateTime? Birthdate { get; set; }

        private readonly IUserManager userManager;
        private readonly IPasswordHashingManager hashing;
        string passwordSalt;
        string passwordHash;

        public RegisterModel()
        {
            userManager = new UserManager(new UserDALManager());
            hashing = new PasswordHashingManager();
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Error"] = "Something went wrong!";
                Page();
            }

            if (Username != null && userManager.UsernameExists(Username) == true)
            {
                ViewData["Error"] = "The username \"" + Username + "\" is already in use by another user!";
                Page();
            }
            else if (Email != null && userManager.EmailExists(Email) == true)
            {
                ViewData["Error"] = "The email \"" + Email + "\" is already in use by another user!";
                Page();
            }
            else
            {
                DateTime birthdate = Birthdate.Value;
                passwordSalt = hashing.PassSalt(10);
                passwordHash = hashing.PassHash(Password, passwordSalt);
                User regUser = new User(0,
                                        FirstName,
                                        LastName,
                                        birthdate,
                                        Username,
                                        Email,
                                        passwordHash,
                                        passwordSalt,
                                        "default");
                userManager.CreateUser(regUser);
                Response.Redirect("/Account/Login");
            }
        }
    }
}
