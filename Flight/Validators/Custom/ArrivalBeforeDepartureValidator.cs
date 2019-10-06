using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Validators.Custom
{
    public class ArrivalBeforeDepartureValidator : IFlightValidator
    {
        // 2. Have any segment with an arrival date before departure date
        public bool IsValid(Flight flight)
        {
            return flight.Segments.Any(seg => seg.ArrivalDate < seg.DepartureDate);
        }
    }
}
