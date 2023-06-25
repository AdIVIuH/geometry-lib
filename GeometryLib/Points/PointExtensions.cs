using GeometryLib.Utils;

namespace GeometryLib;

/// <summary>
///     Contains extension methods for a <see cref="Point" /> class
/// </summary>
public static class PointExtensions
{
    /// <summary>
    ///     Returns a distance between two points
    /// </summary>
    /// <param name="p1">first point</param>
    /// <param name="p2">second point</param>
    /// <returns>A distance between two points</returns>
    public static double GetDistance(this Point p1, Point p2) => DistanceCalculator.GetDistance(p1, p2);
}