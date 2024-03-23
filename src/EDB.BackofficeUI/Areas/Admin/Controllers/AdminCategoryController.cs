using EDB.BackofficeUI.Handlers;
using EDB.BackofficeUI.Utils;
using EDB.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDB.BackofficeUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminCategoryController : Controller
    {
        private readonly DefaultClient _client;

        public AdminCategoryController(DefaultClient client)
        {
            _client = client;
        }

        public IActionResult CategoryList()
        {
            var response = _client.GetAsync<Category>(DefaultClientEndpoint.Category.List);
            return View(response);
        }
    }
}
