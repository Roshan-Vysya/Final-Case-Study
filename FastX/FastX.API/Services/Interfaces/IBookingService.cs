using FastX.DAL.Models;

namespace FastX.API.Services.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int id);
        Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId);
        Task BookAsync(Booking booking);
        Task CancelAsync(int bookingId);
    }
}
