using Microsoft.EntityFrameworkCore;
using ParkingApp.API.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.API.Models
{
    public class SlotContext : DbContext
    {
        public ITicketFactory ticketFactory;
        public DbSet<Slot> Slots { get; set; }
        public SlotContext(DbContextOptions<SlotContext> options) : base(options)
        {
            ticketFactory = new TicketFactory(this);
        }

        public IEnumerable<Slot> AllSlots()
        {
            var list = Slots.ToListAsync().Result;
            return list;
        }
    }
}
