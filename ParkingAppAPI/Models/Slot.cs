using System;
using System.ComponentModel.DataAnnotations;

namespace ParkingAppAPI
{
    public class Slot
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int posX { get; set; }
        public int posY { get; set; }
        public bool IsOccupied { get; set; }

    }
}
