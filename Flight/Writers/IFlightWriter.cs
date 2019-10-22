using Flight.Serializers;

namespace Flight.Writers
{
    /* 
     * This is an interface that is used to output flight info somewhere, or somehow
     * 
     * It could be a console, a UI component, a DB entry, a file or anything that requires output
     * 
     * Works in conjunction with an implementation of IFlightSerializer that optionally
     * serializes the input flight data
    */

    public interface IFlightWriter
    {
        void Output(Flight flight, IFlightSerializer serializer);
    }
}
