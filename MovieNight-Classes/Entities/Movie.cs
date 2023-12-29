using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_Classes
{
    
    public class Movie : ObjectToWatch
    {
        public int Length{ get; set; }

        public Movie()
        {
        }

        public Movie(int id, int length, string title, string description, string imageLink, string trailerLink, Category category, string country,
                        int rating, int year) : base(id, title, description, imageLink, trailerLink, category, country, rating, year)
        {
            Length = length;
        }

    }
}
