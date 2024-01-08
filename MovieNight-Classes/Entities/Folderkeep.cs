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

        public Folderkeep(int mediaId, int userId)
        {
            MediaId = mediaId;
            UserId = userId;
        }

        public Folderkeep()
        {
        }
    }
}
