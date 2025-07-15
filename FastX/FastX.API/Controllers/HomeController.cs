using Microsoft.AspNetCore.Mvc;

namespace FastX.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "FastX Dashboard";
            return View();
        }
    }
}
