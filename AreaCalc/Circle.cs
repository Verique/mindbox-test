namespace AreaCalc;

/// <summary>
/// Class for representing a circle
/// </summary>
public sealed class Circle : IHasArea
{
    private readonly double _r;

    /// <summary>
    /// Circle constructor
    /// </summary>
    /// <param name="radius">Radius</param>
    /// <exception cref="ArgumentOutOfRangeException">Circle radius is negative or NaN</exception>
    public Circle(double radius)
    {
        if (double.IsNegative(radius) || double.IsNaN(radius))
            throw new ArgumentOutOfRangeException("Circle radius can't be negative or NaN");
        _r = radius;
    }

    /// <summary>
    /// Area of a circle
    /// </summary>
    public double Area => Math.PI * _r * _r;
}

