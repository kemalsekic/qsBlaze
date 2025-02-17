using Microsoft.AspNetCore.Identity;
using System.Net.NetworkInformation;
using MatBlazor;
using qsBlaze.Models;
using DataAccessLibrary;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using DataAccessLibrary.Models;

namespace qsBlaze.Shared.GetInfo
{
    public class GetActiveUserClass : IGetActiveUserClass
    {
        [Inject]
        UserManager<IdentityUser> userManager { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> authenticationStateTask { get; set; }
        public string UserName { get; set; }
        public async Task GetActiveUser(string ActiveUser)
        {
            if(authenticationStateTask is not null && authenticationStateTask.IsCompleted) 
            {            
                var user = (await authenticationStateTask).User;

                if (user.Identity is not null && user.Identity.IsAuthenticated)
                {
                    // User is logged in
                    var currentUser = await userManager.GetUserAsync(user);
                    ActiveUser = currentUser.UserName.ToString();
                    ActiveUser = ActiveUser.Substring(0, ActiveUser.IndexOf("@"));
                }
                else
                {
                    Console.WriteLine("[QStack] - User is not logged in.");
                }
            }
        }

        public async Task GetActiveUserAsync(PersonModel ActiveUser)
        {
            var user = (await authenticationStateTask).User;
            if (authenticationStateTask is not null && authenticationStateTask.IsCompleted)
            {

                if (user.Identity is not null && user.Identity.IsAuthenticated)
                {
                    // User is logged in
                    var currentUser = await userManager.GetUserAsync(user);
                    ActiveUser.UUId = currentUser.Id;
                    ActiveUser.EmailAddress = currentUser.Email;
                    ActiveUser.UserName = currentUser.UserName.ToString();
                    ActiveUser.UserName = ActiveUser.UserName.Substring(0, ActiveUser.UserName.IndexOf("@"));
                    ActiveUser.IsActive = true;
                }
                else
                {
                    Console.WriteLine("[QStack] - User is not logged in.");
                    ActiveUser.IsActive = false;
                }
            }
        }

        public void GetActiveUser(PersonModel ActiveUser)
        {
            if (authenticationStateTask is not null && authenticationStateTask.IsCompleted)
            {
                Task.Run(async () =>
                {
                    var user = (await authenticationStateTask).User;

                    if (user.Identity is not null && user.Identity.IsAuthenticated)
                    {
                        // User is logged in
                        var currentUser = await userManager.GetUserAsync(user);
                        ActiveUser.UUId = currentUser.Id;
                        ActiveUser.EmailAddress = currentUser.Email;
                        ActiveUser.UserName = currentUser.UserName.ToString();
                        ActiveUser.UserName = ActiveUser.UserName.Substring(0, ActiveUser.UserName.IndexOf("@"));
                        ActiveUser.IsActive = true;
                    }
                    else
                    {
                        Console.WriteLine("[QStack] - User is not logged in.");
                        ActiveUser.IsActive = false;
                    }
                }).Wait();
            }
        }
    }
}
