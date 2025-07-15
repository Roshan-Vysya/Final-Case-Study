using FastX.DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastX.DAL.DataAccess.Interfaces
{
    public interface IRouteRepository
    {
        Task<IEnumerable<Route>> GetAllAsync();
        Task<Route?> GetByIdAsync(int id);
        Task<IEnumerable<Route>> SearchRoutes(string origin, string dest, DateTime date);
        Task AddAsync(Route route);
        void Update(Route route);
        void Delete(Route route);

        Task SaveAsync(); // ✅ Add this
    }
}
