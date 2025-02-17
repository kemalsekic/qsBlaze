using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class VoteTicketModel
    {
        public int TicketId { get; set; }
        public string TicketNumber { get; set; }
        public int PersonID { get; set; }
        public DateTime DueDate { get; set;}
        public string Title { get; set; }
        public string Description { get; set; }
        public int PriorityLevel { get; set; }
        public DateTime VoteDate { get; set;}
        public int VoteValue { get; set;}
        public int VoteId { get; set;}
        public string CreatedBy { get; set;}
        public DateTime CreatedOn { get; set;}
    }
}
