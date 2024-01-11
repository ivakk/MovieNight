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
    public class SeriesPageModel : PageModel
    {
        public Series Series { get; set; }
        public List<Comments> Comments { get; set; }
        [BindProperty]
        public string CommentLeft { get; set; }
        public User LoggedInUser { get; set; }
        public int UserId { get; set; }
        public string WatchLaterButtonText => IsInWatchLater ? "Remove from Watch Later" : "Add to Watch Later";
        public bool IsInWatchLater { get; private set; }
        public string WatchingButtonText => IsInWatching ? "Remove from Currently Watching" : "Add to Currently Watching";
        public bool IsInWatching { get; private set; }
        public string FinishedButtonText => IsInFinished ? "Remove from Finished" : "Add to Finished";
        public bool IsInFinished { get; private set; }
        public bool IsRated { get; private set; }
        public int SeriesRates { get; set; }
        public int SeriesRating { get; set; }


        private readonly ISeriesManager seriesManager;
        private readonly ICommentManager commentManager;
        private readonly IUserManager userManager;
        private readonly IWatchLaterManager watchLaterManager;
        private readonly IWatchingManager watchingManager;
        private readonly IFinishedManager finishedManager;
        private readonly IRatingManager ratingManager;

        public SeriesPageModel()
        {
            seriesManager = new SeriesManager(new SeriesDALManager());
            commentManager = new CommentManager(new CommentDALManager());
            userManager = new UserManager(new UserDALManager());
            watchLaterManager = new WatchLaterManager(new WatchLaterDALManager());
            watchingManager = new WatchingManager(new WatchingDALManager());
            finishedManager = new FinishedManager(new FinishedDALManager());
            ratingManager = new RatingManager(new RatingDALManager());
        }
        public void OnGet(int id)
        {
            Series = seriesManager.GetById(id);
            Comments = commentManager.GetAll(Series.Id);
            if (User.FindFirst("id") != null)
            {
                LoggedInUser = userManager.GetUserById(int.Parse(User.FindFirst("id").Value));
                UserId = LoggedInUser.Id;
                IsInWatchLater = watchLaterManager.CheckFolder(Series.Id, UserId);
                IsInWatching = watchingManager.CheckFolder(Series.Id, UserId);
                IsInFinished = finishedManager.CheckFolder(Series.Id, UserId);
                IsRated = ratingManager.CheckRate(Series.Id, UserId);
                SeriesRates = ratingManager.GetCount(Series.Id);
                SeriesRating = ratingManager.GetAvgRate(Series.Id);

                if (IsRated)
                {
                    Rating currentRating = ratingManager.GetRate(Series.Id, UserId);
                    ViewData["UserRating"] = currentRating.Rate;
                }
                if (IsBanned(LoggedInUser))
                {
                    RedirectToPage("/Account/Logout");
                }
            }
            foreach (var comment in Comments)
            {
                comment.Username = userManager.GetUserById(comment.UserId).Username;
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

                    // Re-fetch series data and other necessary data
                    Series = seriesManager.GetById(id);
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

                    // Re-fetch series data and other necessary data
                    Series = seriesManager.GetById(id);
                    Comments = commentManager.GetAll(id);

                    return RedirectToPage(new { id = id });
                }

                // If the user is not authorized to delete, handle accordingly
                // Redirect to the same page with an error message or a status
                TempData["ErrorMessage"] = "You are not authorized to delete this comment.";

                Series = seriesManager.GetById(id);
                Comments = commentManager.GetAll(id);

                return RedirectToPage(new { id = id });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Series = seriesManager.GetById(id);
                Comments = commentManager.GetAll(id);
                return RedirectToPage(new { id = id });
            }
        }
        public IActionResult OnPostToggleWatchLater(int seriesId)
        {
            try
            {

                if (User.FindFirst("id") != null)
                {
                    UserId = int.Parse(User.FindFirst("id").Value);
                    IsInWatchLater = watchLaterManager.CheckFolder(seriesId, UserId);
                    if (IsInWatchLater)
                    {
                        watchLaterManager.RemoveFrom(new Folderkeep(seriesId, UserId, 1, DateTime.Now));
                    }
                    else
                    {
                        watchLaterManager.AddTo(new Folderkeep(seriesId, UserId, 1, DateTime.Now));
                    }
                    IsInWatchLater = !IsInWatchLater;
                    // Re-fetch series data and other necessary data
                    Series = seriesManager.GetById(seriesId);
                    Comments = commentManager.GetAll(seriesId);
                    return RedirectToPage(new { id = seriesId });
                }
                else
                {
                    return RedirectToPage("/Account/Login");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Series = seriesManager.GetById(seriesId);
                Comments = commentManager.GetAll(seriesId);
                return RedirectToPage(new { id = seriesId });
            }
        }

        public IActionResult OnPostToggleWatching(int seriesId)
        {
            try
            {
                if (User.FindFirst("id") != null)
                {
                    UserId = int.Parse(User.FindFirst("id").Value);
                    IsInWatching = watchingManager.CheckFolder(seriesId, UserId);
                    if (IsInWatching)
                    {
                        watchingManager.RemoveFrom(new Folderkeep(seriesId, UserId, 1, DateTime.Now));
                    }
                    else
                    {
                        watchingManager.AddTo(new Folderkeep(seriesId, UserId, 1, DateTime.Now));
                    }
                    IsInWatching = !IsInWatching;
                    // Re-fetch series data and other necessary data
                    Series = seriesManager.GetById(seriesId);
                    Comments = commentManager.GetAll(seriesId);
                    return RedirectToPage(new { id = seriesId });
                }
                else
                {
                    return RedirectToPage("/Account/Login");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Series = seriesManager.GetById(seriesId);
                Comments = commentManager.GetAll(seriesId);
                return RedirectToPage(new { id = seriesId });
            }
        }
        public IActionResult OnPostToggleFinished(int seriesId)
        {
            try
            {
                if (User.FindFirst("id") != null)
                {
                    UserId = int.Parse(User.FindFirst("id").Value);
                    IsInFinished = finishedManager.CheckFolder(seriesId, UserId);
                    if (IsInFinished)
                    {
                        finishedManager.RemoveFrom(new Folderkeep(seriesId, UserId, 1, DateTime.Now));
                    }
                    else
                    {
                        finishedManager.AddTo(new Folderkeep(seriesId, UserId, 1, DateTime.Now));
                    }
                    IsInFinished = !IsInFinished;
                    // Re-fetch series data and other necessary data
                    Series = seriesManager.GetById(seriesId);
                    Comments = commentManager.GetAll(seriesId);
                    return RedirectToPage(new { id = seriesId });
                }
                else
                {
                    return RedirectToPage("/Account/Login");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Series = seriesManager.GetById(seriesId);
                Comments = commentManager.GetAll(seriesId);
                return RedirectToPage(new { id = seriesId });
            }
        }

        public IActionResult OnPostRate(int seriesId, int rating)
        {
            try
            {
                if (User.FindFirst("id") != null)
                {
                    UserId = int.Parse(User.FindFirst("id").Value);
                    IsRated = ratingManager.CheckRate(seriesId, UserId);
                    if (IsRated)
                    {
                        Rating curRate = ratingManager.GetRate(seriesId, UserId);
                        ratingManager.ChangeRate(new Rating(curRate.Id, seriesId, UserId, rating, DateTime.Now));
                    }
                    else
                    {
                        ratingManager.PostRate(new Rating(0, seriesId, UserId, rating, DateTime.Now));
                    }
                    // Re-fetch series data and other necessary data
                    Series = seriesManager.GetById(seriesId);
                    Comments = commentManager.GetAll(seriesId);
                    return RedirectToPage(new { id = seriesId });
                }
                else
                {
                    return RedirectToPage("/Account/Login");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                Series = seriesManager.GetById(seriesId);
                Comments = commentManager.GetAll(seriesId);
                return RedirectToPage(new { id = seriesId });
            }
        }

        public IActionResult OnPostDeleteRate(int seriesId)
        {
            if (User.FindFirst("id") != null)
            {
                UserId = int.Parse(User.FindFirst("id").Value);
                Rating currentRating = ratingManager.GetRate(seriesId, UserId);
                // Delete the user's rating from the database
                ratingManager.RemoveRate(currentRating.Id);
            }
            return RedirectToPage(new { id = seriesId });
        }
    }
}
