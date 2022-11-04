using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_BLL.Models
{
    public class TokenDTO
    {
        public TokenDTO(string token, UserRegisteredDTO userRegistered)
        {
            Token = token;
            UserRegistered = userRegistered;
        }
        public string Token { get; set; } = string.Empty;
        public UserRegisteredDTO UserRegistered { get; set; }
    }
}
