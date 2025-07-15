using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RouteModel = FastX.DAL.Models.Route;

namespace FastX.API.Services.Interfaces
{
    public interface IRouteService
    {
        Task<IEnumerable<RouteModel>> GetAllRoutesAsync();
        Task<RouteModel> GetByIdAsync(int id); // Fixed method
        Task<IEnumerable<RouteModel>> SearchRoutesAsync(string origin, string destination, DateTime date);
        Task AddRouteAsync(RouteModel route);
        Task UpdateRouteAsync(int id, RouteModel route);
        Task DeleteRouteAsync(int id);
    }
}
