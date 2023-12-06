using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_DataAccess.Entities;

namespace MovieNight_DataAccess.Controllers
{
    public class CategoryDALManager : Connection
    {

        private readonly string tableName = "Categories";

        public CategoryDALManager()
        {
        }


        /**
        * Query that gets a specific category using id
        */
        public Category GetCategoryById(int id, SqlDataReader reader)
        {
            string query = $"SELECT * FROM {tableName} WHERE id = @categoryId";

            // Open the connection
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            Category cat = null;
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                // Add the parameters
                command.Parameters.AddWithValue("@categoryId", id);
                // Execute the query and get the data
                while (reader.Read())
                {
                    cat = new Category((int)reader.GetValue(0), (string)reader.GetValue(1));
                }
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                Console.WriteLine(e.Message);
            }
            finally
            {
            }
            return cat;
        }

        /**
        * Query that gets all categories
        */
        public List<Category> GetAllCategories()
        {
            string query = $"SELECT * FROM {tableName}";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                List<Category> categories = new List<Category>();

                while (reader.Read())
                {
                    categories.Add(new Category((int)reader.GetValue(0), (string)reader.GetValue(1)));
                }
                return categories;
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
            return new List<Category>();
        }

        /**
        * Query that updates the category data
        */
        public void UpdateCategory(Category newCategory)
        {
            string query =
                $"UPDATE {tableName} " +
                $"SET name = @name " +
                $"WHERE categoryId = @categoryId";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                // Add the parameters
                command.Parameters.AddWithValue("@categoryId", newCategory.Id);
                command.Parameters.AddWithValue("@name", newCategory.Name);

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

        /**
        * Query that deletes a specific category using id
        */
        public void DeleteCategory(int id)
        {
            // Set up the query
            string query = $"DELETE FROM {tableName} WHERE categoryId = @categoryId";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            // Add the parameters
            command.Parameters.AddWithValue("@categoryId", id);

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

        /**
        * Query that creates new category in the database
        */
        public void InsertCategory(Category newCategory)
        {
            // Set up the query
            string query = $"INSERT INTO {tableName} (name)" +
                           $"VALUES (@name)";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            // Add the parameters
            command.Parameters.AddWithValue("@name", newCategory.Name);

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
    }
}
