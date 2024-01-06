using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_Classes
{
    public class WatchLater
    {
        public int Id { get; }
        public int UserId { get; set; }

        public WatchLater(int id, int userId)
        {
            Id = id;
            UserId = userId;
        }

        public WatchLater()
        {
        }
    }
}
