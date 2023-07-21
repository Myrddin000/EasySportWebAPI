using EasySport_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_DAL.Models
{
    public class GameRepository : IGameRepository
    {

        private readonly string connectionstring = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EasySportDB;Integrated Security=True;";

        public void Create(GameEntities game)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = $"INSERT INTO[Games]([Title], [Date], [StartTime], [EndTime], [ScoreA], [ScoreB], [TeamId]) VALUES(@{nameof(GameEntities.Title)}, @{nameof(GameEntities.Date)}, @{nameof(GameEntities.StartTime)}, @{nameof(GameEntities.EndTime)}, @{nameof(GameEntities.ScoreA)}, @{nameof(GameEntities.ScoreB)}, @{nameof(GameEntities.TeamId)})";
            cmd.Parameters.AddWithValue(nameof(GameEntities.Title), game.Title);
            cmd.Parameters.AddWithValue(nameof(GameEntities.Date), game.Date);
            cmd.Parameters.AddWithValue(nameof(GameEntities.StartTime), game.StartTime);
            cmd.Parameters.AddWithValue(nameof(GameEntities.EndTime), game.EndTime);
            cmd.Parameters.AddWithValue(nameof(GameEntities.ScoreA), game.ScoreA);
            cmd.Parameters.AddWithValue(nameof(GameEntities.ScoreB), game.ScoreB);
            cmd.Parameters.AddWithValue(nameof(GameEntities.TeamId), game.TeamId);

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
                    cmd.CommandText = //DELETE FROM [Teams_Games] WHERE [TeamId] = @Id
                                        @"DELETE FROM [Games] WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("Id", Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<GameEntities> GetAll()
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"SELECT Id, Title, Date, StartTime, EndTime, ScoreA, ScoreB, TeamId FROM [Games]";
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return new GameEntities
                {
                    Id = (Guid)reader[nameof(GameEntities.Id)],
                    Title = (string)reader[nameof(GameEntities.Title)],
                    Date = (DateTime)reader[nameof(GameEntities.Date)],
                    StartTime = (DateTime)reader[nameof(GameEntities.StartTime)],
                    EndTime = (DateTime)reader[nameof(GameEntities.EndTime)],
                    ScoreA = (reader["ScoreA"] is DBNull) ? null : (int?)reader["ScoreA"],
                    ScoreB = (reader["ScoreB"] is DBNull) ? null : (int?)reader["ScoreB"],
                    TeamId = (Guid)reader[nameof(GameEntities.TeamId)]
                };
            }
            sqlConnection.Close();
        }

        public IEnumerable<GamesUsersEntities> GetHeadcount(Guid Id)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"SELECT G.UserId, U.Pseudo, U.Email, G.Available, G.NotAvailable, G.Pending FROM [Games_Users] G
                                INNER JOIN [Users] U ON U.Id = G.UserId
                                WHERE GameId = @Id";

            cmd.Parameters.AddWithValue(nameof(GamesUsersEntities.Id), Id);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                yield return new GamesUsersEntities
                {
                    Pseudo = (string)reader[nameof(GamesUsersEntities.Pseudo)],
                    Email = (string)reader[nameof(GamesUsersEntities.Email)],
                    UserId = (Guid)reader[nameof(GamesUsersEntities.UserId)],
                    Available = (Boolean)reader[nameof(GamesUsersEntities.Available)],
                    NotAvailable = (Boolean)reader[nameof(GamesUsersEntities.NotAvailable)],
                    Pending = (Boolean)reader[nameof(GamesUsersEntities.Pending)],
                };
            }
            
        }

        public void Update(GameEntities game)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = $"UPDATE [Games] SET [Title] = @{nameof(GameEntities.Title)}, [Date] = @{nameof(GameEntities.Date)}, [StartTime] = @{nameof(GameEntities.StartTime)}, [EndTime] = @{nameof(GameEntities.EndTime)}, [ScoreA] = @{nameof(GameEntities.ScoreA)}, [ScoreB] = @{nameof(GameEntities.ScoreB)}, [TeamId] = @{nameof(GameEntities.TeamId)} WHERE [Id] = @{nameof(GameEntities.Id)}";
            cmd.Parameters.AddWithValue(nameof(GameEntities.Id), game.Id);
            cmd.Parameters.AddWithValue(nameof(GameEntities.Title), game.Title);
            cmd.Parameters.AddWithValue(nameof(GameEntities.Date), game.Date);
            cmd.Parameters.AddWithValue(nameof(GameEntities.StartTime), game.StartTime);
            cmd.Parameters.AddWithValue(nameof(GameEntities.EndTime), game.EndTime);
            cmd.Parameters.AddWithValue(nameof(GameEntities.ScoreA), game.ScoreA);
            cmd.Parameters.AddWithValue(nameof(GameEntities.ScoreB), game.ScoreB);
            cmd.Parameters.AddWithValue(nameof(GameEntities.TeamId), game.TeamId);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
