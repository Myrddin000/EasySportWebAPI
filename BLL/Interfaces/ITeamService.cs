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
    }
}
