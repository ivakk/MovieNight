using Amazon.Auth.AccessControlPolicy;
using Microsoft.TeamFoundation.Build.WebApi;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight_Classes;
using System.Data;
using MovieNight_InterfacesDAL.IManagers;
using System.Diagnostics;

namespace MovieNight_DataAccess.Controllers
{
    public class UserDALManager : Connection, IUserDALManager 
    {
        private readonly string tableName = "Users";
        public UserDALManager() 
        {
        }

        /**
         * Query that gets a specific user using id
         */
        public User GetUserById(int id)
        {
            string query = $"SELECT * FROM {tableName} WHERE id = @id";
            User user = null;

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
                    user = new User((int)reader.GetValue(0),(string)reader.GetValue(1),
                        (string)reader.GetValue(2), (DateTime)reader.GetValue(3), 
                        (string)reader.GetValue(4), (string)reader.GetValue(5), 
                        (string)reader.GetValue(6), (string)reader.GetValue(7), 
                        (string)reader.GetValue(8));
                }
            } catch (SqlException e) {
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
                reader.Close();
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
                $"SET firstName = @firstName, lastName = @lastName, email = @email, " +
                $"birthday = @birthdate, passwordHash = @passwordHash, passwordSalt = @passwordSalt, role = @role " +
                $"WHERE id = @id";

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
                System.Diagnostics.Debug.WriteLine(e.Message);
                connection.Close();
                return false;
            }
            finally
            {
                connection.Close();
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
            }
            catch (SqlException e)
            {
                // Handle any errors that may have occurred.
                System.Diagnostics.Debug.WriteLine(e.Message);
                connection.Close();
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public void BanUser(User banUser, string reason)
        {
            string query = $"INSERT INTO Banned " +
                           $"(reason, userId) " +
                           $"VALUES (@reason, @userId)";

            connection.Open();

            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                command.Parameters.AddWithValue("@userId", banUser.Id);
                command.Parameters.AddWithValue("@reason", reason);

                using SqlDataReader reader = command.ExecuteReader();
            }
            catch(SqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                connection.Close();
            }
            finally
            {
                connection.Close();
            }
        }

        public void UnbanUser(User bannedUser)
        {
            // Set up the query
            string query = $"DELETE FROM Banned WHERE userId = @userId";

            // Open the connection
            connection.Open();

            // Creating Command string to combine the query and the connection String
            SqlCommand command = new SqlCommand(query, Connection.connection);

            // Add the parameters
            command.Parameters.AddWithValue("@userId", bannedUser.Id);

            try
            {
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                reader.Close();
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

        public bool IsUserBanned(User bannedUser)
        {
            string query = $"SELECT reason, userId FROM Banned JOIN Users ON Banned.userId = Users.id WHERE Users.id = @id";

            // Open the connection
            connection.Open();

            SqlCommand command = new SqlCommand(query, Connection.connection);

            try
            {
                // Add the parameters
                command.Parameters.AddWithValue("@id", bannedUser.Id);

                
                // Execute the query and get the data
                using SqlDataReader reader = command.ExecuteReader();
                while (!reader.Read())
                {
                    return false;
                }
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
            return true;
        }

        public bool ExistingUsername(string username)
        {
            string query = $"SELECT * FROM {tableName} WHERE username = @username";

            // Open the connection
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                // Add the parameters
                command.Parameters.AddWithValue("@username", username);

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
        public bool ExistingEmail(string email)
        {
            string query = $"SELECT * FROM {tableName} WHERE email = @email";

            // Open the connection
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                // Add the parameters
                command.Parameters.AddWithValue("@email", email);

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
