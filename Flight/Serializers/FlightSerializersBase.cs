using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Serializers
{
    // This interface simply transforms flight data into a string
    // For JSON, XML, human-readable and other formats
    public interface IFlightSerializer
    {
        string Serialize(Flight flight);
    }
}
