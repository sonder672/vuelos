using System;
using System.Collections.Generic;

namespace Travels.EFCore.Models
{
    public partial class Transport
    {
        public int Id { get; set; }
        public string FlightCarrier { get; set; } = null!;
        public string? FlightNumber { get; set; }

        public virtual Flight? FlightNumberNavigation { get; set; }
    }
}
