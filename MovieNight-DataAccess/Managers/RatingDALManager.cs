using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.Build.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualBasic;
using MovieNight_Classes;
using MovieNight_InterfacesDAL.IManagers;

namespace MovieNight_DataAccess.Controllers
{
    public class RatingDALManager : Connection, IRatingDALManager
    {
        private readonly string tableName = "Rating";
        public RatingDALManager() 
        { 
        }

        /**
        * Query that gets all user's media
        */
        public Rating GetUserRate(int mediaId, int userId)
        {
            string query = $"SELECT * FROM {tableName} WHERE userId = @userId AND mediaId = @mediaId";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@mediaId", mediaId);
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                Rating rating = null;

                while (reader.Read())
                {
                    rating = new Rating((int)reader.GetValue(0), mediaId, (int)reader.GetValue(2), userId, (DateTime)reader.GetValue(4));
                }
                return rating;
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
            return new Rating();
        }

        public void InsertRate(Rating rating)
        {
            // Set up the query
            string query = $"INSERT INTO {tableName} " +
                           $"(id, mediaId, rate, userId, rateDate) " +
                           $"VALUES (@id, @mediaId, @rate, @userId, @rateDate)";

            // Open the connection
            connection.Open();
            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                command.Parameters.AddWithValue("@id", rating.Id);
                command.Parameters.AddWithValue("@mediaId", rating.MediaId);
                command.Parameters.AddWithValue("@rate", rating.Rate);;
                command.Parameters.AddWithValue("@userId", rating.UserId);
                command.Parameters.AddWithValue("@rateDate", rating.RateDate);

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

        public void DeleteRate(int id)
        {
            string query = $"DELETE FROM {tableName} WHERE id = @id";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            // Add the parameters
            command.Parameters.AddWithValue("@id", id);

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

        public bool CheckUserRating(int mediaId, int userId)
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

        public void UpdateRate(Rating rating)
        {
            // Set up the query
            string query = $"INSERT INTO {tableName} " +
                           $"(id, mediaId, rate, userId, rateDate) " +
                           $"VALUES (@id, @mediaId, @rate, @userId, @rateDate) " +
                           $"WHERE id = @id";

            // Open the connection
            connection.Open();
            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                command.Parameters.AddWithValue("@id", rating.Id);
                command.Parameters.AddWithValue("@mediaId", rating.MediaId);
                command.Parameters.AddWithValue("@rate", rating.Rate); ;
                command.Parameters.AddWithValue("@userId", rating.UserId);
                command.Parameters.AddWithValue("@rateDate", rating.RateDate);

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
    }
}
