using EDB.BackofficeUI.Handlers;
using EDB.BackofficeUI.Models;
using EDB.BackofficeUI.Utils;
using EDB.WebAPI.Model.AccountModel;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace EDB.BackofficeUI.Controllers
{
    public class AccountController : Controller
    {
        DefaultClient client;

        public AccountController(DefaultClient client)
        {
            this.client = client;
        }

        [HttpGet]
        public IActionResult login()
        {
            return View(new LoginModel());
        }
        [HttpPost]
        public async Task<IActionResult> login(LoginModel model)
        {
           

            var response = await client.PostAsync<LoginModel,LoginResponse>(DefaultClientEndpoint.Authentice.Login, model);
            if (response.Success)
            {
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("login", "Account");
            }

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> LogOut()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5210");

                var response = await client.PostAsync("/api/Account/logout", null); 

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home"); 
                }
                else
                {
                    return View("Error"); 
                }
            }
        }
    }
}
