using ClockLibrary.Exceptions;

namespace ClockLibrary;

public class Time
{
    public Time(string time)
    {
        while (time.Contains(' '))
        {
            time = time.Remove(time.IndexOf(' '), 1);
        }
        var timeItems = time.Split(':');
        if (timeItems.Length != 2)
            throw new WrongTimeFormatException("Error! Time format must be hh:mm.");
        try
        {
            int hour = int.Parse(timeItems[0]);
            int minute = int.Parse(timeItems[1]);
            GenerateTime(hour, minute);
        }
        catch (FormatException)
        {
            throw new NonNumericFieldException("Error! Fields must be integer numbers.");
        }
    }

    public Time(int hour, int minute)
    {
        GenerateTime(hour, minute);
    }

    private void GenerateTime(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
    }

    private int _hour;
    private int _minute;

    public int Hour
    {
        get => _hour;
        set
        {
            if (value < 0 || value >= 24)
            {
                throw new ValueOutsideOfRangeException("Error! Hour must be between 0 and 23.");
            }
            _hour = value;
        }
    }

    public int Minute
    {
        get => _minute;
        set
        {
            if (value < 0 || value >= 60)
            {
                throw new ValueOutsideOfRangeException("Error. Minute must be between 0 and 59.");
            }
            _minute = value;
        }
    }
}