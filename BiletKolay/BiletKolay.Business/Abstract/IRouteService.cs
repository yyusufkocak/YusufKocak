using BiletKolay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletKolay.Business.Abstract
{
    public interface IRouteService
    {
        

        
        Route GetById(int id);
        void Create(Route entity);
        void Update(Route entity);
        void Delete(Route entity);

        List<Route> GetAll();
        string GetEndLocation(string endLocation);
        string GetStartLocation(string startLocation);
        List<Route> GetRoute(string startLocation, string endLocation, DateTime Date);
        Route GetRouteDetails(int id);

    }
}
