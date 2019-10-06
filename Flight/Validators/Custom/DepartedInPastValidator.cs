using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Validators.Custom
{
    // Validator for part 1 of the test: Depart before current time
    public class DepartedInPastValidator : IFlightValidator
    {
        public bool IsValid(Flight flight)
        {
            return flight.Segments.Any(seg => seg.DepartureDate < DateTime.Now);
        }
    }
}
