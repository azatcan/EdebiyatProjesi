using EDB.BackofficeUI.Handlers;
using EDB.BackofficeUI.Utils;
using EDB.Domain.Entities;
using EDB.WebAPI.Model.AuthorsModel;
using Microsoft.AspNetCore.Mvc;

namespace EDB.BackofficeUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthorize]
    public class AdminAuthorsController : Controller
    {
        private readonly DefaultClient _client;

        public AdminAuthorsController(DefaultClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var respnse = await _client.GetAsync<List<Authors>>(DefaultClientEndpoint.Authors.List);
            return View(respnse);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(new AuthorsAddedModel());
        }
        [HttpPost]
        public async Task<IActionResult> Add(AuthorsAddedModel model)
        {
            var response = await _client.PostAuthorsAsync(DefaultClientEndpoint.Authors.Add, model);
            if (response != null && response.Success == true)
            {
                return View("Error");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
