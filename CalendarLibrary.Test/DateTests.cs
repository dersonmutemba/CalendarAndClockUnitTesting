using CalendarLibrary.Exceptions;

namespace CalendarLibrary.Test;

[TestClass]
public class DateTests
{
    [TestMethod]
    public void ValidDates()
    {
        var result = new Date("01/01/2001");
        Assert.AreEqual(1, result.Day);
        Assert.AreEqual(1, result.Month);
        Assert.AreEqual(2001, result.Year);
        result = new Date("31/12/2012");
        Assert.AreEqual(31, result.Day);
        Assert.AreEqual(12, result.Month);
        Assert.AreEqual(2012, result.Year);
        result = new Date(" 31 / 12 / 2012 ");
        Assert.AreEqual(31, result.Day);
        Assert.AreEqual(12, result.Month);
        Assert.AreEqual(2012, result.Year);
        result = new Date("1/1/2010");
        Assert.AreEqual(1, result.Day);
        Assert.AreEqual(1, result.Month);
        Assert.AreEqual(2010, result.Year);
        Assert.ThrowsException<WrongDateFormatException>(() => new Date(""));
        Assert.ThrowsException<WrongDateFormatException>(() => new Date("02/02/2020/20"));
        Assert.ThrowsException<NonNumericFieldException>(() => new Date("ab/01/2001"));
        Assert.ThrowsException<NonNumericFieldException>(() => new Date("01/ab/2001"));
        Assert.ThrowsException<NonNumericFieldException>(() => new Date("01//2001"));
        Assert.ThrowsException<NonNumericFieldException>(() => new Date("01/01/abcd"));
        Assert.ThrowsException<NonNumericFieldException>(() => new Date("ab/cd/efgh"));
        Assert.ThrowsException<WrongDateFormatException>(() => new Date("abcdefgh"));
        Assert.ThrowsException<WrongDateFormatException>(() => new Date("abcdefghij"));
    }

    [TestMethod]
    public void LeapYear()
    {
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => new Date("30/02/2012"));
        var result = new Date("02/02/2000");
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => result.Day = 30);
        result.Day = 29;
        Assert.AreEqual(29, result.Day);
        result = new Date("02/02/2001");
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => result.Day = 29);
    }

    [TestMethod]
    public void ValidRange()
    {
        var result = new Date("31/12/2012");
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => new Date("31/04/2012"));
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => result.Month = -1);
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => result.Month = 13);
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => result.Month = 0);
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => result.Day = -1);
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => result.Day = 0);
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => result.Day = 32);
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => result.Year = -1);
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => result.Year = 999);
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => result.Year = 3000);
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => new Date("00/01/2001"));
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => new Date("32/01/2001"));
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => new Date("01/00/2001"));
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => new Date("01/13/2001"));
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => new Date("01/01/0999"));
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => new Date("01/01/3000"));
    }
}