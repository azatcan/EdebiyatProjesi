using EDB.Domain.Entities;
using EDB.WebAPI.Model.AccountModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EDB.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;

        public AccountController(Microsoft.AspNetCore.Identity.UserManager<Users> userManager, SignInManager<Users> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = new Users();
                if (model.ImagePath != null) 
                {
                    var extension = Path.GetExtension(model.ImagePath.FileName);
                    var newimagename = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/resimler",newimagename);
                    var stream = new FileStream(location,FileMode.Create);
                    model.ImagePath.CopyTo(stream);
                    user.ImagePath = newimagename;
                }
                //Users users = new Users
                //{
                user.Name = model.Name;
                user.SurName = model.SurName;
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.AudioFilePath = model.AudioFilePath;
                //};
                if (model.Password == model.RePassword)
                {
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return Ok("Registration successful.");
                    }

                    return BadRequest(result.Errors);
                }
            }
            return Ok();
        }
        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}