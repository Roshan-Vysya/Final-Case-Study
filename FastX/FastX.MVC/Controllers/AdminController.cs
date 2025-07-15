using FastX.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FastX.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IRouteService _routeService;
        private readonly IBusService _busService;
        private readonly IUserService _userService;

        public AdminController(
            IBookingService bookingService,
            IRouteService routeService,
            IBusService busService,
            IUserService userService)
        {
            _bookingService = bookingService;
            _routeService = routeService;
            _busService = busService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            // Session-based authorization
            var role = HttpContext.Session.GetString("UserRole");
            if (string.IsNullOrEmpty(role) || role != "Admin")
                return RedirectToAction("Login", "Account");

            var bookings = await _bookingService.GetAllBookingsAsync();
            var routes = await _routeService.GetAllRoutesAsync();
            var buses = await _busService.GetAllBusesAsync();
            var operators = (await _userService.GetAllUsersAsync())
                            .Where(u => u.Role == "Operator")
                            .ToList();

            ViewBag.Bookings = bookings;
            ViewBag.Routes = routes;
            ViewBag.Buses = buses;
            ViewBag.Operators = operators;

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
