using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_Classes
{
    public class Watching
    {
        public int Id { get; }
        public int UserId { get; set; }

        public Watching(int id, int userId)
        {
            Id = id;
            UserId = userId;
        }

        public Watching()
        {
        }
    }
}
