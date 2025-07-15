using FastX.DAL.Models;
using FastX.DAL.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FastX.DAL.DataAccess.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        private readonly FastXContext _context;

        public RouteRepository(FastXContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Route route) => await _context.Routes.AddAsync(route);

        public void Delete(Route route) => _context.Routes.Remove(route);

        public async Task<IEnumerable<Route>> GetAllAsync() => await _context.Routes.Include(r => r.Bus).ToListAsync();

        public async Task<Route> GetByIdAsync(int id) => await _context.Routes.FindAsync(id);

        public async Task<IEnumerable<Route>> SearchRoutes(string origin, string dest, DateTime date)
        {
            return await _context.Routes
                .Include(r => r.Bus)
                .Where(r =>
                    r.Origin.ToLower() == origin.ToLower() &&
                    r.Destination.ToLower() == dest.ToLower() &&
                    r.DepartureTime.Date == date.Date)
                .ToListAsync();
        }

        public void Update(Route route) => _context.Routes.Update(route);

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
