using FastX.API.Services.Interfaces;
using FastX.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastX.MVC.Controllers
{
    public class OperatorController : Controller
    {
        private readonly IUserService _userService;

        public OperatorController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var operators = (await _userService.GetAllUsersAsync())
                            .Where(u => u.Role == "Operator");
            return View(operators);
        }

        public IActionResult Create()
        {
            return View(new User { Role = "Operator" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            user.Role = "Operator";
            await _userService.RegisterUserAsync(user);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null || user.Role != "Operator") return NotFound();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.Id) return BadRequest();
            if (!ModelState.IsValid) return View(user);

            await _userService.UpdateUserAsync(id, user);
            return RedirectToAction(nameof(Index));
        }
    }
}
