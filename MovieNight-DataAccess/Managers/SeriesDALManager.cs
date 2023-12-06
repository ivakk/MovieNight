using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_DataAccess.Entities;

namespace MovieNight_DataAccess.Controllers
{
    public class SeriesDALManager : ObjectToWatchDALManager
    {

        private string tableName = "Series";
        private CategoryDALManager categoryDALManager = new CategoryDALManager();

        public SeriesDALManager()
        {
        }

        public Series GetSeriesById(int id)
        {
            string query = $"SELECT * FROM ObjectToWatch JOIN Series ON ObjectToWatch.id = Series.id JOIN Categories ON ObjectToWatch.categoryId = Categories.id";

            // Open the connection
            connection.Open();
            Series series = null;
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                // Add the parameters
                command.Parameters.AddWithValue("@id", id);

                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Category category = new Category((int)reader.GetValue(12), (string)reader.GetValue(13));
                    series = new Series((int)reader.GetValue(0), (int)reader.GetValue(10), (int)reader.GetValue(11), (string)reader.GetValue(1), (string)reader.GetValue(2), (string)reader.GetValue(3),
                        (string)reader.GetValue(4), category, (string)reader.GetValue(6), (int)reader.GetValue(7), (int)reader.GetValue(8));
                }
                reader.Close();
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }

            return series;
        }

        public List<Series> GetAllSeries()
        {
            string query = $"SELECT * FROM ObjectToWatch JOIN Series ON ObjectToWatch.id = Series.id JOIN Categories ON ObjectToWatch.categoryId = Categories.id";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                List<Series> series = new List<Series>();
                while (reader.Read())
                {
                    Category category = new Category((int)reader.GetValue(12), (string)reader.GetValue(13));
                    series.Add(new Series((int)reader.GetValue(0), (int)reader.GetValue(10), (int)reader.GetValue(11), (string)reader.GetValue(1), (string)reader.GetValue(2), (string)reader.GetValue(3),
                        (string)reader.GetValue(4), category, (string)reader.GetValue(6), (int)reader.GetValue(7), (int)reader.GetValue(8)));
                }
                reader.Close();
                return series;
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                Console.WriteLine(e.Message);
            }
            finally
            {
                // Close the connection
                connection.Close();
            }

            return new List<Series>();
        }

        public void UpdateSeries(Series newSeries)
        {
            base.UpdateObject(newSeries);

            string query =
                $"UPDATE {tableName} SET " +
                $"season = @season, " +
                $"episode = @episode, " +
                $"WHERE id = @id";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            command.Parameters.AddWithValue("@season", newSeries.Season);
            command.Parameters.AddWithValue("@episode", newSeries.Episode);

            try
            {
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                Debug.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteSeries(int Id)
        {

            base.DeleteObject(Id);

            // Set up the query
            string query = $"DELETE FROM {tableName} WHERE id = @id";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            // Add the parameters
            command.Parameters.AddWithValue("@id", Id);

            try
            {
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void CreateSeries(Series newSeries)
        {
            base.CreateObject(newSeries);
            string query =
                $"INSERT INTO {tableName} (id, season, episode) " +
                $"VALUES (@id, @season, @episode)";

            // Open the connection
            try
            {
                connection.Open();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            command.Parameters.AddWithValue("@id", GetNextId());
            command.Parameters.AddWithValue("@season", newSeries.Season);
            command.Parameters.AddWithValue("@episode", newSeries.Episode);

            try
            {

                // Execute the query and get the data
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                using SqlDataReader reader = command.ExecuteReader();
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                Debug.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
