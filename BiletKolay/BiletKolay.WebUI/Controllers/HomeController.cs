using BiletKolay.Business.Abstract;
using BiletKolay.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BiletKolay.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ICityService _cityService;
        private IRouteService _routeService;

        public HomeController(ICityService cityService, IRouteService routeService)
        {
            _cityService = cityService;
            _routeService = routeService;
        }

        public IActionResult Index(string startLocation, string endLocation, DateTime Date)
        {

            if (startLocation == null || endLocation == null || startLocation == endLocation)
            {
                var cityModel = new RouteTicket()
                {
                    Cities = _cityService.GetAll(),
                    Routes = null
                };

                ViewBag.Cities = new SelectList(cityModel.Cities, "CityId", "CityName");
                return View(cityModel);
            }
            else
            {
                var cityModel = new RouteTicket()
                {
                    Cities = _cityService.GetAll(),
                    Routes = _routeService.GetRoute(startLocation, endLocation, Date)
                };

                TempData["startLocation"] = _routeService.GetStartLocation(startLocation);
                TempData["endLocation"] = _routeService.GetEndLocation(endLocation);
                ViewBag.Cities = new SelectList(cityModel.Cities, "CityId", "CityName");
                return View(cityModel);
            }

        }

    }
}

