using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zoo_API.Models;
using Zoo_API.Data;
using Zoo_API.Services;


namespace Zoo_API.Controllers
{
    public class AuthController : Controller
    {
        private readonly ZooDbContext _context;
        private readonly JwtServices _jwtservices;
        public AuthController(ZooDbContext context , JwtServices jwtservices)
        {
            _context = context;
            _jwtservices = jwtservices;

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = new Users
                {
                    UserName = request.UserName,
                    Password = request.Password,
                    Email = request.Email
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View(request);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginrequest)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == loginrequest.
                UserName && u.Password == loginrequest.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                    return View(loginrequest);

                }
                //jwt token generation
                var token = _jwtservices.GenerateToken(user.UserName);
                Response.Cookies.Append("JwtToken", token, new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTimeOffset.UtcNow.AddHours(2)
                });
                return RedirectToAction("Index", "Zoo");
            }
            return View(loginrequest);
        }

        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("JwtToken");
            return RedirectToAction("Login");
        }
       
     
    }
}
