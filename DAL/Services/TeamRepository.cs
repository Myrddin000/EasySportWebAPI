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
    public class TeamRepository : ITeamRepository
    {
        private readonly string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EasySportDB;Integrated Security=True;";

        public void Create(TeamEntities team)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"DECLARE @Temp Table(Id UNIQUEIDENTIFIER)
                                INSERT INTO [Teams] ([Name], [Sport], [UserId]) OUTPUT inserted.Id INTO @Temp VALUES (@Name, @Sport, @UserId)   
                                INSERT INTO [Teams_Users] ([TeamId], [UserId]) VALUES ((SELECT Id FROM @Temp), @UserId)";
            cmd.Parameters.AddWithValue(nameof(TeamEntities.Name), team.Name);
            cmd.Parameters.AddWithValue(nameof(TeamEntities.Sport), team.Sport);
            cmd.Parameters.AddWithValue(nameof(TeamEntities.UserId), team.UserId);
           
            

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public IEnumerable<TeamEntities> GetAll()
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM[Teams]";
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return new TeamEntities
                {
                    Id = (Guid)reader[nameof(TeamEntities.Id)],
                    Name = (string)reader[nameof(TeamEntities.Name)],
                    Sport = (string)reader[nameof(TeamEntities.Sport)], 
                    UserId = (Guid)reader[nameof(TeamEntities.UserId)]
                };
            }
            sqlConnection.Close();
        }

            public void Update(TeamEntities team)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"UPDATE [Teams] SET [Name] = @Name, [Sport] = @Sport WHERE Id = @Id";
            cmd.Parameters.AddWithValue(nameof(TeamEntities.Id), team.Id);
            cmd.Parameters.AddWithValue(nameof(TeamEntities.Name), team.Name);
            cmd.Parameters.AddWithValue(nameof(TeamEntities.Sport), team.Sport);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }



        public void Delete(Guid Id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM [Teams_Users] WHERE [TeamId] = @Id
                                        DELETE FROM [Teams] WHERE [Id] = @Id";


                    cmd.Parameters.AddWithValue(nameof(TeamEntities.Id), Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public TeamEntities GetDetails(Guid Id)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = $"SELECT * FROM[Teams] WHERE [Teams].Id = @{nameof(TeamEntities.Id)}";
            cmd.Parameters.AddWithValue(nameof(TeamEntities.Id), Id);
          
            using SqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.Read())
            {
                
                return new TeamEntities
                {
                    Id = (Guid)reader[nameof(TeamEntities.Id)],
                    Name = (string)reader[nameof(TeamEntities.Name)],
                    Sport = (string)reader[nameof(TeamEntities.Sport)],
                    UserId = (Guid)reader[nameof(TeamEntities.UserId)]
                };
            }
            else
            {
                
                throw new Exception("Team non trouvé");
                
            }
            
            
        }

        public void AddPlayer(Guid TeamId, Guid PlayerId)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"INSERT INTO [Teams_Users] (TeamId, UserId) VALUES (@TeamId, @PlayerId)";
            cmd.Parameters.AddWithValue("@TeamId", TeamId);
            cmd.Parameters.AddWithValue("@PlayerId", PlayerId);

            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }


        public void DeletePlayer(Guid TeamId, Guid PlayerId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = sqlConnection.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM [Teams_Users] WHERE [TeamId] = @TeamId AND [UserId] = @PlayerId";


                    cmd.Parameters.AddWithValue("@TeamId", TeamId);
                    cmd.Parameters.AddWithValue("@PlayerId", PlayerId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<TeamsUsersEntities> GetAllPlayers(Guid TeamId)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM [Teams_Users] 
                              INNER JOIN [Users] ON [Users].Id = [Teams_Users].UserId
                              WHERE TeamId = @TeamId";
            cmd.Parameters.AddWithValue("@TeamId", TeamId);  
            
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return new TeamsUsersEntities
                {   
                    TeamId = (Guid)reader[nameof(TeamsUsersEntities.TeamId)],
                    UserId = (Guid)reader[nameof(TeamsUsersEntities.UserId)],
                    Pseudo = (string)reader[nameof(TeamsUsersEntities.Pseudo)],
                    Email = (string)reader[nameof(TeamsUsersEntities.Email)],
                    
                };
            }
            sqlConnection.Close();

        }
    }
}
