namespace CalendarLibrary.Exceptions;

public class InvalidParameterException : Exception
{
    public InvalidParameterException(string message) : base(message) { }
}