using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.API.Ticket
{
    public interface ITicketFactory
    {
        public string GenerateTicket(int posX, int posY);
    }
}
