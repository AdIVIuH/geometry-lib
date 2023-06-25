using GeometryLib.Utils;

namespace GeometryLib.Triangles.Exceptions;

public class CollinearPointsException : Exception
{
    public Point Point1 { get; }
    public Point Point2 { get; }
    public Point Point3 { get; }

    public CollinearPointsException(Point p1, Point p2, Point p3) : base("The given points are collinear and cannot form a triangle.")
    {
        Point1 = p1;
        Point2 = p2;
        Point3 = p3;
    }
    
    public static void ThrowIfCollinear(Point p1, Point p2, Point p3)
    {
        if (GeometryUtility.AreCollinear(p1, p2, p3))
            throw new CollinearPointsException(p1, p2, p3);
    }
}