using FastX.DAL.Models;

namespace FastX.DAL.DataAccess.Interfaces
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<Booking> GetByIdAsync(int id);
        Task<IEnumerable<Booking>> GetByUserIdAsync(int userId);
        Task AddAsync(Booking booking);
        void Update(Booking booking);
        void Delete(Booking booking);
    }
}
