using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_Classes;
using MovieNight_InterfacesDAL;
using MovieNight_InterfacesDAL.IManagers;

namespace MovieNight_DataAccess.Controllers
{
    public class ObjectToWatchDALManager : Connection, IObjectToWatchDALManager
    {

        private static readonly string tableName = "ObjectToWatch";
        private ICategoryDALManager categoryController;

        public ObjectToWatchDALManager()
        {
        }

        public int GetNextId()
        {
            string query = $"SELECT IDENT_CURRENT('{tableName}')";
            int id = 0;
            // Open the connection
            if(connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader.GetValue(0));  
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

            return id;
        }
        /**
         * Query that gets a specific object using id
         */
        public ObjectToWatch GetObjectById(int id)
        {
            string query = $"SELECT * FROM {tableName} WHERE id = @id";

            // Open the connection
            connection.Open();
            ObjectToWatch obj = null;
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                // Add the parameters
                command.Parameters.AddWithValue("@id", id);

                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Category category = categoryController.GetCategoryById((int)reader.GetValue(1), reader);
                    obj = new ObjectToWatch((int)reader.GetValue(0), (string)reader.GetValue(1), (string)reader.GetValue(2), (string)reader.GetValue(3),
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

            return obj;
        }


        /**
         * Query that gets all objects
         */
        public List<ObjectToWatch> GetAllObjects()
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
                List<ObjectToWatch> objects = new List<ObjectToWatch>();
                while (reader.Read())
                {
                    Category category = (Category)categoryController.GetCategoryById((int)reader.GetValue(1), reader);
                    objects.Add(new ObjectToWatch((int)reader.GetValue(0), (string)reader.GetValue(1), (string)reader.GetValue(2), (string)reader.GetValue(3),
                        (string)reader.GetValue(4), category, (string)reader.GetValue(6), (int)reader.GetValue(7), (int)reader.GetValue(8)));
                }
                reader.Close();
                return objects;
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

            return new List<ObjectToWatch>();
        }

        /**
         * Query that updates the object data
         */
        public void UpdateObject(ObjectToWatch newObject)
        {
            string query =
                $"UPDATE {tableName} SET " +
                $"title = @title, " +
                $"description = @description, " +
                $"imageLink = @imageLink, " +
                $"trailerLink = @trailerLink," +
                $"categoryId = @categoryId, " +
                $"country = @country, " +
                $"rating = @rating, " +
                $"year = @year " +
                $"WHERE Id = @id";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            command.Parameters.AddWithValue("@id", newObject.Id);
            command.Parameters.AddWithValue("@title", newObject.Title);
            command.Parameters.AddWithValue("@description", newObject.Description);
            command.Parameters.AddWithValue("@imageLink", newObject.ImageLink);
            command.Parameters.AddWithValue("@trailerLink", newObject.TrailerLink);
            command.Parameters.AddWithValue("@categoryId", newObject.Category.Id);
            command.Parameters.AddWithValue("@country", newObject.Country);
            command.Parameters.AddWithValue("@rating", newObject.Rating);
            command.Parameters.AddWithValue("@year", newObject.Year);

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

        /**
         * Query that deletes a specific object using id
        */
        public void DeleteObject(int Id)
        {
            // Set up the query
            string query = $"DELETE FROM {tableName} WHERE id = @Id";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            // Add the parameters
            command.Parameters.AddWithValue("@Id", Id);

            try
            {
                // Execute the query and get the data
                //using SqlDataReader reader = command.ExecuteReader();
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
        * Query that creates new objects in the database
        */
        public void CreateObject(ObjectToWatch newObject)
        {
            string query =
                $"INSERT INTO {tableName} (title, description, imageLink, trailerLink, categoryId, country, rating, year) " +
                $"VALUES (@title, @description, @imageLink, @trailerLink, @categoryId, @country, @rating, @year)";

            // Open the connection
            try
            {
                connection.Open();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            command.Parameters.AddWithValue("@title", newObject.Title);
            command.Parameters.AddWithValue("@description", newObject.Description);
            command.Parameters.AddWithValue("@imageLink", newObject.ImageLink);
            command.Parameters.AddWithValue("@trailerLink", newObject.TrailerLink);
            command.Parameters.AddWithValue("@categoryId", newObject.Category.Id);
            command.Parameters.AddWithValue("@country", newObject.Country);
            command.Parameters.AddWithValue("@rating", newObject.Rating);
            command.Parameters.AddWithValue("@year", newObject.Year);

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
    }
}
