using DataAccessLibrary.Models;
using qsBlaze.Models;
using System.Text;
using DataAccessLibrary;
using DataAccessLibrary.Interfaces;
using System.IO;
using qsBlaze.Data.UserInfo;
using System.Linq;

namespace qsBlaze.Shared.HelperProcs
{
    public class HelperUserAdded : IHelperUserAdded
    {
        public ApplicationUser GenerateUUID(ApplicationUser p, List<UserRolesModel> userRoles)
        {
            if (userRoles is not null)
            {
                foreach (var role in userRoles)
                {
                    if (role.UserId == p.Id)
                    {
                        p.RoleId = role.RoleId;
                        p.RoleType = role.Name;
                    }
                }
            }
            return p;
        }

        public async Task<ApplicationUser> SetUserRolesAsync(ApplicationUser p, List<UserRolesModel> userRoles)
        {
            UserRolesModel personToEdit = new UserRolesModel();
            personToEdit.UserId = p.Id;

            if (userRoles is not null)
            {
                bool contains = userRoles.Any(personToEdit => personToEdit.UserId == p.Id);
                
                if(!contains)
                {
                    p.RoleId = 3;
                    p.RoleType = "QA";
                    personToEdit.RoleId = 3;
                    personToEdit.Name = "QA";
                }
            }
            return p;
        }
    }
}
