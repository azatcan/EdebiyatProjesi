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
        [Route("list")]
        public IActionResult CategoryList()
        {
            var category = _categoryService.List();
            return Ok(category);
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Add(CategoryViewModel category)
        {
            Category cat = new Category()
            {
                Name = category.Name,
            };
            _context.Add(cat);
            _context.SaveChanges();          
            return Ok();
        }
        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(Guid id)
        {
            var category = _categoryService.GetById(id);
            _categoryService.Delete(category);
            return Ok();
        }
        [HttpPost]
        [Route("update")]
        public IActionResult Update(Category category) 
        {     
            _categoryService.Update(category);
            return Ok();
        }
    }
}
