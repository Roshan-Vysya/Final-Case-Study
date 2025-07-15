using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastX.API.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        [Authorize(Roles = "User")]
        public IActionResult User()
        {
            return View(); // Views/Dashboard/User.cshtml
        }

        [Authorize(Roles = "Admin,Operator")]
        public IActionResult Admin()
        {
            return View(); // Views/Dashboard/Admin.cshtml
        }
    }
}
