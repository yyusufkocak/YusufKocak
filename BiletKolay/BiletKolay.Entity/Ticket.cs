using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletKolay.Entity
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerNumber { get; set; }
        public string TravelFrom { get; set; }
        public string TravelTo { get; set; }
        public int SeatNumber { get; set; }
        public double Price { get; set; }
        public int RouteId { get; set; }
        public Route Route { get; set; }
    }
}
