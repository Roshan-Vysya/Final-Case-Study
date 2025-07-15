using FastX.API.Services.Interfaces;
using FastX.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FastX.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Email and Password are required.";
                return View();
            }

            var token = await _userService.LoginAsync(email, password);
            var user = await _userService.GetUserByEmailAsync(email);

            if (token == null || user == null)
            {
                ViewBag.Error = "Invalid credentials.";
                return View();
            }

            HttpContext.Session.SetString("JWToken", token);
            HttpContext.Session.SetString("UserRole", user.Role);
            HttpContext.Session.SetString("UserEmail", user.Email);

            // ✅ Updated redirect for Operator
            return user.Role switch
            {
                "Admin" => RedirectToAction("Index", "Admin"),
                "Operator" => RedirectToAction("Index", "Operators"),
                _ => RedirectToAction("Index", "Home")
            };
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
