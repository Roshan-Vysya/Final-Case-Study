using FastX.DAL.Models;
using FastX.DAL.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastX.DAL.DataAccess.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly FastXContext _context;

        public BookingRepository(FastXContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Booking booking) => await _context.Bookings.AddAsync(booking);

        public void Delete(Booking booking) => _context.Bookings.Remove(booking);

        public async Task<IEnumerable<Booking>> GetAllAsync()
            => await _context.Bookings.Include(b => b.Route).ThenInclude(r => r.Bus).Include(b => b.User).ToListAsync();

        public async Task<Booking> GetByIdAsync(int id)
            => await _context.Bookings.Include(b => b.Route).Include(b => b.User).FirstOrDefaultAsync(b => b.Id == id);

        public async Task<IEnumerable<Booking>> GetByUserIdAsync(int userId)
            => await _context.Bookings
                .Include(b => b.Route).ThenInclude(r => r.Bus)
                .Where(b => b.UserId == userId)
                .ToListAsync();

        public void Update(Booking booking) => _context.Bookings.Update(booking);
    }
}
