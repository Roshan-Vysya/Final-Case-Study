using FastX.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RouteModel = FastX.DAL.Models.Route;

namespace FastX.MVC.Controllers
{
    public class RouteApiController : Controller
    {
        private readonly IRouteService _routeService;
        private readonly IBusService _busService;

        public RouteApiController(IRouteService routeService, IBusService busService)
        {
            _routeService = routeService;
            _busService = busService;
        }

        public async Task<IActionResult> Index()
        {
            var routes = await _routeService.GetAllRoutesAsync();
            return View(routes);
        }

        public async Task<IActionResult> Create()
        {
            var buses = await _busService.GetAllBusesAsync();
            ViewBag.BusList = new SelectList(buses, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RouteModel route)
        {
            if (!ModelState.IsValid)
            {
                var buses = await _busService.GetAllBusesAsync();
                ViewBag.BusList = new SelectList(buses, "Id", "Name");
                return View(route);
            }

            await _routeService.AddRouteAsync(route);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var route = await _routeService.GetByIdAsync(id);
            if (route == null) return NotFound();

            var buses = await _busService.GetAllBusesAsync();
            ViewBag.BusList = new SelectList(buses, "Id", "Name");
            return View(route);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RouteModel route)
        {
            if (id != route.Id)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                var buses = await _busService.GetAllBusesAsync();
                ViewBag.BusList = new SelectList(buses, "Id", "Name");
                return View(route);
            }

            await _routeService.UpdateRouteAsync(id, route);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _routeService.DeleteRouteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
