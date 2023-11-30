using System;
using NUnit.Framework;

namespace AreaCalc.Tests;

[TestFixture]
public class TriangleTests
{
    [Test]
    [TestCase(-3, 4, 5)]
    [TestCase(3, -4, 5)]
    [TestCase(3, 4, -5)]
    [TestCase(3, 4, double.NegativeInfinity)]
    [TestCase(3, 4, double.NaN)]
    public void Triangle_CreateIncorrectSides_ThrowsAnArgumentOutOfRangeException(double a, double b, double c)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(a, b, c));
    }
    [Test]
    [TestCase(3, 4, 8)]
    [TestCase(0, 4, 5)]
    [TestCase(double.PositiveInfinity, 4, 5)]
    public void Triangle_CreateInequalityViolatingSides_ThrowsAnArgumentException(double a, double b, double c)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(a, b, c));
    }

    [Test]
    [TestCase(3, 4, 6)]
    [TestCase(3, 4, 5)]
    [TestCase(10, 10, 10)]
    public void Triangle_CreateCorrectSides_DoesNotThrowAnException(double a, double b, double c)
    {
        Assert.DoesNotThrow(() => new Triangle(a, b, c));
    }

    [Test]
    [TestCase(3, 4, 5, true)]
    [TestCase(5, 12, 13, true)]
    [TestCase(3, 4, 6, false)]
    [TestCase(2, 3, 4, false)]
    [TestCase(10, 10, 10, false)]
    public void Triangle_CheckIfIsRight_ReturnsExpected(double a, double b, double c, bool expected)
    {
        var actual = new Triangle(a, b, c).IsRight;
        Assert.AreEqual(expected, actual);
    }

    [Test]
    [TestCase(3, 4, 5, 6)]
    [TestCase(5, 12, 13, 30)]
    [TestCase(3, 4, 6, 5.33268)]
    [TestCase(2, 3, 4, 2.90474)]
    [TestCase(10, 10, 10, 43.30127)]
    public void Triangle_CalculateArea_RetursExpected(double a, double b, double c, double expected)
    {
        var actual = new Triangle(a, b, c).Area;
        Assert.AreEqual(expected, actual, 0.00001);
    }
}
