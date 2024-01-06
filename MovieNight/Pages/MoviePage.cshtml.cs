using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieNight_BusinessLogic.Services;
using MovieNight_Classes;
using MovieNight_DataAccess.Controllers;
using MovieNight_InterfacesLL.IServices;
using System.Diagnostics;
using System.Security.Claims;

namespace MovieNight.Pages
{
    public class MoviePageModel : PageModel
    {
        public Movie Movie { get; set; }
        public List<Comments> Comments { get; set; }
        public string Username { get; set; }
        [BindProperty]
        public string CommentLeft { get; set; }
        [BindProperty]
        public string DelCommentId { get; set; }
        public int UserId { get; set; }

        private readonly IMovieManager movieManager;
        public readonly ICommentManager commentManager;
        private readonly IUserManager userManager;

        public MoviePageModel()
        {
            movieManager = new MovieManager(new MovieDALManager());
            commentManager = new CommentManager(new CommentDALManager());
            userManager = new UserManager(new UserDALManager());
        }
        public void OnGet(int id)
        {
            Movie = movieManager.GetById(id);
            Comments = commentManager.GetAll(Movie.Id);
            foreach (var comment in Comments)
            {
                comment.Username = userManager.GetUserById(comment.UserId).Username;
            }
        }
        public IActionResult OnPostComment(int id)
        {
            if (!ModelState.IsValid)
            {
                // Set an error message or handle the invalid state as needed
                ViewData["Error"] = "There was a problem posting your comment.";
                return Page(); // Return the current page with the populated properties
            }

            //Checks whether anyone is logged in
            if (User.FindFirst("id") != null)
            {
                try
                {
                    UserId = int.Parse(User.FindFirst("id").Value);
                    commentManager.PostComment(new Comments(0, UserId, id, DateTime.Now, CommentLeft));

                    CommentLeft = ""; // Reset the comment box

                    return RedirectToPage(new { id = id });
                }
                catch (Exception ex)
                {
                    ViewData["Error"] = ex.Message;
                    return RedirectToPage(new { id = id });
                }
            }
            else
            {
                return RedirectToPage("/Account/Login");
            }
        }

        public bool CanDeleteComment(int id)
        {
            //Checks whether anyone is logged in
            if (User.FindFirst("id") != null)
            {
                try
                {
                    UserId = int.Parse(User.FindFirst("id").Value);
                    if (userManager.GetUserById(UserId).Role == "admin" || userManager.GetUserById(UserId).Id == id)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    return false;
                }
            }
            return false;
        }
        public IActionResult OnPostDeleteComment(int id, int commentId)
        {
            try
            {
                // Authorization check: Ensure the user is allowed to delete the comment
                Debug.WriteLine(commentId);
                var comment = commentManager.GetById(commentId);
                if (comment != null && CanDeleteComment(comment.UserId))
                {
                    commentManager.DelComment(commentId);
                    return RedirectToPage(new { id = id });
                }

                // If the user is not authorized to delete, handle accordingly
                // Redirect to the same page with an error message or a status
                TempData["ErrorMessage"] = "You are not authorized to delete this comment.";
                return RedirectToPage(new { id = id });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return RedirectToPage(new {id = id});
            }
        }
    }
}
