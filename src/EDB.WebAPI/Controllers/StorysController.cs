using EDB.Domain.Data;
using EDB.Domain.Entities;
using EDB.Infrastructure.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorysController : ControllerBase
    {
        private readonly IStorysService storysService;
        private readonly DataContext dataContext;

        public StorysController(IStorysService storysService, DataContext dataContext)
        {
            this.storysService = storysService;
            this.dataContext = dataContext;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult Get()
        {
            storysService.List();
            return Ok();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Added(Storys storys)
        {
            storysService.Add(storys);
            return Ok();
        }
        [HttpPost]
        [Route("Update")]
        public IActionResult Update(Guid id)
        {
            var result = storysService.GetById(id);
            storysService.Update(result);
            return Ok();
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(Guid id)
        {
            var result = storysService.GetById(id);
            storysService.Delete(result);
            return Ok();
        }

    }
}
