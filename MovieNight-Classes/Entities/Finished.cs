using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_Classes
{
    public class Finished
    {
        public int Id { get; }
        public int UserId { get; set; }

        public Finished(int id, int userId)
        {
            Id = id;
            UserId = userId;
        }

        public Finished()
        {
        }
    }
}
