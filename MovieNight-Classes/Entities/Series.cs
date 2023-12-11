using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_Classes
{
    
    public class Series : ObjectToWatch
    {
        public int Season {  get; set; }
        public int Episode { get; set; }

        public Series()
        {
        }

        public Series(int id, int season, int episode, string title, string description, string imageLink, string trailerLink, Category category, string country,
                        int rating, int year) : base(id, title, description, imageLink, trailerLink, category, country, rating, year)
        {
            Season = season;
            Episode = episode;
        }

    }
}
