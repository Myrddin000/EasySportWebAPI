using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_BLL.Models
{
    
        public class TeamFormDTO
        {

            

            public string Name { get; set; } = String.Empty;

            public string Sport { get; set; } = String.Empty;

            public Guid UserId { get; set; }

            
        }
    
}
