using FastX.API.DTOs;
using FastX.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RouteModel = FastX.DAL.Models.Route;

namespace FastX.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet("search")]
        [Authorize]
        public async Task<IActionResult> SearchRoutes(string origin, string dest, DateTime date)
        {
            var routes = await _routeService.SearchRoutesAsync(origin, dest, date);

            var result = routes.Select(r => new RouteResponseDto
            {
                Id = r.Id,
                Origin = r.Origin,
                Destination = r.Destination,
                DepartureTime = r.DepartureTime,
                ArrivalTime = r.ArrivalTime,
                Fare = r.Fare,
                BusName = r.Bus?.Name
            });

            return Ok(result);
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin,Operator")]
        public async Task<IActionResult> AddRoute([FromBody] RouteModel request)
        {
            await _routeService.AddRouteAsync(request);
            return Ok("Route added successfully.");
        }

        [HttpPut("update/{id}")]
        [Authorize(Roles = "Admin,Operator")]
        public async Task<IActionResult> UpdateRoute(int id, [FromBody] RouteModel request)
        {
            await _routeService.UpdateRouteAsync(id, request); // ✅ fixed
            return Ok("Route updated successfully.");
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Admin,Operator")]
        public async Task<IActionResult> DeleteRoute(int id)
        {
            await _routeService.DeleteRouteAsync(id);
            return Ok("Route deleted successfully.");
        }
    }
}
