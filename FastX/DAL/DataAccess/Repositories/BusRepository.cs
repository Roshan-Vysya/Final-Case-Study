using FastX.DAL.Models;
using FastX.DAL.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastX.DAL.DataAccess.Repositories
{
    public class BusRepository : IBusRepository
    {
        private readonly FastXContext _context;

        public BusRepository(FastXContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Bus bus) => await _context.Buses.AddAsync(bus);

        public void Delete(Bus bus) => _context.Buses.Remove(bus);

        public async Task<IEnumerable<Bus>> GetAllAsync() => await _context.Buses.ToListAsync();

        public async Task<Bus> GetByIdAsync(int id) => await _context.Buses.FindAsync(id);

        public void Update(Bus bus) => _context.Buses.Update(bus);
    }
}
