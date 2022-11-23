using EasySport_DAL.Interfaces;
using EasySport_DAL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_DAL.Services
{
    public class AuthRepository : IAuthRepository
    {
        private readonly string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EasySportDB;Integrated Security=True;";

        // récup les infos dans appsettingssjon
        private readonly IConfiguration _Configuration;
        public AuthRepository(IConfiguration configuration)
        {
            _Configuration = configuration;
        }


        public UserEntities Auth(string login, string password)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM [Users] WHERE [Email] = @login OR [Pseudo] = @login";
            cmd.Parameters.AddWithValue("Login", login);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                UserEntities user = new UserEntities();
                if (reader.Read())
                {
                    user.Id = (Guid)reader[nameof(UserEntities.Id)];
                    user.Pseudo = (string)reader[nameof(UserEntities.Pseudo)];
                    user.Email = (string)reader[nameof(UserEntities.Email)];
                    user.Password = (string)reader[nameof(UserEntities.Password)];
                    user.Role = (int)reader[nameof(UserEntities.Role)];
                }
                else throw new Exception("Identifiant incorrecte");
                return user;
            }
        }

        public string GenerateToken(string SecretKey, List<Claim> claims)
        {
            throw new NotImplementedException();
        }
    }
}
