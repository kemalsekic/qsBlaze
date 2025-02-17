using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models.Games
{
    public class GamesModel
    {
        public int GameId { get; set; }
        public string UUId { get; set; }
        public string GameName { get; set; }
        public string GameHost { get; set; }
        public List<string> TeamsList { get; set; }
        public List<string> SportsList { get; set; }
        public DateTime GameDate { get; set; }
    }
}
