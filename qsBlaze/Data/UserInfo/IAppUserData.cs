using DataAccessLibrary.Models;
using qsBlaze.Models;

namespace qsBlaze.Data.UserInfo
{
    public interface IAppUserData
    {
        Task<List<ApplicationUser>> GetRegisteredUsers();
        Task<List<ApplicationUser>> GetAllUserDetails();
        Task RegisterUser(ApplicationUser userToRegister);
        Task EditUser(ApplicationUser userToEdit);



        Task EditUserRole(UserRolesModel userToEdit);
        Task AddNewRole(UserRolesModel userToEdit);
        Task<List<UserRolesModel>> GetUserRoles();
        Task<List<UserRolesModel>> GetUserRoleTypes();
    }
}