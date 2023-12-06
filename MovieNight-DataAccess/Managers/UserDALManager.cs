using Amazon.Auth.AccessControlPolicy;
using Microsoft.TeamFoundation.Build.WebApi;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_DataAccess.Entities;
using System.Data;

namespace MovieNight_DataAccess.Controllers
{
    public class UserDALManager : Connection {

        private readonly string tableName = "Users";
        public UserDALManager() { }

        /**
         * Query that gets a specific user using id
         */
        public User GetUserById(int id)
        {
            string query = $"SELECT * FROM {tableName} WHERE id = @id";

            // Open the connection
            connection.Open();

            SqlCommand command = new SqlCommand(query, Connection.connection);

            try {
                // Add the parameters
                command.Parameters.AddWithValue("@id", id);

                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    return new User((int)reader.GetValue(0),(string)reader.GetValue(1),
                        (string)reader.GetValue(2), (DateTime)reader.GetValue(3), 
                        (string)reader.GetValue(4), (string)reader.GetValue(5), 
                        (string)reader.GetValue(6), (string)reader.GetValue(7), 
                        (string)reader.GetValue(8));
                }
            } catch (SqlException e) {
                // Handle any errors that may have occurred.
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return new User();
        }

        /**
        * Query that gets a specific user by typing in their username
        */
        public User GetUserByUsername(string username)
        {
            string query = $"SELECT * FROM {tableName} WHERE username = @username";

            // Open the connection
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            
            User user = null;
            try
            {
                // Add the parameters
                command.Parameters.AddWithValue("@username", username);

                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user = new User((int)reader.GetValue(0), (string)reader.GetValue(1),
                        (string)reader.GetValue(2), (DateTime)reader.GetValue(3),
                        (string)reader.GetValue(4), (string)reader.GetValue(5),
                        (string)reader.GetValue(6), (string)reader.GetValue(7),
                        (string)reader.GetValue(8));
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
            return user;
        }

        /**
         * Query that gets all users
         */
        public List<User> GetAll() 
        {
            string query = $"SELECT * FROM {tableName}";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try {
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                List<User> user = new List<User>();

                while (reader.Read()) {
                    user.Add(new User((int)reader.GetValue(0), (string)reader.GetValue(1),
                        (string)reader.GetValue(2), (DateTime)reader.GetValue(3),
                        (string)reader.GetValue(4), (string)reader.GetValue(5),
                        (string)reader.GetValue(6), (string)reader.GetValue(7),
                        (string)reader.GetValue(8)));
                }
                return user;
            } catch (SqlException e) {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return new List<User>();
        }

        public bool UpdateUser(User newUser)
        {
            string query =
                $"UPDATE {tableName} " +
                $"SET firstName = @firstName, lastName = @lastName, email = @email " +
                $"birthday = @birthdate, passwordHash = @passwordHash, passwordSalt = @passwordSalt, role = @role" +
                $"WHERE userId = @id";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                // Add the parameters
                command.Parameters.AddWithValue("@id", newUser.Id);
                command.Parameters.AddWithValue("@username", newUser.Username);
                command.Parameters.AddWithValue("@firstName", newUser.FirstName);
                command.Parameters.AddWithValue("@lastName", newUser.LastName);
                command.Parameters.AddWithValue("@email", newUser.Email);
                command.Parameters.AddWithValue("@birthdate", newUser.Birthday);
                command.Parameters.AddWithValue("@passwordHash", newUser.PasswordHash);
                command.Parameters.AddWithValue("@passwordSalt", newUser.PasswordSalt);
                command.Parameters.AddWithValue("@role", newUser.Role);
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();

                connection.Close();
                return true;
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                Console.WriteLine(e.Message);
                connection.Close();
                return false;
            }
        }

        /**
         * Query that deletes a specific user using id
         */
        public void DeleteUser(int id) {
            // Set up the query
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

        /**
         * Query that creates new user in the database
         */
        public bool InsertUser(User newUser)
        {
            // Set up the query
            string query = $"INSERT INTO {tableName} " +
                           $"(username, firstName, lastName, email, birthday, passwordHash, passwordSalt, role) " +
                           $"VALUES (@username, @firstName, @lastName, @email," +
                           $"@birthday, @passwordHash, @passwordSalt, @role)";

            // Open the connection
            connection.Open();
            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                command.Parameters.AddWithValue("@username", newUser.Username);
                command.Parameters.AddWithValue("@firstName", newUser.FirstName);
                command.Parameters.AddWithValue("@lastName", newUser.LastName);
                command.Parameters.AddWithValue("@email", newUser.Email);
                command.Parameters.AddWithValue("@role", newUser.Role);
                command.Parameters.AddWithValue("@birthday", newUser.Birthday);
                command.Parameters.AddWithValue("@passwordHash", newUser.PasswordHash);
                command.Parameters.AddWithValue("@passwordSalt", newUser.PasswordSalt);

                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();

                connection.Close();
                return true;
                ;
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
                connection.Close();
                return false;
            }

        }
 
        public bool IsPasswordCorrect(string username, string password)
        {
            /// <summary>
            /// This function returns true, if the password is correct for the given username.
            /// </summary>

            // Get user by username property, 
            User user = GetUserByUsername(username);

            // If there is no user with the given username address, return false.
            if (user == null)
            {
                // No user found with given username.
                return false;
            }

            PasswordHashing passwordHashing = new PasswordHashing();
            string hashedPasswordToCheck = passwordHashing.GenerateSHA256Hash(password, user.PasswordSalt);

            if (user.PasswordHash == hashedPasswordToCheck)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
