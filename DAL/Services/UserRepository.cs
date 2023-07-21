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
            cmd.CommandText = $"INSERT INTO [Users] ([Pseudo], [Email], [Password]) VALUES (@{nameof(UserEntities.Pseudo)}, @{nameof(UserEntities.Email)}, @{nameof(UserEntities.Password)})";
            cmd.Parameters.AddWithValue(nameof(UserEntities.Pseudo), user.Pseudo);
            cmd.Parameters.AddWithValue(nameof(UserEntities.Email), user.Email);
            cmd.Parameters.AddWithValue(nameof(UserEntities.Password), user.Password);
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
                    Id = (Guid)reader[nameof(UserEntities.Id)],
                    Pseudo = (string)reader[nameof(UserEntities.Pseudo)],
                    Email = (string)reader[nameof(UserEntities.Email)],
                    Role = (int)reader[nameof(UserEntities.Role)],
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
                    cmd.CommandText = $"DELETE FROM [Users] WHERE [Id] = @{nameof(UserEntities.Id)}";

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
            cmd.CommandText = $"UPDATE [Users] SET [Pseudo] = @{nameof(UserEntities.Pseudo)}, [Email] = @{nameof(UserEntities.Email)}, [Password] = @{nameof(UserEntities.Password)}, [Role] = @{nameof(UserEntities.Role)} WHERE Id = @{nameof(UserEntities.Id)}";
            cmd.Parameters.AddWithValue(nameof(UserEntities.Id), user.Id);
            cmd.Parameters.AddWithValue(nameof(UserEntities.Pseudo), user.Pseudo);
            cmd.Parameters.AddWithValue(nameof(UserEntities.Email), user.Email);
            cmd.Parameters.AddWithValue(nameof(UserEntities.Password), user.Password);
            cmd.Parameters.AddWithValue(nameof(UserEntities.Role), user.Role);

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
                    cmd.CommandText = $"SELECT * FROM [Users] WHERE [Id] = @{nameof(UserEntities.Id)}";

                    cmd.Parameters.AddWithValue("Id", Id);

                    using SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new UserEntities
                        {
                            
                            Pseudo = (string)reader[nameof(UserEntities.Pseudo)],
                            Email = (string)reader[nameof(UserEntities.Email)],
                            Password = (string)reader[nameof(UserEntities.Password)],
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
