using FastX.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FastX.MVC.Controllers
{
    public class OperatorsController : Controller
    {
        private readonly IUserService _userService;

        public OperatorsController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var operators = (await _userService.GetAllUsersAsync())
                            .Where(u => u.Role == "Operator");
            return View(operators);
        }

        // other actions: Create, Edit etc...
    }
}
