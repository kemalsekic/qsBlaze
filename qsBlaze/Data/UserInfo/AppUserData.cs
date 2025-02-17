using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using qsBlaze.Models;

namespace qsBlaze.Data.UserInfo
{
    public class AppUserData : IAppUserData
    {
        private readonly ISqlDataAccess _db;

        public AppUserData(ISqlDataAccess db)
        {
            _db = db;
        }
        //Registered Users
        public Task RegisterUser(ApplicationUser userToRegister)
        {
            string sql = @"insert into dbo.AspNetUsers (Id, PasswordHash, NormalizedUserName, UserName, Email, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount)
                            values (@Id, @PasswordHash, @NormalizedUserName, @UserName, @Email, @EmailConfirmed, @PhoneNumberConfirmed, @TwoFactorEnabled, @LockoutEnabled, @AccessFailedCount);";

            return _db.SaveData(sql, userToRegister);
        }

        public Task<List<ApplicationUser>> GetRegisteredUsers()
        {
            string sql = "select * from dbo.AspNetUsers";

            return _db.LoadData<ApplicationUser, dynamic>(sql, new { });
        }

        public Task<List<ApplicationUser>> GetAllUserDetails()
        {
            string sql = @"
                            select * 
                            from dbo.AspNetUsers
                            INNER JOIN dbo.AspNetUserRoles
                            ON dbo.AspNetUsers.Id=dbo.AspNetUserRoles.UserId
                            ";

            return _db.LoadData<ApplicationUser, dynamic>(sql, new { });
        }

        public Task EditUser(ApplicationUser userToEdit)
        {
            string sql = @"UPDATE dbo.AspNetUsers 
                            SET UserName = @UserName,
                                Email = @Email,
                                NormalizedUserName = @NormalizedUserName
                            WHERE Id = @Id";

            return _db.SaveData(sql, userToEdit);
        }

        public Task EditUserRole(UserRolesModel userToEdit)
        {
            string sql = @"UPDATE dbo.AspNetUserRoles 
                            SET RoleId = @RoleId
                            WHERE UserId = @UserId";

            return _db.SaveData(sql, userToEdit);
        }

        public Task AddNewRole(UserRolesModel roleToAdd)
        {
            string sql = @"insert into dbo.AspNetUserRoles (UserId, RoleId)
                            values (@UserId, @RoleId);";

            return _db.SaveData(sql, roleToAdd);
        }

        public Task<List<UserRolesModel>> GetUserRoles()
        {
            string sql = @"
                            select * 
                            from dbo.AspNetUserRoles
                            INNER JOIN dbo.AspNetRoles
                            ON dbo.AspNetUserRoles.RoleId=dbo.AspNetRoles.Id
                            ";

            return _db.LoadData<UserRolesModel, dynamic>(sql, new { });
        }

        public Task<List<UserRolesModel>> GetUserRoleTypes()
        {
            string sql = @"
                            select * 
                            from dbo.AspNetRoles
                            ";

            return _db.LoadData<UserRolesModel, dynamic>(sql, new { });
        }
    }
}
