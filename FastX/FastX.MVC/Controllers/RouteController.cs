using FastX.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RouteModel = FastX.DAL.Models.Route;

namespace FastX.MVC.Controllers
{
    public class RouteController : Controller
    {
        private readonly IRouteService _routeService;
        private readonly IBusService _busService;

        public RouteController(IRouteService routeService, IBusService busService)
        {
            _routeService = routeService;
            _busService = busService;
        }

        // View All Routes
        public async Task<IActionResult> Index()
        {
            var routes = await _routeService.GetAllRoutesAsync();
            return View(routes);
        }

        // GET: Create Route Page
        public async Task<IActionResult> Create()
        {
            var buses = await _busService.GetAllBusesAsync();
            ViewBag.BusList = new SelectList(buses, "Id", "Name");
            return View();
        }

        // POST: Create Route
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RouteModel route)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.BusList = new SelectList(await _busService.GetAllBusesAsync(), "Id", "Name");
                return View(route);
            }

            await _routeService.AddRouteAsync(route);
            return RedirectToAction(nameof(Index));
        }

        // GET: Edit Route
        public async Task<IActionResult> Edit(int id)
        {
            var route = await _routeService.GetByIdAsync(id);
            if (route == null)
                return NotFound();

            var buses = await _busService.GetAllBusesAsync();
            ViewBag.BusList = new SelectList(buses, "Id", "Name", route.BusId);
            return View(route); // This should match Views/Route/Edit.cshtml
        }

        // POST: Edit Route
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RouteModel route)
        {
            if (id != route.Id)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                ViewBag.BusList = new SelectList(await _busService.GetAllBusesAsync(), "Id", "Name", route.BusId);
                return View(route);
            }

            await _routeService.UpdateRouteAsync(id, route);
            return RedirectToAction(nameof(Index));
        }

        // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            await _routeService.DeleteRouteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
