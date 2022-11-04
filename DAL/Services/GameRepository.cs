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
            cmd.CommandText = @"INSERT INTO[Games]([Date], [StartTime], [EndTime], [ScoreA], [ScoreB], [TeamId]) VALUES(@Date, @StartTime, @EndTime, @ScoreA, @ScoreB, @TeamId)";
            cmd.Parameters.AddWithValue("Date", game.Date);
            cmd.Parameters.AddWithValue("StartTime", game.StartTime);
            cmd.Parameters.AddWithValue("EndTime", game.EndTime);
            cmd.Parameters.AddWithValue("ScoreA", game.ScoreA);
            cmd.Parameters.AddWithValue("ScoreB", game.ScoreB);
            cmd.Parameters.AddWithValue("TeamId", game.TeamId);

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
            cmd.CommandText = @"SELECT * FROM[Games]";
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                yield return new GameEntities
                {
                    Id = (Guid)reader["Id"],
                    Date = (DateTime)reader["Date"],
                    StartTime = (DateTime)reader["StartTime"],
                    EndTime = (DateTime)reader["EndTime"],
                    ScoreA = (int)reader["ScoreA"],
                    ScoreB = (int)reader["ScoreB"],
                    TeamId = (Guid)reader["TeamId"]
                };
            }
            sqlConnection.Close();
        }

        public GameEntities GetDetails(Guid Id)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM[Games] WHERE [Games].Id = @Id";
            cmd.Parameters.AddWithValue("Id", Id);

            using SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {

                return new GameEntities
                {
                    Id = (Guid)reader["Id"],
                    Date = (DateTime)reader["Date"],
                    StartTime = (DateTime)reader["StartTime"],
                    EndTime = (DateTime)reader["EndTime"],
                    ScoreA = (int)reader["ScoreA"],
                    ScoreB = (int)reader["ScoreB"],
                    TeamId = (Guid)reader["TeamId"]
                };
            }
            else
            {

                throw new Exception("Game non trouvé");

            }
        }

        public void Update(GameEntities game)
        {
            using SqlConnection sqlConnection = new SqlConnection(connectionstring);
            sqlConnection.Open();
            using SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = @"UPDATE [Games] SET [Date] = @Date, [StartTime] = @StartTime, [EndTime] = @EndTime, [ScoreA] = @ScoreA, [ScoreB] = @ScoreB, [TeamId] = @TeamId WHERE [Id] = @Id";
            cmd.Parameters.AddWithValue("Id", game.Id);
            cmd.Parameters.AddWithValue("Date", game.Date);
            cmd.Parameters.AddWithValue("StartTime", game.StartTime);
            cmd.Parameters.AddWithValue("EndTime", game.EndTime);
            cmd.Parameters.AddWithValue("ScoreA", game.ScoreA);
            cmd.Parameters.AddWithValue("ScoreB", game.ScoreB);
            cmd.Parameters.AddWithValue("TeamId", game.TeamId);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
