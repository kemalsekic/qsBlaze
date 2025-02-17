using DataAccessLibrary.Models;
using qsBlaze.Models;

namespace qsBlaze.Shared.HelperProcs
{
    public interface IHelperUserAdded
    {
        ApplicationUser GenerateUUID(ApplicationUser p, List<UserRolesModel> userRoles);
        //ApplicationUser SetUserRolesAsync(ApplicationUser p, List<UserRolesModel> userRoles);
        Task<ApplicationUser> SetUserRolesAsync(ApplicationUser p, List<UserRolesModel> userRoles);
    }
}