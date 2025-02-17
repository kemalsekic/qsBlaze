using Microsoft.AspNetCore.Identity;

namespace qsBlaze.Models
{
    public class ApplicationUser
    {
        public string Id { get; set; }
        public int UUId { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string Team { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public int RoleId { get; set; }
        public string RoleType { get; set; }
    }
}
