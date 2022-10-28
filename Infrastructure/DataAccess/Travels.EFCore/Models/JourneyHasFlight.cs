using System;
using System.Collections.Generic;

namespace Travels.EFCore.Models
{
    public partial class JourneyHasFlight
    {
        public int? JourneyId { get; set; }
        public string? FlightId { get; set; }

        public virtual Flight? Flight { get; set; }
        public virtual Journey? Journey { get; set; }
    }
}
