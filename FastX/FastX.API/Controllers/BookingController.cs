using FastX.API.Services.Interfaces;
using FastX.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize(Roles = "User")]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService) => _bookingService = bookingService;

    [HttpPost("book")]
    public async Task<IActionResult> Book(Booking booking)
    {
        await _bookingService.BookAsync(booking);
        return Ok("Booking successful");
    }

    [HttpGet("details/{id}")]
    public async Task<IActionResult> GetBooking(int id)
    {
        var result = await _bookingService.GetBookingByIdAsync(id);
        return Ok(result);
    }
}
