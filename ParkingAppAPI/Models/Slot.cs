using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ParkingApp.API
{
    public class Slot
    { 
        public Guid Id { get; set; } = Guid.NewGuid();

        public bool IsOccupied { get; set; } = false;

    }
}
