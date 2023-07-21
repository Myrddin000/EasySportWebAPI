using EasySport_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_DAL.Interfaces
{
    public interface ITeamRepository
    {
        IEnumerable<TeamEntities> GetAll();

        void Create(TeamEntities team);

        void Update(TeamEntities team);

        void Delete(Guid Id);

        TeamEntities GetDetails(Guid Id);

        void AddPlayer(Guid TeamId, Guid PlayerId);

        void DeletePlayer(Guid TeamId, Guid PlayerId);

        IEnumerable<TeamsUsersEntities> GetAllPlayers(Guid TeamId);
    }
}
