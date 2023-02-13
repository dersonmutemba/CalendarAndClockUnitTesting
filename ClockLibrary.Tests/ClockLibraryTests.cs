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
        
    }
}