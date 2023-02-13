using ClockLibrary.Exceptions;

namespace ClockLibrary;

public class ClockLibrary
{
    public static int Difference(Time time1, Time time2)
    {
        return Math.Abs(time1.Hour * 60 + time1.Minute - time2.Hour * 60 - time2.Minute);
    }

    public static Time Add(Time time, int minutes)
    {
        if (minutes < 0)
            throw new InvalidParameterException("Error! Minutes must be positive.");
        Time newTime = new Time(time.Hour, time.Minute);
        int hour = minutes / 60;
        int minute = minutes % 60;
        if (newTime.Minute + minute > 59)
        {
            hour++;
            newTime.Minute = (newTime.Minute + minute) % 60;
        }
        else
        {
            newTime.Minute += minute;
        }
        newTime.Hour = (newTime.Hour + hour) % 24;
        return newTime;
    }

    public static Time Subtract(Time time, int minutes)
    {
        if (minutes < 0)
            throw new InvalidParameterException("Error! Minutes must be positive.");
        Time newTime = new Time(time.Hour, time.Minute);
        int hour = minutes / 60;
        int minute = minutes % 60;
        if (newTime.Minute - minute < 0)
        {
            hour++;
            newTime.Minute = 60 + newTime.Minute - minute;
        }
        else
        {
            newTime.Minute -= minute;
        }
        hour = hour % 24;
        newTime.Hour = newTime.Hour - hour;
        return newTime;
    }
}