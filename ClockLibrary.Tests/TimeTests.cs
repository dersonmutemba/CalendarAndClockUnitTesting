using ClockLibrary.Exceptions;

namespace ClockLibrary.Tests;

[TestClass]
public class TimeTests
{
    [TestMethod]
    public void ConstructorGenerateCorrectTime()
    {
        var time = new Time("00:00");
        var expected = 0;
        var actual = time.Hour;
        Assert.AreEqual(expected, actual);
        expected = 0;
        actual = time.Minute;
        Assert.AreEqual(expected, actual);

        time = new Time("00:30");
        expected = 0;
        actual = time.Hour;
        Assert.AreEqual(expected, actual);
        expected = 30;
        actual = time.Minute;
        Assert.AreEqual(expected, actual);

        time = new Time("05:00");
        expected = 5;
        actual = time.Hour;
        Assert.AreEqual(expected, actual);
        expected = 0;
        actual = time.Minute;
        Assert.AreEqual(expected, actual);

        time = new Time("10:30");
        expected = 10;
        actual = time.Hour;
        Assert.AreEqual(expected, actual);
        expected = 30;
        actual = time.Minute;
        Assert.AreEqual(expected, actual);

        time = new Time(0, 0);
        expected = 0;
        actual = time.Hour;
        Assert.AreEqual(expected, actual);
        expected = 0;
        actual = time.Minute;
        Assert.AreEqual(expected, actual);

        time = new Time(0, 30);
        expected = 0;
        actual = time.Hour;
        Assert.AreEqual(expected, actual);
        expected = 30;
        actual = time.Minute;
        Assert.AreEqual(expected, actual);

        time = new Time(5, 0);
        expected = 5;
        actual = time.Hour;
        Assert.AreEqual(expected, actual);
        expected = 0;
        actual = time.Minute;
        Assert.AreEqual(expected, actual);

        time = new Time(10, 30);
        expected = 10;
        actual = time.Hour;
        Assert.AreEqual(expected, actual);
        expected = 30;
        actual = time.Minute;
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ConstructorAcceptsValidTimeFormatOnly()
    {
        Assert.ThrowsException<WrongTimeFormatException>(() => new Time(""));
        Assert.ThrowsException<WrongTimeFormatException>(() => new Time("1"));
        Assert.ThrowsException<WrongTimeFormatException>(() => new Time("10 00"));
        Assert.ThrowsException<WrongTimeFormatException>(() => new Time("9:10:20"));
    }

    [TestMethod]
    public void AcceptsValuesBetweenRangeOnly()
    {
        var time = new Time(10, 10);
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => time.Minute = 60);
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => time.Minute = -1);
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => time.Minute = 90);
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => time.Minute = 100);
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => time.Hour = 24);
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => time.Hour = -1);
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => time.Hour = 60);
        Assert.ThrowsException<ValueOutsideOfRangeException>(() => time.Hour = 100);
    }

    [TestMethod]
    public void PropertiesUpdateCorrectly() {
        var time = new Time("0:0");
        time.Minute = 20;
        var actual = time.Minute;
        var expected = 20;
        Assert.AreEqual(expected, actual);

        time.Hour = 8;
        actual = time.Hour;
        expected = 8;
        Assert.AreEqual(expected, actual);

        time.Hour = 9;
        actual = time.Hour;
        expected = 9;
        Assert.AreEqual(expected, actual);

        time.Hour = 16;
        actual = time.Hour;
        expected = 16;
        Assert.AreEqual(expected, actual);

        time.Minute = 8;
        actual = time.Minute;
        expected = 8;
        Assert.AreEqual(expected, actual);

        time.Minute = 48;
        actual = time.Minute;
        expected = 48;
        Assert.AreEqual(expected, actual);
    }
}