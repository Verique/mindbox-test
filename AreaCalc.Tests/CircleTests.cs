using System;
using NUnit.Framework;

namespace AreaCalc.Tests;

[TestFixture]
public class CircleTests
{
    [Test]
    [TestCase(-1)]
    [TestCase(double.NegativeInfinity)]
    [TestCase(double.NaN)]
    public void Circle_CreateIncorrectRadius_ThrowsAnArgumentOutOfRangeException(double radius)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(radius));
    }

    [Test]
    [TestCase(0)]
    [TestCase(0.001)]
    [TestCase(5)]
    [TestCase(double.PositiveInfinity)]
    public void Circle_CreateWithCorrectRadius_DoesNotThrowAnException(double radius)
    {
        Assert.DoesNotThrow(() => new Circle(radius));
    }

    [Test]
    [TestCase(0, 0)]
    [TestCase(0.001, 0.00000314159)]
    [TestCase(5, 78.539816)]
    [TestCase(double.PositiveInfinity, double.PositiveInfinity)]
    public void Circle_CalculateArea_ReturnsExpected(double radius, double expected)
    {
        var actual = new Circle(radius).Area;
        Assert.AreEqual(expected, actual, 0.00001);
    }
}