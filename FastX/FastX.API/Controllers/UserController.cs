using FastX.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize(Roles = "User")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IBookingService _bookingService;

    public UserController(IUserService userService, IBookingService bookingService)
    {
        _userService = userService;
        _bookingService = bookingService;
    }

    [HttpGet("profile")]
    public async Task<IActionResult> Profile()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);
        var user = await _userService.GetUserByEmailAsync(email);
        return Ok(user);
    }

    [HttpGet("bookings")]
    public async Task<IActionResult> MyBookings()
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var bookings = await _bookingService.GetBookingsByUserIdAsync(userId);
        return Ok(bookings);
    }

    [HttpDelete("cancel/{id}")]
    public async Task<IActionResult> CancelBooking(int id)
    {
        await _bookingService.CancelAsync(id);
        return Ok("Booking cancelled.");
    }
}
