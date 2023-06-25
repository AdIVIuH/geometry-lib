// ReSharper disable once CheckNamespace
namespace GeometryLib;

/// <summary>
///     Represents a point in 2D space
/// </summary>
[Serializable]
public struct Point : IEquatable<Point>
{
    /// <summary>
    ///     Constructor of current type
    /// </summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; }
    public double Y { get; }

    public static bool operator ==(Point first, Point second) => first.Equals(second);
    public static bool operator !=(Point first, Point second) => !(first == second);
    public bool Equals(Point other) => X.Equals6DigitPrecision(other.X) && Y.Equals6DigitPrecision(other.Y);
    public override bool Equals(object? obj) => obj is Point other && Equals(other);

    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = hash * 23 + X.GetHashCode();
            hash = hash * 23 + Y.GetHashCode();
            return hash;
        }
    }

    public string ShortString() => $"({X},{Y})";
    public override string ToString() => $"Point: ({X},{Y})";
}