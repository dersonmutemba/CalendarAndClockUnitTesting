namespace CalendarLibrary.Exceptions;

//
// Summary:
//      This exception represents letters passed as date elements exception
public class NonNumericFieldException : Exception
{
    //
    // Summary:
    //      Initializes a new instance of
    //      CalendarLibrary.Exceptions.NonNumericFieldException class
    //      with a specified message.
    //
    //  Parameters:
    //      message:
    //          The message that describes the error.
    public NonNumericFieldException(string message) : base(message) { }
}