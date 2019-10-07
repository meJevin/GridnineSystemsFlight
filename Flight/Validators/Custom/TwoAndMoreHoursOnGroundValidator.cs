using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Validators.Custom
{
    // Validator for part 3 of the test: Spend more than 2 hours on the ground
    public class TwoAndMoreHoursOnGroundValidator : IFlightValidator
    {
        public bool IsValid(Flight flight)
        {
            if (flight.Segments.Count < 2)
            {
                return false;
            }

            TimeSpan totalGroundTime = TimeSpan.Zero;

            for (int i = 0; i <= flight.Segments.Count - 2; ++i)
            {
                DateTime arrivalFirstSeg = flight.Segments[i].ArrivalDate;
                DateTime departureSecondSeg = flight.Segments[i + 1].DepartureDate;

                totalGroundTime = totalGroundTime.Add(departureSecondSeg.Subtract(arrivalFirstSeg));
            }

            return totalGroundTime.TotalHours > 2;
        }
    }
}
