﻿using EDB.Domain.Entities;
using EDB.WebAPI.Model.AccountModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace EDB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<Users> _userManager;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<Roles> _roleManager;
        private readonly SignInManager<Users> _signInManager;
        public readonly IWebHostEnvironment _webHost;

        public AccountController(Microsoft.AspNetCore.Identity.UserManager<Users> userManager, Microsoft.AspNetCore.Identity.RoleManager<Roles> roleManager, SignInManager<Users> signInManager, IWebHostEnvironment webHost)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _webHost = webHost;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: false, lockoutOnFailure: false);
         
            if (result.Succeeded)
            {
                return new JsonResult(new { Message = "Login successful." }) { StatusCode = 200 };
            }
            return new JsonResult(new { Message = "Unauthorized access." }) { StatusCode = 401 };
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromForm] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = new Users();
                if (model.ImagePath != null)
                {
                    var extension = Path.GetExtension(model.ImagePath.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resimler/user", newimagename);
                    using (var stream = new FileStream(location, FileMode.Create))
                    {
                        await model.ImagePath.CopyToAsync(stream);
                    }
                    user.ImagePath = newimagename;
                }

                user.Name = model.Name;
                user.SurName = model.SurName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.AudioFilePath = model.AudioFilePath;

                if (model.Password == model.RePassword)
                {
                    var result = await _userManager.CreateAsync(user, model.Password);
                    await _userManager.AddToRoleAsync(user, "User");
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return NoContent();
                    }

                    return BadRequest(result.Errors);
                }
            }

            return NoContent();
        }
        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet]
        [Route("getUserRoles")]
        public async Task<IActionResult> GetUserRoles()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var userRoles = await _userManager.GetRolesAsync(currentUser);
            var rolesString = string.Join(",", userRoles);
            return Ok(rolesString);
        }
    }
}