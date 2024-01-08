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
        [BindProperty]
        public string CommentLeft { get; set; }
        public int UserId { get; set; }
        public string WatchLaterButtonText => IsInWatchLater ? "Remove from Watch Later" : "Add to Watch Later";
        public bool IsInWatchLater { get; private set; }
        public string WatchingButtonText => IsInWatching ? "Remove from Currently Watching" : "Add to Currently Watching";
        public bool IsInWatching { get; private set; }
        public string FinishedButtonText => IsInFinished ? "Remove from Finished" : "Add to Finished";
        public bool IsInFinished { get; private set; }
        public bool IsRated {  get; private set; }


        private readonly IMovieManager movieManager;
        private readonly ICommentManager commentManager;
        private readonly IUserManager userManager;
        private readonly IWatchLaterManager watchLaterManager;
        private readonly IWatchingManager watchingManager;
        private readonly IFinishedManager finishedManager;
        private readonly IRatingManager ratingManager;

        public MoviePageModel()
        {
            movieManager = new MovieManager(new MovieDALManager());
            commentManager = new CommentManager(new CommentDALManager());
            userManager = new UserManager(new UserDALManager());
            watchLaterManager = new WatchLaterManager(new WatchLaterDALManager());
            watchingManager = new WatchingManager(new WatchingDALManager());
            finishedManager = new FinishedManager(new FinishedDALManager());
            ratingManager = new RatingManager(new RatingDALManager());
        }
        public void OnGet(int id)
        {
            Movie = movieManager.GetById(id);
            Comments = commentManager.GetAll(Movie.Id);
            if (User.FindFirst("id") != null)
            {
                UserId = int.Parse(User.FindFirst("id").Value);
                IsInWatchLater = watchLaterManager.CheckFolder(Movie.Id, UserId);
                IsInWatching = watchingManager.CheckFolder(Movie.Id, UserId);
                IsInFinished = finishedManager.CheckFolder(Movie.Id, UserId);
                IsRated = ratingManager.CheckRate(Movie.Id, UserId);
            }
            foreach (var comment in Comments)
            {
                comment.Username = userManager.GetUserById(comment.UserId).Username;
            }
        }
        public IActionResult OnPostComment(int id)
        {
            //Checks whether anyone is logged in
            if (User.FindFirst("id") != null)
            {
                try
                {
                    UserId = int.Parse(User.FindFirst("id").Value);
                    commentManager.PostComment(new Comments(0, UserId, id, DateTime.Now, CommentLeft));

                    CommentLeft = ""; // Reset the comment box

                    // Re-fetch movie data and other necessary data
                    Movie = movieManager.GetById(id);
                    Comments = commentManager.GetAll(id);

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
                var comment = commentManager.GetById(commentId);
                if (comment != null && CanDeleteComment(comment.UserId))
                {
                    commentManager.DelComment(commentId);

                    // Re-fetch movie data and other necessary data
                    Movie = movieManager.GetById(id);
                    Comments = commentManager.GetAll(id);

                    return RedirectToPage(new { id = id });
                }

                // If the user is not authorized to delete, handle accordingly
                // Redirect to the same page with an error message or a status
                TempData["ErrorMessage"] = "You are not authorized to delete this comment.";

                Movie = movieManager.GetById(id);
                Comments = commentManager.GetAll(id);

                return RedirectToPage(new { id = id });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Movie = movieManager.GetById(id);
                Comments = commentManager.GetAll(id);
                return RedirectToPage(new {id = id});
            }
        }
        public IActionResult OnPostToggleWatchLater(int movieId)
        {
            try
            {
                
                if (User.FindFirst("id") != null)
                {
                    UserId = int.Parse(User.FindFirst("id").Value);
                    IsInWatchLater = watchLaterManager.CheckFolder(movieId, UserId);
                    if (IsInWatchLater)
                    {
                        watchLaterManager.RemoveFrom(new Folderkeep(movieId, UserId));
                    }
                    else
                    {
                        watchLaterManager.AddTo(new Folderkeep(movieId, UserId));
                    }
                    IsInWatchLater = !IsInWatchLater;
                    // Re-fetch movie data and other necessary data
                    Movie = movieManager.GetById(movieId);
                    Comments = commentManager.GetAll(movieId);
                    return RedirectToPage(new { id = movieId });
                }
                else
                {
                    return RedirectToPage("/Account/Login");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Movie = movieManager.GetById(movieId);
                Comments = commentManager.GetAll(movieId);
                return RedirectToPage(new { id = movieId });
            }
        }

        public IActionResult OnPostToggleWatching(int movieId)
        {
            try
            {
                if (User.FindFirst("id") != null)
                {
                    UserId = int.Parse(User.FindFirst("id").Value);
                    IsInWatching = watchingManager.CheckFolder(movieId, UserId);
                    if (IsInWatching)
                    {
                        watchingManager.RemoveFrom(new Folderkeep(movieId, UserId));
                    }
                    else
                    {
                        watchingManager.AddTo(new Folderkeep(movieId, UserId));
                    }
                    IsInWatching = !IsInWatching;
                    // Re-fetch movie data and other necessary data
                    Movie = movieManager.GetById(movieId);
                    Comments = commentManager.GetAll(movieId);
                    return RedirectToPage(new { id = movieId });
                }
                else
                {
                    return RedirectToPage("/Account/Login");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Movie = movieManager.GetById(movieId);
                Comments = commentManager.GetAll(movieId);
                return RedirectToPage(new { id = movieId });
            }
        }
        public IActionResult OnPostToggleFinished(int movieId)
        {
            try
            {
                if (User.FindFirst("id") != null)
                {
                    UserId = int.Parse(User.FindFirst("id").Value);
                    IsInFinished = finishedManager.CheckFolder(movieId, UserId);
                    if (IsInFinished)
                    {
                        finishedManager.RemoveFrom(new Folderkeep(movieId, UserId));
                    }
                    else
                    {
                        finishedManager.AddTo(new Folderkeep(movieId, UserId));
                    }
                    IsInFinished = !IsInFinished;
                    // Re-fetch movie data and other necessary data
                    Movie = movieManager.GetById(movieId);
                    Comments = commentManager.GetAll(movieId);
                    return RedirectToPage(new { id = movieId });
                }
                else
                {
                    return RedirectToPage("/Account/Login");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Movie = movieManager.GetById(movieId);
                Comments = commentManager.GetAll(movieId);
                return RedirectToPage(new { id = movieId });
            }
        }

        //public IActionResult Rate(int movieId) { }
    }
}
