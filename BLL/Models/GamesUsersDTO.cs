using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_BLL.Models
{
    public class GamesUsersDTO
    {
        

        public string Pseudo { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public Guid UserId { get; set; }

        public Boolean Available { get; set; }

        public Boolean NotAvailable { get; set; }

        public Boolean Pending { get; set; }
    }
}
