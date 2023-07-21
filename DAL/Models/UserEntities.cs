using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_DAL.Models
{
    public class UserEntities
    {
        public Guid Id { get; set; }
        public string Pseudo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Role { get; set; }
    }
}
