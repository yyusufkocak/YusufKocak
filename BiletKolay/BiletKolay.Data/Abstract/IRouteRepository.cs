using BiletKolay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletKolay.Data.Abstract
{
    public interface IRouteRepository : IRepository<Route>
    {
        Route GetRouteDetails(int id);
        string GetStartLocation(string startLocation);
        List<Route> GetRoute(string startLocation, string endLocation, DateTime Date);

        string GetEndLocation(string endLocation);
        
    }
}
