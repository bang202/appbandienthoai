using CuaHangOnline.Data;
using CuaHangOnline.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CuaHangOnline.Controllers
{
    public class AccountController : Controller
    {
        private readonly CuaHangOnlineContext _context;

        public AccountController(CuaHangOnlineContext context)
        {
            _context = context;
        }
        

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User _userFromPage)
        {
            var user = _context.User.Where(m=>m.UserEmail == _userFromPage.UserEmail && m.UserPassword == _userFromPage.UserPassword).FirstOrDefault();
            if (user == null)
            {
                ViewBag.Loginstatus = 0;
            }
            else
            {
                var claims = new List<Claim>
                 {
                    new Claim(ClaimTypes.Name, user.UserEmail),
                    new Claim("FullName", user.UserName),
                    new Claim(ClaimTypes.Role, user.UserRole),
                 };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                 
                };

                 HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return RedirectToAction("Index","Account");
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return  RedirectToAction("Login", "Account"); ;
        }
    }
}
