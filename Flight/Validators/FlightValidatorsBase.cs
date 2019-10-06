
namespace Flight.Validators
{
    /*
     * IFlightValidator is used to identify flights that satisfy a certain condition
     * that is specified by the person implementing this interface
     * 
     * Check Filters folder for more
    */

    public interface IFlightValidator
    {
        bool IsValid(Flight flight);
    }
}
