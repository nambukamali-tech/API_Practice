using Microsoft.AspNetCore.Mvc;
using Flowers_API.Models;
using Flowers_API.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Flowers_API.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string userName , string password)
        {
            if (userName == "Admin" && password == "admin123")
            {
                var claims = new List<Claim>
               {
                new Claim(ClaimTypes.Name , userName)
               };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MyCookieAuth", principal);
                return RedirectToAction("Index", "Flowers");
               
            }
            ViewBag.Error = "Invalid UserName or Password";
            return View();

        }
    }
}
