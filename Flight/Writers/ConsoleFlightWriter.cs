using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Flight.Serializers;

namespace Flight.Writers
{
    // Writer
    class ConsoleFlightWriter : IFlightWriter
    {
        public void Output(Flight flight, IFlightSerializer serializer)
        {
            Console.WriteLine(serializer.Serialize(flight));
        }
    }
}
