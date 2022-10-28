using System;
using System.Collections.Generic;

namespace Travels.EFCore.Models
{
    public partial class Flight
    {
        public Flight()
        {
            Transports = new HashSet<Transport>();
        }

        public string Id { get; set; } = null!;
        public string Origin { get; set; } = null!;
        public string Destination { get; set; } = null!;
        public double Price { get; set; }

        public virtual ICollection<Transport> Transports { get; set; }
    }
}
