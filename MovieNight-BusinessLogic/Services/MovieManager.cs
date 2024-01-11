using MovieNight_DataAccess.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_Classes;
using MovieNight_InterfacesLL.IServices;
using MovieNight_InterfacesDAL.IManagers;

namespace MovieNight_BusinessLogic.Services
{
    public class MovieManager : IMovieManager
    {
        IMovieDALManager manager;
        public MovieManager(IMovieDALManager manager) 
        {
            this.manager = manager;
        }
        public List<Movie> GetAll()
        {
            return (List<Movie>)manager.GetAllMovies();
        }
        public Movie GetById(int id)
        {
            return (Movie)manager.GetMovieById(id);
        }

        public List<Movie> GetBySearch(string search)
        {
            List<Movie> result = new List<Movie>();
            foreach (Movie movies in GetAll())
            {
                if (movies.GetObjectString().Contains(search))
                {
                    result.Add(movies);
                }
            }
            return result;
        }
        public void Create(Movie movie)
        {
            manager.CreateMovies(movie);
        }
        public void Update(Movie movie)
        {
            manager.UpdateMovies(movie);
        }
        public void Delete(int id)
        {
            manager.DeleteMovies(id);
        }
        public List<Movie> Get7()
        {
            return (List<Movie>)manager.Get7Movies();
        }
        public List<Movie> Search(string search)
        {
            return (List<Movie>)manager.GetSearch(search);
        }
    }
}
