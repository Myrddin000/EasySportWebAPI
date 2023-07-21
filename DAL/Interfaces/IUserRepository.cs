using EasySport_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_DAL.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserEntities> GetAll();

        void Create(UserEntities user);

        void Delete(Guid Id);

        void Update(UserEntities user);

        UserEntities GetById(Guid Id);
    }
}
