using BiletKolay.Data.Abstract;
using BiletKolay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletKolay.Data.Concrete.EfCore
{
    public class EfCoreTicketRepository : EfCoreGenericRepository<Ticket, BiletKolayContext>, ITicketRepository
    {
        public string GetDate(int routeid)
        {
            using (var context = new BiletKolayContext())
            {
                var ticketDate = context
                    .Routes
                    .Where(i => i.RouteId == routeid)
                    .Select(i => i.Date)
                    .FirstOrDefault();

                return ticketDate;
            }
        }

        public string GetTime(int routeid)
        {
            using (var context = new BiletKolayContext())
            {
                var ticketTime = context.Routes
                    .Where(i => i.RouteId == routeid)
                    .Select(i => i.Time)
                    .FirstOrDefault();

                return ticketTime;
            }
        }

        public int GetId()
        {
            using (var context = new BiletKolayContext())
            {
                var id = context.Tickets
                    .OrderByDescending(i => i.TicketId)
                    .Select(i => i.RouteId)
                    .FirstOrDefault();
                return id;
            }
        }

        public Ticket GetLastTicket()
        {
            using (var context = new BiletKolayContext())
            {
                var lastTicket = context.Tickets
                    .OrderByDescending(i => i.TicketId)
                    .FirstOrDefault();
                return lastTicket;
            }
        }

        public List<int> GetSeat(int routeId)
        {
            using (var context = new BiletKolayContext())
            {
                var seat = context.Tickets
                    .Where(i => i.RouteId == routeId)
                    .Select(i => i.SeatNumber)
                    .ToList();

                return seat;
            }
        }

        public int GetSeatNumber(int routeId)
        {
            using (var context = new BiletKolayContext())
            {
                return context.Tickets
                    .Where(i => i.RouteId == routeId)
                    .Select(i => i.SeatNumber)
                    .Count();
            }
        }
    }
}
