using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Flight.Filters;
using Flight.Serializers;
using Flight.Validators.Custom;
using Flight.Writers;

namespace Flight
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get flights
            FlightBuilder builder = new FlightBuilder();

            List<Flight> flights = builder.GetFlights().ToList();

            // Craete flight writer
            IFlightWriter writer = new ConsoleFlightWriter();

            // Create flight serializer
            IFlightSerializer serializer = new DepartureArrivalInfoSerializer();

            // Create filters according to requests in the test
            List<IFlightFilter> filters = new List<IFlightFilter>()
            {
                new SingleConditionFilter(
                        new DepartedInPastValidator()
                    ),

                new SingleConditionFilter(
                    new ArrivalBeforeDepartureValidator()
                ),

                new SingleConditionFilter(
                    new TwoAndMoreHoursOnGroundValidator()
                ),
            };


            // Output the result
            for (int i = 0; i < filters.Count; ++i)
            {
                Console.WriteLine($"Answers to {i+1}.\n=======================================\n");
                foreach (var flight in filters[i].Filter(flights))
                {
                    writer.Output(flight, serializer);
                }
                Console.WriteLine("\n");
            }

            // Stop console
            Console.ReadKey();
        }
    }
}
