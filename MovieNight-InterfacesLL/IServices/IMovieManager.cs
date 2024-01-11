using MovieNight_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_InterfacesLL.IServices
{
    public interface IMovieManager
    {
        List<Movie> GetAll();
        Movie GetById(int id);
        List<Movie> GetBySearch(string search);
        void Create(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
        List<Movie> Get7();
        List<Movie> Search(string search);
    }
}
