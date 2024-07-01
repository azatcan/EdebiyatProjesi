using EDB.Domain.Abstract;
using EDB.Domain.Data;
using EDB.Domain.Entities;
using EDB.Infrastructure.Abstract;
using EDB.WebAPI.Model.AuthorsModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EDB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorsService authorsService;
        private readonly DataContext dataContext;

        public AuthorsController(IAuthorsService authorsService, DataContext dataContext)
        {
            this.authorsService = authorsService;
            this.dataContext = dataContext;
        }

        [HttpGet]
        [Route("List")]
        public IActionResult GetAuthors()
        {
            var result = authorsService.List();
            return Ok(result);
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AuthorsAdded([FromForm] AuthorsAddedModel model)
        {
            if (ModelState.IsValid)
            {
                Authors authors = new Authors();
                if (model.ImagePath != null)
                {
                    var extension = Path.GetExtension(model.ImagePath.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resimler/authors", newimagename);
                    using (var stream = new FileStream(location, FileMode.Create))
                    {
                        await model.ImagePath.CopyToAsync(stream);
                    }
                    authors.ImagePath = newimagename;
                }

                authors.Name = model.Name;
                authors.SurName = model.SurName;
                authors.About = model.About;
                authors.Pseudonym = model.Pseudonym;
                authors.DateOfBirth = model.DateOfBirth;
                authors.DateOfDeath = model.DateOfDeath;

                dataContext.Add(authors);
                dataContext.SaveChanges();
            }

            return NoContent();
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(Guid id)
        {
            var authors = authorsService.GetById(id);
            dataContext.Update(authors);
            dataContext.SaveChanges();
            return Ok();
        }
        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(Guid id)
        {
            var authors = authorsService?.GetById(id);
            authorsService.Delete(authors);
            return Ok();
        }
    }
}
