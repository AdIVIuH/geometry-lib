using GeometryLib;
using GeometryLib.Utils;

// ReSharper disable once CheckNamespace
namespace GeometryLib;

/// <summary>
///     Represents a triangle geometric figure
/// </summary>
public class Triangle : Figure, IAreaCalculable, IEquatable<Triangle>
{
    /// <summary>
    ///     Constructor of current type
    /// </summary>
    /// <param name="firstPoint">First triangle point</param>
    /// <param name="secondPoint">Second triangle point</param>
    /// <param name="thirdPoint">Third triangle point</param>
    public Triangle(Point firstPoint, Point secondPoint, Point thirdPoint)
    {
        TriangleValidator.Validate(firstPoint, secondPoint, thirdPoint); // TODO use FluentValidation lib

        FirstPoint = firstPoint;
        SecondPoint = secondPoint;
        ThirdPoint = thirdPoint;

        Type = GetTriangleType(FirstPoint, SecondPoint, ThirdPoint);
    }

    /// <summary>
    ///     The triangle type
    /// </summary>
    public TriangleType Type { get; }

    /// <summary>
    ///     The first point of the triangle
    /// </summary>
    public Point FirstPoint { get; }

    /// <summary>
    ///     The second point of the triangle
    /// </summary>
    public Point SecondPoint { get; }

    /// <summary>
    ///     The third point of the triangle
    /// </summary>
    public Point ThirdPoint { get; }

    /// <summary>
    ///     Returns the width of the triangle
    /// </summary>
    public double Width => GetWidth();

    /// <summary>
    ///     Returns the Height of the triangle
    /// </summary>
    public double Height => GetHeight();

    /// <summary>
    ///     The first edge of the triangle
    /// </summary>
    public Edge FirstEdge => new(FirstPoint, SecondPoint);

    /// <summary>
    ///     The second edge of the triangle
    /// </summary>
    public Edge SecondEdge => new(SecondPoint, ThirdPoint);

    /// <summary>
    ///     The third edge of the triangle
    /// </summary>
    public Edge ThirdEdge => new(FirstPoint, ThirdPoint);

    #region IAreaCalculable Members

    public override double CalculateArea()
    {
        var p = CalculatePerimeter() / 2;
        var a = FirstEdge.Length;
        var b = SecondEdge.Length;
        var c = ThirdEdge.Length;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }

    #endregion

    #region IEquatable<Triangle> Members

    public bool Equals(Triangle? other) => other is not null &&
                                           FirstPoint.Equals(other.FirstPoint) &&
                                           SecondPoint.Equals(other.SecondPoint) &&
                                           ThirdPoint.Equals(other.ThirdPoint);

    #endregion


    public double CalculatePerimeter() => FirstEdge.Length + SecondEdge.Length + ThirdEdge.Length;

    private double GetWidth() => MathHelper.GetMaxValue(FirstPoint.X, SecondPoint.X, ThirdPoint.X) -
                                 MathHelper.GetMinValue(FirstPoint.X, SecondPoint.X, ThirdPoint.X);

    private double GetHeight() => MathHelper.GetMaxValue(FirstPoint.Y, SecondPoint.Y, ThirdPoint.Y) -
                                  MathHelper.GetMinValue(FirstPoint.Y, SecondPoint.Y, ThirdPoint.Y);

    private static TriangleType GetTriangleType(Point p1, Point p2, Point p3)
    {
        var a = p1.GetDistance(p2);
        var b = p2.GetDistance(p3);
        var c = p1.GetDistance(p3);

        var angleA = AngleCalculator.GetAngle(p2, p1, p3);
        var angleB = AngleCalculator.GetAngle(p1, p2, p3);
        var angleC = AngleCalculator.GetAngle(p1, p3, p2);

        if (a.Equals6DigitPrecision(b) && b.Equals6DigitPrecision(c))
            return TriangleType.Equilaterial;
        if (a.Equals6DigitPrecision(b) || b.Equals6DigitPrecision(c) || a.Equals6DigitPrecision(c))
            return TriangleType.Isosceles;
        if (angleA.Equals6DigitPrecision(90) || angleB.Equals6DigitPrecision(90) || angleC.Equals6DigitPrecision(90))
            return TriangleType.RightAngled;
        return TriangleType.Scalene;
    }

    public static bool operator ==(Triangle first, Triangle second) => first.Equals(second);
    public static bool operator !=(Triangle first, Triangle second) => !(first == second);

    public override bool Equals(object? obj) => obj is Triangle other && Equals(other);

    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = hash * 23 + FirstPoint.GetHashCode();
            hash = hash * 23 + SecondPoint.GetHashCode();
            hash = hash * 23 + ThirdPoint.GetHashCode();
            return hash;
        }
    }

    public override string ToString() =>
        $"Triangle: [{FirstPoint.ShortString()}, {SecondPoint.ShortString()}, {ThirdPoint.ShortString()}]";
}