using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models.Games
{
    public class TournamentsModel
    {
        public int TournamentId { get; set; }
        public string UUId { get; set; }
        public string TournamentName { get; set; }
        public List<string> TeamsList { get; set; }
        public List<string> SportsList { get; set; }
        public DateTime TournamentDate { get; set; }
    }
}
