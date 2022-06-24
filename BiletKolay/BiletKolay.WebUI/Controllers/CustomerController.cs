using BiletKolay.Business.Abstract;
using BiletKolay.Entity;
using BiletKolay.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletKolay.WebUI.Controllers
{
    public class CustomerController:Controller
    {

        private IRouteService _routeService;
        private ITicketService _ticketService;

        public CustomerController(IRouteService routeService, ITicketService ticketService)
        {
            _routeService = routeService;
            _ticketService = ticketService;
        }
        public IActionResult Details(int id)
        {
            Route route = _routeService.GetRouteDetails(id);
            int seatNumber = _ticketService.GetSeatNumber(id);
            List<int> takenSeat = _ticketService.GetSeat(id);
            List<int> seatNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40 };


            foreach (var item in takenSeat)
            {
                seatNumbers.Remove(item);
            }

            ViewBag.SeatNumber = seatNumber;
            ViewBag.SeatNumbers = new SelectList(seatNumbers);

            if (route == null)
            {
                return NotFound();
            }
            else
            {

                return View(route);
            }

        }

        [HttpPost]
        public IActionResult Details(int routeId, double price, string startLocation, string endLocation, int seatNumber, string customerNumber, string customerMail, string firstName, string lastName)
        {
            Random rnd = new Random();
            int PrnNumber = rnd.Next();
            var entity = new Ticket()
            {
                CustomerName = firstName,
                CustomerSurname = lastName,
                CustomerNumber = customerNumber,
                TravelFrom = startLocation,
                TravelTo = endLocation,
                SeatNumber = seatNumber,
                Price = price,
                RouteId = routeId
            };

            _ticketService.Create(entity);
            return RedirectToAction("Details");
        }

        public IActionResult TicketDetails()
        {
            Ticket lastTicket = _ticketService.GetLastTicket();
            int routeId = _ticketService.GetId();
            string Time = _ticketService.GetTime(routeId);
            string Date = _ticketService.GetDate(routeId);

            var routeTicket = new RouteTicket()
            {
                Date = Date,
                Time = Time,
                Ticket = lastTicket
            };
            return View(routeTicket);
        }
    }
}
