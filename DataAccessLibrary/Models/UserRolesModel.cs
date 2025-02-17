using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.Interfaces;

namespace DataAccessLibrary.Models
{
    public class UserRolesModel : IUserRolesModel
    {
        public string? UserId { get; set; }
        public int RoleId { get; set; }
        public string? Name { get; set; }
    }
}
