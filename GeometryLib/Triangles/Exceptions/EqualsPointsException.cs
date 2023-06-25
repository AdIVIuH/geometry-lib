namespace GeometryLib.Triangles.Exceptions;

public class EqualsPointsException : Exception
{
    public Point Point1 { get; }
    public Point Point2 { get; }
    public Point Point3 { get; }

    public EqualsPointsException(Point p1, Point p2, Point p3) : base(
        "The given points are not different and cannot form a triangle.")
    {
        Point1 = p1;
        Point2 = p2;
        Point3 = p3;
    }

    public static void ThrowIfEquals(Point p1, Point p2, Point p3)
    {
        if (p1 == p2 || p1 == p3 || p2 == p3)
            throw new EqualsPointsException(p1, p2, p3);
    }
}