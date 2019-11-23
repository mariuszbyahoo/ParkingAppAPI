using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ParkingApp.API
{
    public class Slot : IComparable<Slot>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public bool IsOccupied { get; set; } = false;
        public string desc { get; set; }

        public int CompareTo(Slot obj)
        {
            return ((IComparable)Id).CompareTo(obj.Id);
        }
    }
}
