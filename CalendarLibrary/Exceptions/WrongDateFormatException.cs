namespace CalendarLibrary.Exceptions;

//
// Summary:
//      This exception represents dates passed in the wrong format
public class WrongDateFormatException : Exception
{
    //
    // Summary:
    //      Initializes a new instance of
    //      CalendarLibrary.Exceptions.WrongDateFormatException class
    //      with a specified message.
    //
    //  Parameters:
    //      message:
    //          The message that describes the error.
    public WrongDateFormatException(string message) : base(message) { }
}