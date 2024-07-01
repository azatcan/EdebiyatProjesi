using EDB.BackofficeUI.Areas.Admin.Models;
using EDB.Domain.Abstract;
using EDB.Domain.Concrete;
using EDB.Domain.Data;
using EDB.Domain.Entities;
using EDB.Infrastructure.Abstract;
using EDB.Infrastructure.Concrete;
using EDB.WebAPI.Model.CategoryModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        DataContext _context;

        public CategoryController(ICategoryService categoryService, DataContext context)
        {
            _categoryService = categoryService;
            _context = context;
        }

        [HttpGet]
        [Route("List")]
        public IActionResult List()
        {
            var category = _categoryService.List();
            return Ok(category);
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(CategoryViewModel category)
        {
            Category cat = new Category()
            {
                Id = Guid.NewGuid(),
                Name = category.Name,
            };
            _context.Add(cat);
            _context.SaveChanges();          
            return Ok();
        }
        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete([FromBody] CategoryRequest response)
        {
            var category = _categoryService.GetById(response.id);
            if (category == null)
            {
                return NotFound();
            }

            _categoryService.Delete(category);
            return Ok();
        }
        [HttpPost]
        [Route("Update")]
        public IActionResult Update(Category category,Guid id) 
        {
            var Getid = _categoryService.GetById(id);
            if (Getid == null)
            {
                return NotFound();
            }
            else
            {
                _categoryService.Update(category);
                return Ok();
            }
          
        }
    }
}
