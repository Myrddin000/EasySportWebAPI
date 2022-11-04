using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_BLL.Models
{
    public class UserRegisteredDTO
    {
        public Guid Id { get; set; }

        public string Pseudo { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public int Role { get; set; }
    }
}
