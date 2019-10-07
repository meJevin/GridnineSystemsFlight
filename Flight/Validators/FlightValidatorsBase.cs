
namespace Flight.Validators
{
    public interface IFlightValidator
    {
        // True if we want to discard the flight, false if we want to keep it
        bool Discard(Flight flight);
    }
}
