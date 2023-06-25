// ReSharper disable once CheckNamespace
namespace GeometryLib;

/// <summary>
/// The triangle type
/// </summary>
public enum TriangleType
{
    /// <summary>
    /// The triangle has 3 different angles
    /// </summary>
    Scalene = 1,
    /// <summary>
    /// The triangle has 3 the same angles (60 degrees)
    /// </summary>
    Equilaterial = 2,
    /// <summary>
    /// The triangle has 2 the same angles and one different angle
    /// </summary>
    Isosceles = 3,
    /// <summary>
    /// The triangle has an angle equals 90 degrees
    /// </summary>
    RightAngled = 4,
}