// ReSharper disable once CheckNamespace
namespace GeometryLib;

/// <summary>
///     Represents a circle geometric figure
/// </summary>
public class Circle : Figure
{
    public Circle(Point centerPoint, double radius)
    {
        CircleValidator.Validate(radius);
        
        CenterPoint = centerPoint;
        Radius = radius;
    }

    /// <summary>
    ///     The center point of a circle
    /// </summary>
    public Point CenterPoint { get; }

    /// <summary>
    ///     The radius of a circle
    /// </summary>
    public double Radius { get; }

    public override double CalculateArea() => Math.PI * Math.Pow(Radius, 2);
}