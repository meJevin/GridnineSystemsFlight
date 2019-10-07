using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Validators.Custom
{
    // Validator for part 2 of the test: Have any segment with an arrival date before departure date
    public class ArrivalBeforeDepartureValidator : IFlightValidator
    {
        public bool Discard(Flight flight)
        {
            return flight.Segments.Any(seg => seg.ArrivalDate < seg.DepartureDate);
        }
    }
}
