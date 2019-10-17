using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingAppAPI.Models
{
    public class SlotContext : DbContext
    {
        public SlotContext(DbContextOptions<SlotContext> options) : base(options)
        {

        }

        public DbSet<Slot> slots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Slot>().HasData(
                    new Slot()) ;
        }
    }
}
