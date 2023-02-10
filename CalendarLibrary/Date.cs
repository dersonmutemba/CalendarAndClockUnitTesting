using CalendarLibrary.Exceptions;

namespace CalendarLibrary;

public class Date
{
    public Date(string date)
    {
        while (date.Contains(' '))
        {
            date.Remove(date.IndexOf(' '));
        }
        var dateItems = date.Split('/');
        if (dateItems.Length != 3)
            throw new WrongDateFormatException("Error! Date format must be dd/mm/yyyy.");
        try
        {
            int day = int.Parse(dateItems[0]);
            int month = int.Parse(dateItems[1]);
            int year = int.Parse(dateItems[2]);
            GenerateDate(day, month, year);
        }
        catch (FormatException)
        {
            throw new NonNumericFieldException("Error! Fields must be integer numbers.");
        }
    }

    public Date(int day, int month, int year) => GenerateDate(day, month, year);

    private void GenerateDate(int day, int month, int year)
    {
        Year = year;
        Month = month;
        Day = day;
    }

    public bool isBefore(Date date)
    {
        if ((date.Day > Day && date.Month >= Month && date.Year >= Year) ||
            (date.Month > Month && date.Year >= Year) ||
            date.Year > Year)
        {
            return true;
        }
        return false;
    }

    // override object.Equals
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        if (Day == ((Date)obj).Day && Month == ((Date)obj).Month && Year == ((Date)obj).Year)
            return true;

        return false;
    }

    private bool _leapYear;
    private int _year;
    private int _month;
    private int _day;

    public int Day
    {
        get => _day;
        set
        {
            if (value >= 1 && value <= _daysInMonth[Month - 1])
                _day = value;
            else
                throw new ValueOutsideOfRangeException($"Error! Day should be between 1 and {_daysInMonth[Month - 1]}");
        }
    }

    public int Month
    {
        get => _month;
        set
        {
            if (value >= 1 && value <= 12)
                _month = value;
            else
                throw new ValueOutsideOfRangeException("Error! Month should be between 1 and 12");
        }
    }

    public int Year
    {
        get => _year;
        set
        {
            if (value % 4 == 0 && value % 100 != 0)
                _leapYear = true;
            else if (value % 400 == 0)
                _leapYear = true;
            else
                _leapYear = false;
            if (_leapYear)
                _daysInMonth[1] = 29;
            else
                _daysInMonth[1] = 28;
            if (value >= 1000 && value < 3000)
                _year = value;
            else
                throw new ValueOutsideOfRangeException("Error! Year should be between 1000 and 2999");
        }
    }

    internal int[] _daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    internal bool leapYear { get => _leapYear; }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}