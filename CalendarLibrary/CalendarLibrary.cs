using CalendarLibrary.Exceptions;

namespace CalendarLibrary;

public class CalendarLibrary
{
    public static int Difference(Date date1, Date date2)
    {
        int difference = 0;
        if (date1.isBefore(date2))
        {
            var aux = date1;
            date1 = date2;
            date2 = aux;
        }
        while (date1.Month != date2.Month || date1.Year != date2.Year)
        {
            if (date2.Month != 12)
            {
                difference += date2._daysInMonth[date2.Month - 1];
                date2.Month++;
            }
            else
            {
                difference += date2._daysInMonth[date2.Month - 1];
                date2.Month = 1;
                date2.Year++;
            }
        }
        difference += date1.Day - date2.Day;
        return Math.Abs(difference);
    }

    public static Date Add(Date date, int days)
    {
        if (days < 0)
            throw new InvalidParameterException("Parameter should be a positive integer");
        Date newDate = new Date(date.Day, date.Month, date.Year);
        while (days >= 366)
        {
            newDate.Year++;
            if (newDate.Month > 2)
            {
                if ((new Date(1, 1, newDate.Year + 1)).leapYear)
                {
                    days -= 366;
                }
                else
                {
                    days -= 365;
                }
            }
            else
            {
                if (newDate.leapYear)
                {
                    days -= 366;
                }
                else
                {
                    days -= 365;
                }
            }
        }
        while (days >= newDate._daysInMonth[newDate.Month - 1])
        {
            days -= newDate._daysInMonth[newDate.Month - 1];
            if (newDate.Month == 12)
            {
                newDate.Month = 1;
                newDate.Year++;
            }
            else
            {
                newDate.Month++;
            }
        }
        while (days + newDate.Day > newDate._daysInMonth[newDate.Month - 1])
        {

            newDate.Day = newDate.Day - newDate._daysInMonth[newDate.Month - 1] + days;
            if (newDate.Month == 12)
            {
                newDate.Month = 1;
                newDate.Year++;
            }
            else
            {
                newDate.Month++;
            }
            days = 0;
        }
        newDate.Day += days;
        return newDate;
    }

    public static Date Subtract(Date date, int days)
    {
        if (days < 0)
            throw new InvalidParameterException("Parameter should be a positive integer");
        Date newDate = new Date(date.Day, date.Month, date.Year);
        while (days >= 366)
        {
            newDate.Year--;
            if (newDate.Month > 2)
            {
                if ((new Date(1, 1, newDate.Year + 1)).leapYear)
                {
                    days -= 366;
                }
                else
                {
                    days -= 365;
                }
            }
            else
            {
                if (newDate.leapYear)
                {
                    days -= 366;
                }
                else
                {
                    days -= 365;
                }
            }
        }
        while (days >= newDate._daysInMonth[newDate.Month - 1])
        {
            days -= newDate._daysInMonth[newDate.Month - 1];
            if (newDate.Month == 1)
            {
                newDate.Month = 12;
                newDate.Year--;
            }
            else
            {
                newDate.Month--;
            }
        }
        while (newDate.Day - days < 1)
        {

            if (newDate.Month == 1)
            {
                newDate.Month = 12;
                newDate.Year--;
            }
            else
            {
                newDate.Month--;
            }
            newDate.Day = newDate._daysInMonth[newDate.Month - 1] + newDate.Day - days;
            days = 0;
        }
        newDate.Day -= days;
        return newDate;
    }

    public static bool IsLeap(Date date)
    {
        return date.leapYear;
    }
}
