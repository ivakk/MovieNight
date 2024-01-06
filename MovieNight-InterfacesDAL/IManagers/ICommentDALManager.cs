using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_Classes;

namespace MovieNight_InterfacesDAL.IManagers
{
    public interface ICommentDALManager
    {
        Comments GetCommentById(int id);
        List<Comments> GetAllComments(int mediaId);
        void WriteComment(Comments comment);
        void DeleteComment(int id);
        string GetCommentUser(int id);
    }
}
