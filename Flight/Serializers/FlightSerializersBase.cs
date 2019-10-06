using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Serializers
{
    public interface IFlightSerializer
    {
        string Serialize(Flight flight);
    }
}
