namespace ClockLibrary.Exceptions;

public class WrongTimeFormatException : Exception
{
    public WrongTimeFormatException(string message) : base(message)
    {

    }
}