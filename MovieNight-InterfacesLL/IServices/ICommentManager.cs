using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_Classes;

namespace MovieNight_InterfacesLL.IServices
{
    public interface ICommentManager
    {
        List<Comments> GetAll(int mediaId);
        Comments GetById(int id);
        void PostComment(Comments comment);
        void DelComment(int id);
        string GetCommenter(int id);
    }
}
