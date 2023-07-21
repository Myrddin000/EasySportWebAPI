using EasySport_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_DAL.Interfaces
{
    public interface IAuthRepository
    {
        UserEntities Auth(string login, string password);

        string GenerateToken(string SecretKey, List<Claim> claims);
    }
}
