using MovieNight_DataAccess.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_Classes;
using MovieNight_InterfacesDAL.IManagers;
using MovieNight_InterfacesLL.IServices;

namespace MovieNight_BusinessLogic.Services
{
    public class CommentManager : ICommentManager
    {
        ICommentDALManager controller;

        public CommentManager(ICommentDALManager controller)
        {
            this.controller = controller;
        }
        
        public List<Comments> GetAll(int mediaId)
        {
            return controller.GetAllComments(mediaId);
        }
        public Comments GetById(int id)
        {
            Comments comment = controller.GetCommentById(id);
            return comment;
        }
        public void PostComment(Comments comment)
        {
            controller.WriteComment(comment);
        }
        public void DelComment(int id)
        {
            controller.DeleteComment(id);
        }
        public string GetCommenter(int id)
        {
            return controller.GetCommentUser(id);
        }
    }
}
