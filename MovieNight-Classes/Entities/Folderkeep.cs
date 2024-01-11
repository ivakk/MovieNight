using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_Classes
{
    public class Folderkeep
    {
        public int MediaId { get; set; }
        public int UserId { get; set; }
        public int Type { get; set; }
        public DateTime Time { get; set; }

        public Folderkeep(int mediaId, int userId, int type, DateTime time)
        {
            MediaId = mediaId;
            UserId = userId;
            Type = type;
            Time = time;
        }

        public Folderkeep()
        {
        }
    }
}
