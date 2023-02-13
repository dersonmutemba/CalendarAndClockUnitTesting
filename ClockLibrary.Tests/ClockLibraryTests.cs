using ClockLibrary.Exceptions;

namespace ClockLibrary.Tests;

[TestClass]
public class ClockLibraryTests
{
    [TestMethod]
    public void DifferenceBetweenTimes()
    {
        var expected = 2;
        var actual = ClockLibrary.Difference(new Time("10:00"), new Time("10:02"));
        Assert.AreEqual(expected, actual);

        expected = 2;
        actual = ClockLibrary.Difference(new Time("9:58"), new Time("10:00"));
        Assert.AreEqual(expected, actual);

        expected = 2;
        actual = ClockLibrary.Difference(new Time("9:59"), new Time("10:01"));
        Assert.AreEqual(expected, actual);

        expected = 100;
        actual = ClockLibrary.Difference(new Time("9:00"), new Time("10:40"));
        Assert.AreEqual(expected, actual);

        expected = 101;
        actual = ClockLibrary.Difference(new Time("10:02"), new Time("11:43"));
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void AddsMinutesCorrectly()
    {
        var expected = new Time("10:02");
        var actual = ClockLibrary.Add(new Time("10:00"), 2);
        Assert.AreEqual(expected, actual);

        expected = new Time("10:00");
        actual = ClockLibrary.Add(new Time("9:58"), 2);
        Assert.AreEqual(expected, actual);

        expected = new Time("12:00");
        actual = ClockLibrary.Add(new Time("10:00"), 26 * 60);
        Assert.AreEqual(expected, actual);

        expected = new Time("10:09");
        actual = ClockLibrary.Add(new Time("9:58"), 11);
        Assert.AreEqual(expected, actual);

        expected = new Time("10:00");
        actual = ClockLibrary.Add(new Time("10:00"), 0);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void SubtractsMinutesCorrectly()
    {
        var expected = new Time("10:00");
        var actual = ClockLibrary.Subtract(new Time("10:02"), 2);
        Assert.AreEqual(expected, actual);

        expected = new Time("9:58");
        actual = ClockLibrary.Subtract(new Time("10:00"), 2);
        Assert.AreEqual(expected, actual);

        expected = new Time("10:00");
        actual = ClockLibrary.Subtract(new Time("12:00"), 26 * 60);
        Assert.AreEqual(expected, actual);

        expected = new Time("9:58");
        actual = ClockLibrary.Subtract(new Time("10:09"), 11);
        Assert.AreEqual(expected, actual);

        expected = new Time("10:00");
        actual = ClockLibrary.Subtract(new Time("10:00"), 0);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void NegativeParameterThrowsException()
    {
        Assert.ThrowsException<InvalidParameterException>(() => ClockLibrary.Add(new Time("9:00"), -1));
        Assert.ThrowsException<InvalidParameterException>(() => ClockLibrary.Add(new Time("9:00"), -2));
        Assert.ThrowsException<InvalidParameterException>(() => ClockLibrary.Add(new Time("9:00"), -100));
        Assert.ThrowsException<InvalidParameterException>(() => ClockLibrary.Subtract(new Time("9:00"), -1));
        Assert.ThrowsException<InvalidParameterException>(() => ClockLibrary.Subtract(new Time("9:00"), -2));
        Assert.ThrowsException<InvalidParameterException>(() => ClockLibrary.Subtract(new Time("9:00"), -100));
    }
}