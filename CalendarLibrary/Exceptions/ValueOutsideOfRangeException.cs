namespace CalendarLibrary.Exceptions;

//
// Summary:
//      This exception represents passed parameter outside of the range
public class ValueOutsideOfRangeException : Exception
{
    //
    // Summary:
    //      Initializes a new instance of
    //      CalendarLibrary.Exceptions.ValueOutsideOfRangeException class
    //      with a specified message.
    //
    //  Parameters:
    //      message:
    //          The message that describes the error.
    public ValueOutsideOfRangeException(string message) : base(message) { }
}