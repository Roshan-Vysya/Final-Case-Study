using FastX.API.Services.Interfaces;
using FastX.DAL.DataAccess.Interfaces;
using FastX.DAL.Models;

namespace FastX.API.Services.Implementations
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepo;

        public BusService(IBusRepository busRepo)
        {
            _busRepo = busRepo;
        }

        public async Task<IEnumerable<Bus>> GetAllBusesAsync() => await _busRepo.GetAllAsync();

        public async Task<Bus> GetByIdAsync(int id) => await _busRepo.GetByIdAsync(id);

        public async Task AddBusAsync(Bus bus) => await _busRepo.AddAsync(bus);

        public async Task UpdateBusAsync(int id, Bus updatedBus)
        {
            var bus = await _busRepo.GetByIdAsync(id);
            if (bus != null)
            {
                bus.Name = updatedBus.Name;
                bus.BusNumber = updatedBus.BusNumber;
                bus.Type = updatedBus.Type;
                bus.SeatCount = updatedBus.SeatCount;
                bus.Amenities = updatedBus.Amenities;
                _busRepo.Update(bus);
            }
        }

        public async Task DeleteBusAsync(int id)
        {
            var bus = await _busRepo.GetByIdAsync(id);
            if (bus != null) _busRepo.Delete(bus);
        }
    }
}
