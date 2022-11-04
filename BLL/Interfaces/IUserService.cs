using EasySport_BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_BLL.Interfaces
{
    
    public interface IUserService
    {
        void Create(UserFormDTO user);
        IEnumerable<UserDTO> GetAll();

        void Delete(Guid Id);
    }
}
