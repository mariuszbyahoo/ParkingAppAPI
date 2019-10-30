using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ParkingApp.API
{
    public class Slot : IComparable<Slot>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int PosX { get; set; }
        public int PosY { get; set; }
        public bool IsOccupied { get; set; }

        public int CompareTo( Slot other)
        {
            var comparisonResult = PosY.CompareTo(other.PosY);
            if (comparisonResult == 0)
                PosX.CompareTo(other.PosX);

           return comparisonResult;
        }
    }
}
