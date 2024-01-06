using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_Classes
{
    public class Rating
    {
        public int Id { get; }
        public int MediaId { get; set; }
        public int UserId { get; set; }
        public int Rate { get; set; }
        public DateTime RateDate { get; set; }
        public string Username { get; set; }

        public Rating(int id, int mediaId, int userId, int rate, DateTime rateDate)
        {
            Id = id;
            MediaId = mediaId;
            UserId = userId;
            Rate = rate;
            RateDate = rateDate;
        }

        public Rating()
        {
        }
    }
}
