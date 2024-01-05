using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieNight_BusinessLogic.Services;
using MovieNight_Classes;
using MovieNight_DataAccess.Controllers;
using MovieNight_InterfacesLL.IServices;

namespace MovieNight.Pages
{
    public class MoviePageModel : PageModel
    {
        public Movie Movie { get; set; }
        private readonly IMovieManager movieManager;

        public MoviePageModel()
        {
            movieManager = new MovieManager(new MovieDALManager());
        }
        public void OnGet(int id)
        {
            Movie = movieManager.GetById(id);
        }
    }
}
