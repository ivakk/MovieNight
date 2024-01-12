using MovieNight_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_InterfacesLL.IServices
{
    public interface IMovieAlgoManager
    {
        List<Movie> GetAll();
        Movie GetById(int id);
        List<Movie> Recommend(User user);
        List<Movie> SortDesc();
    }
}
