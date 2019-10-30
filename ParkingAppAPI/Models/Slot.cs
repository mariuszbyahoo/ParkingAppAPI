using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ParkingApp.API
{
    public class Slot : IComparable<Slot>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int posX { get; set; }
        public int posY { get; set; }
        public bool IsOccupied { get; set; }

        public int CompareTo( Slot other)
        {
            var comparisonResult = posY.CompareTo(other.posY);
            if (comparisonResult == 0)
                posX.CompareTo(other.posX);

           return comparisonResult;
        }
    }
}
