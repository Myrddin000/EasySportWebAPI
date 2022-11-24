using EasySport_BLL.Models;
using EasySport_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_BLL.Tools
{

    // User Mappers
    public static class Mappers
    {
        public static UserEntities ToDAL(this UserFormDTO user)
        {
            return new UserEntities
            {
                Pseudo = user.Pseudo,
                Email = user.Email,
                Password = user.Password,
                
            };
        }
        public static UserEntities ToDAL(this UserDTO user)
        {
            return new UserEntities
            {
                Id = user.Id,
                Pseudo = user.Pseudo,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
            };
        }

        public static UserDTO ToBLL(this UserEntities user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Pseudo = user.Pseudo,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
            };
        }
        public static UserFormDTO ToFormBLL(this UserEntities user)
        {
            return new UserFormDTO
            {
                
                Pseudo = user.Pseudo,
                Email = user.Email,
                Password = user.Password,
                
            };
        }

        public static IEnumerable<UserDTO> ToBLL(this IEnumerable<UserEntities> user)
        {
            foreach (UserEntities item in user)
            {
                yield return new UserDTO
                {
                    Id = item.Id,
                    Pseudo = item.Pseudo,
                    Email = item.Email,
                    Password = item.Password,
                    Role = item.Role,
                };
            }
        }
        public static UserRegisteredDTO UserRegisteredToBLL(this UserDTO user)
        {
            return new UserRegisteredDTO
            {
                Id = user.Id,
                Pseudo = user.Pseudo,
                Email = user.Email,
                Role = user.Role,
            };
        }



        //  Team Mappers

        public static TeamEntities ToDAL(this TeamFormDTO team)
        {
            return new TeamEntities
            {
               
                Name = team.Name,
                Sport = team.Sport,
                UserId = team.UserId

            };
        }

        public static TeamDTO ToBLL(this TeamEntities team)
        {
            return new TeamDTO
            {
                Id = team.Id,
                Name = team.Name,
                Sport = team.Sport,
                UserId = team.UserId,
            };
        }

        public static IEnumerable<TeamDTO> ToBLL(this IEnumerable<TeamEntities> team)
        {
            foreach (TeamEntities item in team)
            {
                yield return new TeamDTO
                {
                    Id = item.Id,                    
                    Name = item.Name,
                    Sport = item.Sport,
                    UserId = item.UserId,
                };
            }
        }

        public static IEnumerable<TeamsUsersDTO> ToBLL(this IEnumerable<TeamsUsersEntities> team)
        {
            foreach(TeamsUsersEntities item in team)
            {
                yield return new TeamsUsersDTO
                {
                    TeamId = item.TeamId,
                    UserId = item.UserId,
                    Pseudo = item.Pseudo,
                    Email = item.Email,
                };
            }
        }


        //Game

        public static GameEntities ToDAL(this GameFormDTO game)
        {
            return new GameEntities
            {
                Id = game.Id,
                Title = game.Title,
                Date = game.Date,
                StartTime = game.StartTime,
                EndTime = game.EndTime,
                ScoreA = game.ScoreA,
                ScoreB = game.ScoreB,
                TeamId = game.TeamId,

            };
        }

        public static IEnumerable<GamesUsersDTO> ToBLL(this IEnumerable<GamesUsersEntities> game)
        {
            foreach (GamesUsersEntities item in game)
            { 
                yield return new GamesUsersDTO
                {
                Pseudo = item.Pseudo,
                Email = item.Email, 
                UserId = item.UserId,
                Available = item.Available,
                NotAvailable = item.NotAvailable,
                Pending = item.Pending,
                };
            }
        }
        public static IEnumerable<GameDTO> ToBLL(this IEnumerable<GameEntities> game)
        {
            foreach (GameEntities item in game)
            {
                yield return new GameDTO
                {
                    Id = item.Id,
                    Title = item.Title,
                    Date = item.Date,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,
                    ScoreA = item.ScoreA,
                    ScoreB = item.ScoreB,
                    TeamId = item.TeamId,
                };
            }
        }

    }
}
