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
    public class WatchingDALManager : Connection, IWatchingDALManager
    {
        private readonly string tableName = "Watching";
        public WatchingDALManager() 
        { 
        }

        /**
        * Query that gets all user's media
        */
        public List<Folderkeep> GetUserFolders(int userId)
        {
            string query = $"SELECT * FROM {tableName} WHERE userId = @userId ORDER BY time DESC";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                command.Parameters.AddWithValue("@userId", userId);
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                List<Folderkeep> folders = new List<Folderkeep>();

                while (reader.Read())
                {
                    folders.Add(new Folderkeep((int)reader.GetValue(1), (int)reader.GetValue(0), (int)reader.GetValue(2), (DateTime)reader.GetValue(3)));
                }
                return folders;
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
            return new List<Folderkeep>();
        }

        public void AddToFolders(Folderkeep folders)
        {
            // Set up the query
            string query = $"INSERT INTO {tableName} " +
                           $"(mediaId, userId, type, time) " +
                           $"VALUES (@mediaId, @userId, @type, @time)";

            // Open the connection
            connection.Open();
            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                command.Parameters.AddWithValue("@mediaId", folders.MediaId);
                command.Parameters.AddWithValue("@userId", folders.UserId);
                command.Parameters.AddWithValue("@type", folders.Type);
                command.Parameters.AddWithValue("@time", folders.Time);

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

        public void RemoveFromFolders(Folderkeep folders)
        {
            string query = $"DELETE FROM {tableName} WHERE mediaId = @mediaId AND userId = @userId";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            // Add the parameters
            command.Parameters.AddWithValue("@mediaId", folders.MediaId);
            command.Parameters.AddWithValue("@userId", folders.UserId);

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

        public bool CheckUserFolder(int mediaId, int userId)
        {
            string query = $"SELECT * FROM {tableName} WHERE userId = @userId AND mediaId = @mediaId";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                command.Parameters.AddWithValue("@mediaId", mediaId);
                command.Parameters.AddWithValue("@userId", userId);
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return true;
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
            return false;
        }
    }
}
