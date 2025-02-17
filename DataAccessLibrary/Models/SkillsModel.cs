using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class SkillsModel
    {
        public int SkillID { get; set; }
        public int PersonID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public int SkillLevel { get; set; }
        public int UpVotes { get; set; }
        public int DownVotes { get; set; }
        public bool VotedUp { get; set; }
        public bool VotedDown { get; set; }
    }
}
