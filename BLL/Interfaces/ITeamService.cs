using EasySport_BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_BLL.Interfaces
{
    public interface ITeamService
    {
        void Create(TeamFormDTO team);

        IEnumerable<TeamDTO> GetAll();
        
        void Update(TeamFormDTO team);

        void Delete(Guid Id);

        TeamDTO GetDetails(Guid Id);

        void AddPlayer(Guid TeamId, Guid PlayerId);

        void DeletePlayer(Guid TeamId, Guid PlayerId);

        IEnumerable<TeamsUsersDTO> GetAllPlayers(Guid TeamId);
    }
}
