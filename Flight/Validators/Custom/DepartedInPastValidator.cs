using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Validators.Custom
{
    public class DepartedInPastValidator : IFlightValidator
    {
        // 1. Depart before current time
        public bool IsValid(Flight flight)
        {
            return flight.Segments.Any(seg => seg.DepartureDate < DateTime.Now);
        }
    }
}
