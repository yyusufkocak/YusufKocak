using BiletKolay.Business.Abstract;
using BiletKolay.Data.Abstract;
using BiletKolay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletKolay.Business.Concrete
{
    public class RouteManager : IRouteService
    {
        private IRouteRepository _routeRepository;
        public RouteManager(IRouteRepository routeRepository)
        {
            _routeRepository = routeRepository;
        }
        public void Create(Route entity)
        {
            _routeRepository.Create(entity);
        }

        public void Delete(Route entity)
        {
            _routeRepository.Delete(entity);
        }

        public List<Route> GetAll()
        {
            return _routeRepository.GetAll();
        }

        public Route GetById(int id)
        {
            return _routeRepository.GetById(id);
        }

        public string GetEndLocation(string endLocation)
        {
            return _routeRepository.GetEndLocation(endLocation);
        }

        public List<Route> GetRoute(string startLocation, string endLocation, DateTime date)
        {
            return _routeRepository.GetRoute(startLocation, endLocation, date);
        }

        public Route GetRouteDetails(int id)
        {
            return _routeRepository.GetRouteDetails(id);
        }

        public string GetStartLocation(string startLocation)
        {
            return _routeRepository.GetStartLocation(startLocation);
        }

        public void Update(Route entity)
        {
            _routeRepository.Update(entity);
        }
    }
}
