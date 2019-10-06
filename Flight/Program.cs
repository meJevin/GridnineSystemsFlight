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
            ConsoleFlightWriter flightWriter = new ConsoleFlightWriter();

            // Create flight serializer
            DepartureArrivalInfoSerializer DAISeriziler = new DepartureArrivalInfoSerializer();

            // Create filters according to requests in the test
            SingleConditionFilter departBeforeCurrentTime =
                new SingleConditionFilter(
                    new DepartedInPastValidator()
                );

            SingleConditionFilter anySegmentArrivalBeforeDeparture =
                new SingleConditionFilter(
                    new ArrivalBeforeDepartureValidator()
                );

            SingleConditionFilter moreThanTwoHoursGroundTime =
                new SingleConditionFilter(
                    new TwoAndMoreHoursOnGroundValidator()
                );


            // Output the result

            Console.WriteLine("Answers to 1.\n=======================================");
            foreach (var flight in departBeforeCurrentTime.Filter(flights))
            {
                flightWriter.Output(flight, DAISeriziler);
            }
            Console.WriteLine();

            Console.WriteLine("Answers to 2.\n=======================================");
            foreach (var flight in anySegmentArrivalBeforeDeparture.Filter(flights))
            {
                flightWriter.Output(flight, DAISeriziler);
            }
            Console.WriteLine();

            Console.WriteLine("Answers to 3.\n=======================================");
            foreach (var flight in moreThanTwoHoursGroundTime.Filter(flights))
            {
                flightWriter.Output(flight, DAISeriziler);
            }
            Console.WriteLine();

            // Stop console
            Console.ReadKey();
        }
    }
}
