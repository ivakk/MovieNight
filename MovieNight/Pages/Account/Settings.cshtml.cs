using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieNight_BusinessLogic.Services;
using MovieNight_Classes;
using MovieNight_DataAccess.Controllers;
using MovieNight_DataAccess;
using MovieNight_InterfacesLL.IServices;
using MovieNight_InterfacesLL;
using System.ComponentModel.DataAnnotations;
using Amazon.Runtime.Internal.Util;
using Microsoft.AspNetCore.Identity;

namespace MovieNight.Pages.Account
{
    public class SettingsModel : PageModel
    {
        public User LoggedInUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [BindProperty]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "Password should be between 8 and 32 symbols!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required!")]
        public string Password { get; set; }

        [BindProperty]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "Passwords should match!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required!")]
        public string ConfirmPassword { get; set; }

        private readonly IUserManager userManager;
        private readonly IPasswordHashingManager hashing;

        public SettingsModel(IUserManager _userManager, IPasswordHashingManager _hashing)
        {
            userManager = _userManager;
            hashing = _hashing;
            LoggedInUser = new User();
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
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Error"] = "Something went wrong!";
                return Page();
            }
            try
            {
                LoggedInUser = userManager.GetUserById(int.Parse(User.FindFirst("id").Value));
                if (Password != ConfirmPassword)
                {
                    ViewData["Error"] = "Passwords don't match!";
                    return Page();
                }
                if (FirstName == string.Empty)
                {
                    FirstName = LoggedInUser.FirstName;
                }
                if (LastName == string.Empty)
                {
                    LastName = LoggedInUser.LastName;
                }
                string passwordSalt = hashing.PassSalt(10);
                string passwordHash = hashing.PassHash(Password, passwordSalt);
                User regUser = new User(LoggedInUser.Id,
                                        FirstName,
                                        LastName,
                                        LoggedInUser.Birthday,
                                        LoggedInUser.Username,
                                        LoggedInUser.Email,
                                        passwordHash,
                                        passwordSalt,
                                        "default");
                userManager.UpdateUser(regUser);
                return RedirectToPage("/Index");
            }
            catch (ArgumentException ex)
            {
                return Page();
            }
        }
    }
}
