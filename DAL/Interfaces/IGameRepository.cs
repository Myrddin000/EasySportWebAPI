using EasySport_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_DAL.Interfaces
{
    public interface IGameRepository
    {
        IEnumerable<GameEntities> GetAll();

        void Create(GameEntities game);

        GameEntities GetDetails(Guid Id);

        void Update(GameEntities game);

        void Delete(Guid Id);
    }
}
