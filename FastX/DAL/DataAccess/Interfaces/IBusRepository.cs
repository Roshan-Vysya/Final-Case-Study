using FastX.DAL.Models;

namespace FastX.DAL.DataAccess.Interfaces
{
    public interface IBusRepository
    {
        Task<IEnumerable<Bus>> GetAllAsync();
        Task<Bus> GetByIdAsync(int id);
        Task AddAsync(Bus bus);
        void Update(Bus bus);
        void Delete(Bus bus);
    }
}
