using EDB.BackofficeUI.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDB.BackofficeUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthorize]
    public class AdminRoleController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }
    }
}
