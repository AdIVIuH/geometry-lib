namespace GeometryLib.Utils;

/// <summary>
///     Represents a calculator which has methods for distance calculation
/// </summary>
public static class DistanceCalculator
{
    /// <summary>
    ///     Returns a distance between two points
    /// </summary>
    /// <param name="p1">first point</param>
    /// <param name="p2">second point</param>
    /// <returns>A distance between two points</returns>
    public static double GetDistance(Point p1, Point p2) => GetDistance(p1.X, p1.Y, p2.X, p2.Y);

    /// <summary>
    ///     Returns a distance between two points
    /// </summary>
    /// <param name="x1">X coordinate for a first point</param>
    /// <param name="y1">Y coordinate for a first point</param>
    /// <param name="x2">X coordinate for a second point</param>
    /// <param name="y2">Y coordinate for a second point</param>
    /// <returns></returns>
    public static double GetDistance(double x1, double y1, double x2, double y2) =>
        Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
}