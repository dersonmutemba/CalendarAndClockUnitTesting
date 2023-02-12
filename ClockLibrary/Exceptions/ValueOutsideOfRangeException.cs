namespace ClockLibrary.Exceptions;

public class ValueOutsideOfRangeException : Exception
{
    public ValueOutsideOfRangeException(string message) : base(message) { }
}