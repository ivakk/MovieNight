using MovieNight_Classes;
using MovieNight_InterfacesDAL.IManagers;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MovieNight_DataAccess.Controllers
{
    public class MovieDALManager : ObjectToWatchDALManager, IMovieDALManager
    {

        private string tableName = "Movies";

        public MovieDALManager()
        {
        }

        public Movie GetMovieById(int id)
        {
            string query = $"SELECT * FROM ObjectToWatch JOIN Movies ON ObjectToWatch.id = Movies.id " +
                $"JOIN Categories ON ObjectToWatch.categoryId = Categories.id " +
                $"WHERE ObjectToWatch.id = @id";

            // Open the connection
            connection.Open();
            Movie movie = null;
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                if(connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                // Add the parameters
                command.Parameters.AddWithValue("@id", id);

                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Category category = new Category((int)reader.GetValue(12), (string)reader.GetValue(13));
                    movie = new Movie((int)reader.GetValue(0), (int)reader.GetValue(10), (string)reader.GetValue(11), (string)reader.GetValue(1), (string)reader.GetValue(2), (string)reader.GetValue(3),
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

            return movie;
        }

        public List<Movie> GetAllMovies()
        {
            string query = $"SELECT * FROM ObjectToWatch JOIN Movies ON ObjectToWatch.id = Movies.id JOIN Categories ON ObjectToWatch.categoryId = Categories.id";
            

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                List<Movie> movie = new List<Movie>();
                while (reader.Read())
                {
                    Category category = new Category((int)reader.GetValue(12), (string)reader.GetValue(13));
                    movie.Add(new Movie((int)reader.GetValue(0), (int)reader.GetValue(10), (string)reader.GetValue(11), (string)reader.GetValue(1), (string)reader.GetValue(2), (string)reader.GetValue(3),
                        (string)reader.GetValue(4), category, (string)reader.GetValue(6), (int)reader.GetValue(7), (int)reader.GetValue(8)));
                }
                reader.Close();
                return movie;
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                // Close the connection
                connection.Close();
            }

            return new List<Movie>();
        }

        public void UpdateMovies(Movie newMovie)
        {
            base.UpdateObject(newMovie);

            string query =
                $"UPDATE {tableName} SET " +
                $"length = @length, " +
                $"director = @director " +
                $"WHERE id = @id";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            command.Parameters.AddWithValue("@id", newMovie.Id);
            command.Parameters.AddWithValue("@length", newMovie.Length);
            command.Parameters.AddWithValue("@director", newMovie.Director);
            Debug.WriteLine(newMovie.Length);
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

        public void DeleteMovies(int Id)
        {

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
                reader.Close();
                base.DeleteObject(Id);
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

        public void CreateMovies(Movie newMovie)
        {
            base.CreateObject(newMovie);
            string query =
                $"INSERT INTO {tableName} (id, length, director) " +
                $"VALUES (@id, @length, @director)";

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
            command.Parameters.AddWithValue("@length", newMovie.Length);
            command.Parameters.AddWithValue("@director", newMovie.Director);
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

        public List<Movie> Get7Movies()
        {
            string query = $"SELECT TOP 8 * FROM ObjectToWatch " +
                $"JOIN Movies ON ObjectToWatch.id = Movies.id JOIN Categories ON ObjectToWatch.categoryId = Categories.id " +
                $"ORDER BY Movies.id DESC";


            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                List<Movie> movie = new List<Movie>();
                while (reader.Read())
                {
                    Category category = new Category((int)reader.GetValue(12), (string)reader.GetValue(13));
                    movie.Add(new Movie((int)reader.GetValue(0), (int)reader.GetValue(10), (string)reader.GetValue(11), (string)reader.GetValue(1), (string)reader.GetValue(2), (string)reader.GetValue(3),
                        (string)reader.GetValue(4), category, (string)reader.GetValue(6), (int)reader.GetValue(7), (int)reader.GetValue(8)));
                }
                reader.Close();
                return movie;
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                // Close the connection
                connection.Close();
            }

            return new List<Movie>();
        }

        public List<Movie> GetSearch(string search)
        {
            string query = $"SELECT * " +
                $"FROM ObjectToWatch JOIN Movies on ObjectToWatch.id = Movies.id " +
                $"JOIN Categories ON ObjectToWatch.categoryId = Categories.id " +
                $"WHERE ObjectToWatch.title LIKE @search";


            // Open the connection
            connection.Open();
            
            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);
            command.Parameters.AddWithValue("@search", "%" + search + "%");

            try
            {
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                List<Movie> movie = new List<Movie>();
                while (reader.Read())
                {
                    Category category = new Category((int)reader.GetValue(12), (string)reader.GetValue(13));
                    movie.Add(new Movie((int)reader.GetValue(0), (int)reader.GetValue(10), (string)reader.GetValue(11), (string)reader.GetValue(1), (string)reader.GetValue(2), (string)reader.GetValue(3),
                        (string)reader.GetValue(4), category, (string)reader.GetValue(6), (int)reader.GetValue(7), (int)reader.GetValue(8)));
                }
                reader.Close();
                return movie;
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                // Close the connection
                connection.Close();
            }

            return new List<Movie>();
        }
    }
}
