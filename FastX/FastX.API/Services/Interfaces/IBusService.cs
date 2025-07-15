using FastX.DAL.Models;

namespace FastX.API.Services.Interfaces
{
    public interface IBusService
    {
        Task<IEnumerable<Bus>> GetAllBusesAsync();
        Task<Bus> GetByIdAsync(int id);
        Task AddBusAsync(Bus bus);
        Task UpdateBusAsync(int id, Bus updatedBus);
        Task DeleteBusAsync(int id);
    }
}
