using EDB.Domain.Data;
using EDB.Domain.Entities;
using EDB.Infrastructure.Abstract;
using EDB.WebAPI.Model.LiteraryWorksModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiteraryWorksController : ControllerBase
    {
        private readonly ILiteraryWorksService literaryWorksService;
        private readonly DataContext dataContext;

        public LiteraryWorksController(ILiteraryWorksService literaryWorksService, DataContext dataContext)
        {
            this.literaryWorksService = literaryWorksService;
            this.dataContext = dataContext;
        }
        [HttpGet]
        [Route("list")]
        public IActionResult Get()
        {
            var result = literaryWorksService.List();
            return Ok(result);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Added([FromForm]LiteraryWorksAddedModel model)
        {
            if (ModelState.IsValid)
            {
                LiteraryWorks authors = new LiteraryWorks();
                if (model.ImagePath != null)
                {
                    var extension = Path.GetExtension(model.ImagePath.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resimler/literaryworks", newimagename);
                    using (var stream = new FileStream(location, FileMode.Create))
                    {
                        await model.ImagePath.CopyToAsync(stream);
                    }
                    authors.ImagePath = newimagename;
                }

                authors.Title = model.Title;
                authors.Description = model.Description;
                authors.PublicationDate = model.PublicationDate;
                authors.AudioFilePath = model.AudioFilePath;
                authors.AuthorsId = model.AuthorsId;
                authors.CategoryId = model.CategoryId;

                dataContext.Add(authors);
                dataContext.SaveChanges();
            }

            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(Guid id)
        {
            var result = literaryWorksService.GetById(id);
            literaryWorksService.Update(result);
            return Ok();
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(Guid id)
        {
            var result = literaryWorksService.GetById(id);
            literaryWorksService.Delete(result);
            return Ok();
        }
    }
}
