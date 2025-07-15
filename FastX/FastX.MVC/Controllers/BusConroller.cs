using FastX.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FastX.DAL.Models;

namespace FastX.MVC.Controllers
{
    public class BusController : Controller
    {
        private readonly IBusService _busService;

        public BusController(IBusService busService)
        {
            _busService = busService;
        }

        public async Task<IActionResult> Index()
        {
            var buses = await _busService.GetAllBusesAsync();
            return View(buses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bus bus)
        {
            if (!ModelState.IsValid)
                return View(bus);

            await _busService.AddBusAsync(bus);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var bus = await _busService.GetByIdAsync(id);
            if (bus == null) return NotFound();
            return View(bus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Bus bus)
        {
            if (id != bus.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(bus);

            await _busService.UpdateBusAsync(id, bus);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _busService.DeleteBusAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
