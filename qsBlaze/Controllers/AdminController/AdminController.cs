using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using qsBlaze.Models;

namespace qsBlaze.Controllers.AdminController
{
    public class AdminController : Controller, IAdminController
    {
        private UserManager<ApplicationUser> userManager;

        public AdminController(UserManager<ApplicationUser> usrMgr)
        {
            userManager = usrMgr;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser
                {
                    UserName = user.UserName,
                    Email = user.Email
                };

                IdentityResult result = await userManager.CreateAsync(appUser, user.PasswordHash);

                if (result.Succeeded)
                    return RedirectToAction("");
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }
    }
}
