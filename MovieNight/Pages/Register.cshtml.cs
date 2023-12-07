using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MovieNight.Pages
{
    public class RegisterModel : PageModel
    {
        public void OnGet()
        {
            if (User.FindFirst("id") != null)
            {
                Response.Redirect("/Account/YourAccount");
            }
        }
    }
}
