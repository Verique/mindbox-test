namespace AreaCalc;

/// <summary>
/// Class for representing a triangle
/// </summary>
public sealed class Triangle : IHasArea
{
    private readonly double[] _sides;
    private readonly Func<double> _areaFunc;

    /// <summary>
    /// Triangle constructor
    /// </summary>
    /// <param name="a">first side</param>
    /// <param name="b">second side</param>
    /// <param name="c">third side</param>
    /// <exception cref="ArgumentOutOfRangeException">Side length is negative or NaN</exception>
    /// <exception cref="ArgumentException">Triangle inequality is not met</exception>
    public Triangle(double a, double b, double c)
    {
        _sides = new[] { a, b, c }.OrderBy(x => x).ToArray();

        if (_sides.Any(x => double.IsNaN(x) || double.IsNegative(x)))
            throw new ArgumentOutOfRangeException("Side length can't be negative or NaN");
        if (a + b < c || a + c < b || b + c < a)
            throw new ArgumentException("Impossible triangle");

        _areaFunc = IsRight ? RightTriangle : Heron;
    }

    /// <summary>
    /// Returns true if the triangle is right
    /// </summary>
    public bool IsRight => _sides[2] * _sides[2] == _sides[1] * _sides[1] + _sides[0] * _sides[0];

    /// <summary>
    /// Area of a circle
    /// </summary>
    public double Area => _areaFunc();

    private double RightTriangle() => (_sides[1] * _sides[0]) / 2;

    private double Heron()
    {
        var semiPerimeter = _sides.Sum() / 2;
        var coeffs = _sides
            .Select(x => semiPerimeter - x)
            .Append(semiPerimeter);
        return Math.Sqrt(coeffs.Aggregate(1d, (x, y) => x * y));
    }
}

