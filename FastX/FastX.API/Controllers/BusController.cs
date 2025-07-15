using FastX.API.Services.Interfaces;
using FastX.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize(Roles = "Admin,Operator")]
public class BusController : ControllerBase
{
    private readonly IBusService _busService;

    public BusController(IBusService busService) => _busService = busService;

    [HttpGet("all")]
    public async Task<IActionResult> GetAll() => Ok(await _busService.GetAllBusesAsync());

    [HttpPost("add")]
    public async Task<IActionResult> Add(Bus bus)
    {
        await _busService.AddBusAsync(bus);
        return Ok("Bus added");
    }

    [HttpPut("edit/{id}")]
    public async Task<IActionResult> Edit(int id, Bus bus)
    {
        await _busService.UpdateBusAsync(id, bus);
        return Ok("Bus updated");
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _busService.DeleteBusAsync(id);
        return Ok("Bus deleted");
    }
}
