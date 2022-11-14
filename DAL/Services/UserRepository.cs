using EasySport_DAL.Interfaces;
using EasySport_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_DAL.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EasySportDB;Integrated Security=True;";
        public void Create(UserEntities user)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"INSERT INTO [Users] ([Pseudo], [Email], [Password]) VALUES (@Pseudo, @Email, @Password)";
            cmd.Parameters.AddWithValue("Pseudo", user.Pseudo);
            cmd.Parameters.AddWithValue("Email", user.Email);
            cmd.Parameters.AddWithValue("Password", user.Password);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public IEnumerable<UserEntities> GetAll()
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM [Users]";
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return new UserEntities
                {
                    Id = (Guid)reader["Id"],
                    Pseudo = (string)reader["Pseudo"],
                    Email = (string)reader["Email"],
                    Role = (int)reader["Role"],
                };
            }
            sqlConnection.Close();
        }

        public void Delete(Guid Id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM [Users] WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("Id", Id);

                    cmd.ExecuteNonQuery();

                }

            }
        }

        public void Update(UserEntities user)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"UPDATE [Users] SET [Pseudo] = @Pseudo, [Email] = @Email, [Password] = @Password, [Role] = @Role WHERE Id = @Id";
            cmd.Parameters.AddWithValue("Id", user.Id);
            cmd.Parameters.AddWithValue("Pseudo", user.Pseudo);
            cmd.Parameters.AddWithValue("Email", user.Email);
            cmd.Parameters.AddWithValue("Password", user.Password);
            cmd.Parameters.AddWithValue("Role", user.Role);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public UserEntities GetById(Guid Id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [Users] WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("Id", Id);

                    using SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new UserEntities
                        {
                            
                            Pseudo = (string)reader["Pseudo"],
                            Email = (string)reader["Email"],
                            Password = (string)reader["Password"],
                        };
                    }
                    else
                    {
                        
                        throw new Exception("User not found");
                    }
                    

                }

            }
        }
    }
}
