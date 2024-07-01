using EDB.BackofficeUI.Areas.Admin.Models;
using EDB.BackofficeUI.Handlers;
using EDB.BackofficeUI.Utils;
using EDB.Domain.Entities;
using EDB.WebAPI.Model.CategoryModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EDB.BackofficeUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AdminAuthorize]
    public class AdminCategoryController : Controller
    {
        private readonly DefaultClient _client;

        public AdminCategoryController(DefaultClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync<List<Category>>(DefaultClientEndpoint.Category.List);
            return View(response);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(new CategoryViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel model)
        {
            var response = await _client.PostAsync<CategoryViewModel, CategoryResponse>(DefaultClientEndpoint.Category.Add, model);
            if (response != null && response.Success == true)
            {
                return View("Error");
            }
            else
            {
                return RedirectToAction("Index");
            }
                    
        }

        public async Task<IActionResult> Delete(CategoryRequest request)
        {
            
            var response = await _client.PostAsync<CategoryRequest,CategoryResponse >(DefaultClientEndpoint.Category.Delete, request);

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
