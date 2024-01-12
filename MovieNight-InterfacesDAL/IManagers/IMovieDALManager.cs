using MovieNight_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_InterfacesDAL.IManagers
{
    public interface IMovieDALManager
    {
        Movie GetMovieById(int id);
        List<Movie> GetAllMovies();
        void UpdateMovies(Movie newMovie);
        void DeleteMovies(int Id);
        void CreateMovies(Movie newMovie);
        List<Movie> Get7Movies();
        List<Movie> GetSearch(string search);
        List<Movie> SortRateDesc();
        List<Movie> SortRateAsc();
    }
}
