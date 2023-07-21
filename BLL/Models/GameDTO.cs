using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySport_BLL.Models
{
    public class GameDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int? ScoreA { get; set; }

        public int? ScoreB { get; set; }

        public Guid TeamId { get; set; }

        
    }
}
