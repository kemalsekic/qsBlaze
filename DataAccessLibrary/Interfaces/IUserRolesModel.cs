namespace DataAccessLibrary.Interfaces
{
    public interface IUserRolesModel
    {
        string? Name { get; set; }
        int RoleId { get; set; }
        string? UserId { get; set; }
    }
}