using FastX.API.Services.Interfaces;
using FastX.DAL.DataAccess.Interfaces;
using FastX.DAL.Models;

namespace FastX.API.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;

        public BookingService(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync() => await _bookingRepo.GetAllAsync();

        public async Task<Booking> GetBookingByIdAsync(int id) => await _bookingRepo.GetByIdAsync(id);

        public async Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId)
            => await _bookingRepo.GetByUserIdAsync(userId);

        public async Task BookAsync(Booking booking) => await _bookingRepo.AddAsync(booking);

        public async Task CancelAsync(int bookingId)
        {
            var booking = await _bookingRepo.GetByIdAsync(bookingId);
            if (booking != null)
            {
                booking.IsCancelled = true;
                _bookingRepo.Update(booking);
            }
        }
    }
}
