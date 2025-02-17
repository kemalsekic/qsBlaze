using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string UUId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Color { get; set; }
        public string GroupName { get; set; }
        public int AssignedPoints { get; set; }
        public int CarryOverPoints { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
