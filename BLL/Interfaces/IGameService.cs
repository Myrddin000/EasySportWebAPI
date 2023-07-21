using EasySport_BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_BLL.Interfaces
{
    public interface IGameService
    {
        void Create(GameFormDTO game);

        IEnumerable<GameDTO> GetAll();
        
        void Update(GameFormDTO game);

        void Delete(Guid Id);

        IEnumerable<GamesUsersDTO> GetHeadcount(Guid Id);
    }
}
