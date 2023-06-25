namespace GeometryLib.Utils;

public static class GeometryUtility
{
    public static bool AreCollinear(Point p1, Point p2, Point p3)
    {
        var determinant = (p2.X - p1.X) * (p3.Y - p1.Y) - (p3.X - p1.X) * (p2.Y - p1.Y);
        return Math.Abs(determinant) < double.Epsilon;
    }
}