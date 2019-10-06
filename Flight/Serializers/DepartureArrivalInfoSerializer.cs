using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight.Serializers
{
    // Serializer
    public class DepartureArrivalInfoSerializer : IFlightSerializer
    {
        public string SerializeDateTimeFormat { get; set; } = "HH:mm, dd/MM/yyyy";

        public string Serialize(Flight flight)
        {
            string result = "";

            for (int i = 0; i < flight.Segments.Count; ++i)
            {
                result += $"Departure: " +
                    $"{flight.Segments[i].DepartureDate.ToString(SerializeDateTimeFormat)};" +
                    $" Arrival :" +
                    $" {flight.Segments[i].ArrivalDate.ToString(SerializeDateTimeFormat)};" +
                    $"\n";
            }

            return result;
        }
    }
}
