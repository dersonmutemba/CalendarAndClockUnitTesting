namespace ClockLibrary.Exceptions;

public class NonNumericFieldException : Exception
{
    public NonNumericFieldException(string message) : base(message) { }
}