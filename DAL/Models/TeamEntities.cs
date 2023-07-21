using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_DAL.Models
{
    public class TeamEntities
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public string Sport { get; set; } = String.Empty;

        public Guid UserId { get; set; }    


    }
}
