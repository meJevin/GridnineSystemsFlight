using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Flight.Filters;
using Flight.Serializers;
using Flight.Validators;
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

            // Create filters according to requirements in the test
            IFlightFilter filters = new AllConditionsFilter(
                    new List<IFlightValidator>()
                    {
                        // Filter out those that departed in the past
                        new DepartedInPastValidator(),

                        // Arrived before deparutre
                        new ArrivalBeforeDepartureValidator(),

                        // Have 2+ hrs ground time
                        new TwoAndMoreHoursOnGroundValidator(),
                    }
                );

            // Print original flights
            Console.WriteLine($"Flights before filter:\n=======================================\n");
            foreach (var flight in flights)
            {
                writer.Output(flight, serializer);
            }
            Console.WriteLine("\n\n");

            // Output the result
            Console.WriteLine($"Flights after filter:\n=======================================\n");
            foreach (var flight in filters.FilterOut(flights))
            {
                writer.Output(flight, serializer);
            }
            Console.WriteLine("\n");

            // Stop console
            Console.ReadKey();
        }
    }
}
