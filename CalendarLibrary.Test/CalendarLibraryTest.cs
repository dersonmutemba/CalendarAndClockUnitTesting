using CalendarLibrary.Exceptions;

namespace CalendarLibrary.Test;

[TestClass]
public class CalendarLibraryTest
{
    [TestMethod]
    public void DatesDifference()
    {
        var actual = CalendarLibrary.Difference(new Date("10/10/2010"), new Date("11/10/2010"));
        var expected = 1;
        Assert.AreEqual(expected, actual);

        actual = CalendarLibrary.Difference(new Date("11/10/2010"), new Date("10/10/2010"));
        expected = 1;
        Assert.AreEqual(expected, actual);

        actual = CalendarLibrary.Difference(new Date("09/10/2010"), new Date("10/10/2010"));
        expected = 1;
        Assert.AreEqual(expected, actual);

        actual = CalendarLibrary.Difference(new Date("10/10/2011"), new Date("10/10/2010"));
        expected = 365;
        Assert.AreEqual(expected, actual);

        actual = CalendarLibrary.Difference(new Date("10/10/2015"), new Date("10/10/2010"));
        expected = 1826;
        Assert.AreEqual(expected, actual);

        actual = CalendarLibrary.Difference(new Date("10/02/2010"), new Date("10/10/2010"));
        expected = 242;
        Assert.AreEqual(expected, actual);

        actual = CalendarLibrary.Difference(new Date("10/10/2010"), new Date("10/10/2010"));
        expected = 0;
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void DatesAdd() {
        var actual = CalendarLibrary.Add(new Date("10/10/2010"), 2);
        var expected = new Date("12/10/2010");
        Assert.AreEqual(expected, actual);

        actual = CalendarLibrary.Add(new Date("10/10/2010"), 365);
        expected = new Date("10/10/2011");
        Assert.AreEqual(expected, actual);

        actual = CalendarLibrary.Add(new Date("10/10/2010"), 1826);
        expected = new Date("10/10/2015");
        Assert.AreEqual(expected, actual);

        actual = CalendarLibrary.Add(new Date("10/10/2010"), 0);
        expected = new Date("10/10/2010");
        Assert.AreEqual(expected, actual);

        actual = CalendarLibrary.Add(new Date("10/11/2010"), 25);
        expected = new Date("05/12/2010");
        Assert.AreEqual(expected, actual);


        actual = CalendarLibrary.Add(new Date("10/12/2010"), 25);
        expected = new Date("04/01/2011");
        Assert.AreEqual(expected, actual);

        Assert.ThrowsException<InvalidParameterException>(() => CalendarLibrary.Add(new Date("10/10/2010"), -1));
    }

    [TestMethod]
    public void DatesSubtract() {
        var actual = CalendarLibrary.Subtract(new Date("12/10/2010"), 2);
        var expected = new Date("10/10/2010");
        Assert.AreEqual(expected, actual);

        actual = CalendarLibrary.Subtract(new Date("10/10/2011"), 365);
        expected = new Date("10/10/2010");
        Assert.AreEqual(expected, actual);

        actual = CalendarLibrary.Subtract(new Date("10/10/2015"), 1826);
        expected = new Date("10/10/2010");
        Assert.AreEqual(expected, actual);

        actual = CalendarLibrary.Subtract(new Date("10/10/2010"), 0);
        expected = new Date("10/10/2010");
        Assert.AreEqual(expected, actual);

        actual = CalendarLibrary.Subtract(new Date("05/12/2010"), 25);
        expected = new Date("10/11/2010");
        Assert.AreEqual(expected, actual);


        actual = CalendarLibrary.Subtract(new Date("04/01/2011"), 25);
        expected = new Date("10/12/2010");
        Assert.AreEqual(expected, actual);

        Assert.ThrowsException<InvalidParameterException>(() => CalendarLibrary.Subtract(new Date("10/10/2010"), -1));
    }

    [TestMethod]
    public void IsLeapYear() {
        var actual = CalendarLibrary.IsLeap(new Date(1, 1, 2010));
        var expected = false;
        Assert.AreEqual(expected, actual);

        actual = CalendarLibrary.IsLeap(new Date(1, 1, 2000));
        expected = true;
        Assert.AreEqual(expected, actual);

        actual = CalendarLibrary.IsLeap(new Date(1, 1, 2020));
        expected = true;
        Assert.AreEqual(expected, actual);

        actual = CalendarLibrary.IsLeap(new Date(1, 1, 2100));
        expected = false;
        Assert.AreEqual(expected, actual);
    }
}