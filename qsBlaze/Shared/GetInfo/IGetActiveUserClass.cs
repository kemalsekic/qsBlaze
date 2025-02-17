using DataAccessLibrary.Models;

namespace qsBlaze.Shared.GetInfo
{
    public interface IGetActiveUserClass
    {
        string UserName { get; set; }

        Task GetActiveUser(string ActiveUser);
        Task GetActiveUserAsync(PersonModel ActiveUser);
        public void GetActiveUser(PersonModel ActiveUser);
    }
}