﻿using BiletKolay.Data.Abstract;
using BiletKolay.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletKolay.Data.Concrete.EfCore
{
    public class EfCoreRouteRepository : EfCoreGenericRepository<Route, BiletKolayContext>,IRouteRepository
    {
        public string GetEndLocation(string endLocation)
        {
            using (var context = new BiletKolayContext())
            {
                var end = context.Cities
                    .Where(i => i.CityId == Convert.ToInt32(endLocation))
                    .Select(i => i.CityName)
                    .ToList();
                return end[0];
            }
        }

        public List<Route> GetRoute(string startLocation, string endLocation, DateTime Date)
        {
            var dateTimeLocal = Date.ToString("yyyy-MM-dd");
            using (var context = new BiletKolayContext())
            {
                var start = context.Cities
                    .Where(i => i.CityId == Convert.ToInt32(startLocation))
                    .Select(i => i.CityName)
                    .ToList();

                var end = context.Cities
                    .Where(i => i.CityId == Convert.ToInt32(endLocation))
                    .Select(i => i.CityName)
                    .ToList();

                var routes = context.Routes
                    .FromSqlRaw($"Select * From Routes Where ((StartLocation='{start[0]}' or FirstStation='{start[0]}' or SecondStation='{start[0]}' or ThirdStation='{start[0]}' ) and (EndLocation='{end[0]}' or ThirdStation='{end[0]}' or SecondStation='{end[0]}' or FirstStation='{end[0]}' ) and Date='{dateTimeLocal}') ")
                    .ToList();

                return routes;
            }

        }


        public Route GetRouteDetails(int id)
        {
            using (var context = new BiletKolayContext())
            {
                return context.Routes
                    .Where(i => i.RouteId == id)
                    .AsNoTracking()
                    .FirstOrDefault();
            }
        }

        public string GetStartLocation(string startLocation)
        {
            using (var context = new BiletKolayContext())
            {
                var start = context.Cities
                    .Where(i => i.CityId == Convert.ToInt32(startLocation))
                    .Select(i => i.CityName)
                    .ToList();
                return start[0];
            }
        }
    }
}
