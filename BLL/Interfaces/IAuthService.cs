using EasySport_BLL.Models;
using EasySport_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_BLL.Interfaces
{
    public interface IAuthService
    {
        TokenDTO Auth(LoginDTO login);

        string GenerateToken(string secretkey, List<Claim> claims);
    }
}
