using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAppAPI.Ticket
{
    public interface ITicketFactory
    {
        public string GenerateTicket(int posX, int posY);
    }
}
