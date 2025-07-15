using FastX.API.Services.Interfaces;
using FastX.DAL.DataAccess.Interfaces;
using RouteModel = FastX.DAL.Models.Route;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FastX.API.Services.Implementations
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _routeRepository;

        public RouteService(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public async Task<IEnumerable<RouteModel>> GetAllRoutesAsync()
        {
            return await _routeRepository.GetAllAsync();
        }

        public async Task<RouteModel> GetByIdAsync(int id) // Added this
        {
            return await _routeRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<RouteModel>> SearchRoutesAsync(string origin, string destination, DateTime date)
        {
            return await _routeRepository.SearchRoutes(origin, destination, date);
        }

        public async Task AddRouteAsync(RouteModel route)
        {
            await _routeRepository.AddAsync(route);
            await _routeRepository.SaveAsync();
        }

        public async Task UpdateRouteAsync(int id, RouteModel route)
        {
            _routeRepository.Update(route);
            await _routeRepository.SaveAsync();
        }

        public async Task DeleteRouteAsync(int id)
        {
            var route = await _routeRepository.GetByIdAsync(id);
            if (route != null)
            {
                _routeRepository.Delete(route);
                await _routeRepository.SaveAsync();
            }
        }
    }
}
