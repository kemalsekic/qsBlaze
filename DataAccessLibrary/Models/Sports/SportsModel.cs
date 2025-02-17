using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models.Sports
{
    public class SportsModel
    {
        public int SportId { get; set; }
        public string UUId { get; set; }
        public string SportName { get; set; }
        public List<string> TeamsList { get; set; }
        public List<string> SportsList { get; set; }
    }
}
