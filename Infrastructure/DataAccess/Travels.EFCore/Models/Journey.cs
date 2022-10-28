using System;
using System.Collections.Generic;

namespace Travels.EFCore.Models
{
    public partial class Journey
    {
        public int Id { get; set; }
        public string Origin { get; set; } = null!;
        public string Destination { get; set; } = null!;
        public double Price { get; set; }
    }
}
