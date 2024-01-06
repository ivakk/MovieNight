using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieNight_Classes
{
    public class Comments
    {
        public int Id { get; }
        public int UserId { get; set; }
        public int MediaId { get; set; }
        public DateTime CommentDate { get; set; }
        public string Information { get; set; }
        public string Username { get; set; }

        public Comments(int id, int userId, int mediaId, DateTime commentDate, string information)
        {
            Id = id;
            UserId = userId;
            MediaId = mediaId;
            CommentDate = commentDate;
            Information = information;
        }

        public Comments()
        {
        }
    }
}
