using Microsoft.EntityFrameworkCore;

namespace ParkingAppAPI.Models
{
    public class SlotContext : DbContext
    {
        public DbSet<Slot> slots { get; set; }
        public SlotContext(DbContextOptions<SlotContext> options) : base(options)
        {

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
