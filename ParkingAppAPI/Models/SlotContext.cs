using Microsoft.EntityFrameworkCore;
using ParkingApp.API.Ticket;

namespace ParkingApp.API.Models
{
    public class SlotContext : DbContext
    {
        public ITicketFactory ticketFactory;
        public DbSet<Slot> slots { get; set; }
        public SlotContext(DbContextOptions<SlotContext> options) : base(options)
        {
            ticketFactory = new TicketFactory(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Slot>().HasData(new Slot() { posX = 0, posY = 0, IsOccupied = false });
            modelBuilder.Entity<Slot>().HasData(new Slot() { posX = 0, posY = 1, IsOccupied = false});
            modelBuilder.Entity<Slot>().HasData(new Slot() { posX = 0, posY = 2, IsOccupied = false });
            modelBuilder.Entity<Slot>().HasData(new Slot() { posX = 0, posY = 3, IsOccupied = false });
            modelBuilder.Entity<Slot>().HasData(new Slot() { posX = 0, posY = 4, IsOccupied = false });
        }
    }
}
