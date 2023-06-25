namespace GeometryLib.Utils;

public static class AngleCalculator
{
    public static double GetAngle(Point p1, Point p2, Point p3)
    {
        var a = p1.GetDistance(p2);
        var b = p2.GetDistance(p3);
        var c = p1.GetDistance(p3);

        var cosAB = (a * a + b * b - c * c) / (2 * a * b);
        var angleRad = Math.Acos(cosAB);
        var angleDeg = angleRad * (180.0 / Math.PI);

        return angleDeg;
    }
}