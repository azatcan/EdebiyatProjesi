﻿using EDB.Domain.Data;
using EDB.Domain.Entities;
using EDB.WebAPI.Model.RoleModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EDB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<Roles> _roleManager;
        private readonly DataContext _dataContext;
        private readonly UserManager<Users> _userManager;

        public RoleController(RoleManager<Roles> roleManager, DataContext dataContext, UserManager<Users> userManager)
        {
            _roleManager = roleManager;
            _dataContext = dataContext;
            _userManager = userManager;
        }
        [HttpGet]
        [Route("list")]
        public IActionResult List()
        {
            var values = _roleManager.Roles.ToList();
            return Ok(values);
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(RoleViewModel model)
        {
            Roles roles = new Roles
            {
                Name = model.Name,
            };
            var result = await _roleManager.CreateAsync(roles);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(Guid id, [FromBody] RoleUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
            {
                return NotFound();
            }

            role.Name = model.Name;
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(Guid id)
        {
            var delete = _dataContext.Roles.Find(id);
            _dataContext.Roles.Remove(delete);
            _dataContext.SaveChanges();

            return Ok();
        }
    }
}
