using Microsoft.AspNetCore.Mvc;
using qsBlaze.Models;

namespace qsBlaze.Controllers.AdminController
{
    public interface IAdminController
    {
        ViewResult Create();
        Task<IActionResult> Create(ApplicationUser user);
        IActionResult Index();
    }
}