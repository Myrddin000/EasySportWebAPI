using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_BLL.Models
{

    public class TeamsUsersDTO
    {
        public Guid TeamId { get; set; }

        public Guid UserId { get; set; }

        public string Pseudo { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
