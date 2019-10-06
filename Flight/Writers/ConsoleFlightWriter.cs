using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Flight.Serializers;

namespace Flight.Writers
{
    /* 
     * My implementation of IFlightWriter for console that utilizes IFlightSerializer
     * in order to retrieve serialized data from a flight
    */

    public class ConsoleFlightWriter : IFlightWriter
    {
        public void Output(Flight flight, IFlightSerializer serializer)
        {
            Console.WriteLine(serializer.Serialize(flight));
            Console.WriteLine("-----------------------------------");
        }
    }
}
