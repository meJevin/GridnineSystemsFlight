using Flight.Serializers;

namespace Flight.Writers
{
    public interface IFlightWriter
    {
        void Output(Flight flight, IFlightSerializer serializer);
    }
}
