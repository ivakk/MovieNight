using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualBasic;
using MovieNight_Classes;
using MovieNight_InterfacesDAL.IManagers;

namespace MovieNight_DataAccess.Controllers
{
    public class CommentDALManager : Connection, ICommentDALManager
    {

        public CommentDALManager()
        {
        }


        /**
        * Query that gets a specific comment using id
        */
        public Comments GetCommentById(int id)
        {
            string query = $"SELECT * FROM Comment WHERE id = @commentId";

            // Open the connection
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            Comments comment = null;
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                // Add the parameters
                command.Parameters.AddWithValue("@commentId", id);
                using SqlDataReader reader = command.ExecuteReader();
                // Execute the query and get the data
                while (reader.Read())
                {
                    comment = new Comments((int)reader.GetValue(0), (int)reader.GetValue(1), (int)reader.GetValue(2), (DateTime)reader.GetValue(4), (string)reader.GetValue(3));
                }
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return comment;
        }

        /**
        * Query that gets all comments
        */
        public List<Comments> GetAllComments(int mediaId)
        {
            string query = $"SELECT Comment.id, userId, mediaId, comDate, information FROM Comment " +
                $"JOIN ObjectToWatch ON ObjectToWatch.id = Comment.mediaId " +
                $"WHERE Comment.mediaId = @id";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                command.Parameters.AddWithValue("@id", mediaId);
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                List<Comments> comments = new List<Comments>();

                while (reader.Read())
                {
                    comments.Add(new Comments((int)reader.GetValue(0), (int)reader.GetValue(1), (int)reader.GetValue(2), (DateTime)reader.GetValue(3), (string)reader.GetValue(4)));
                }
                return comments;
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return new List<Comments>();
        }

        public void WriteComment(Comments comment)
        {
            // Set up the query
            string query = $"INSERT INTO Comment " +
                           $"(userId, mediaId, information, comDate) " +
                           $"VALUES (@userId, @mediaId, @information, @comDate)";

            // Open the connection
            connection.Open();
            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                command.Parameters.AddWithValue("@userId", comment.UserId);
                command.Parameters.AddWithValue("@mediaId", comment.MediaId);
                command.Parameters.AddWithValue("@information", comment.Information);
                command.Parameters.AddWithValue("@comDate", comment.CommentDate);

                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();

                connection.Close();
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
                connection.Close();
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteComment(int id)
        {
            string query = $"DELETE FROM Comment WHERE id = @commentId";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            // Add the parameters
            command.Parameters.AddWithValue("@commentId", id);

            try
            {
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public string GetCommentUser(int id)
        {
            string query = $"SELECT Users.username FROM Comment JOIN Users ON Users.id = Comment.userId WHERE Comment.id = @id";

            connection.Open();
            string commenter = null;

            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                command.Parameters.AddWithValue("@id", id);

                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    commenter = new string(reader.GetString(0));
                }
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
                connection.Close();
            }
            finally
            {
                connection.Close();
            }
            return commenter;
        }
    }
}
