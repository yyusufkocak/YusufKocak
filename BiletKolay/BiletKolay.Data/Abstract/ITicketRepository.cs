using BiletKolay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiletKolay.Data.Abstract
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        int GetSeatNumber(int routeId);
        List<int> GetSeat(int routeId);
        int GetId();
        string GetDate(int routeid);
        string GetTime(int routeid);
        Ticket GetLastTicket();

    }
}
