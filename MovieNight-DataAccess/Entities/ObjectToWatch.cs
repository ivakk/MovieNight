using MovieNight_DataAccess.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_DataAccess.Entities
{
    
    public class ObjectToWatch
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public string TrailerLink { get; set; }
        public Category Category { get; set; }
        public string Country { get; set; }
        public int Rating { get; set; }
        public int Year { get; set; }


        public ObjectToWatch()
        {
        }

        public ObjectToWatch(int id, string title, string description, string imageLink, string trailerLink, Category category, string country, int rating, int year)
        {
            Id = id;
            Title = title;
            Description = description;
            ImageLink = imageLink;
            TrailerLink = trailerLink;
            Category = category;
            Country = country;
            Rating = rating;
            Year = year;
        }



        public string GetObjectString()
        {
            return Id.ToString() + Title + Country + ImageLink + TrailerLink + Category.Name + Rating + Year.ToString();
        }
    }
}
