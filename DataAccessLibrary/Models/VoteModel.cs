using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class VoteModel
    {
        public int? VoteId { get; set; }
        public int VoteNumber { get; set; }
        public int PersonID { get; set; }
        public DateTime VoteDate { get; set; }
        public int? VoteValue { get; set; }
        public string? VoteValueString { get; set; }
        public int SessionId { get; set; }
        public string? UserName { get; set; }
    }
}
