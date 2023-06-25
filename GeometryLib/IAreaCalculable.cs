namespace GeometryLib;

/// <summary>
///     An interface for objects which could calculate the area
/// </summary>
public interface IAreaCalculable
{
    /// <summary>
    ///     Calculates the area of an object
    /// </summary>
    /// <returns>The area of an object</returns>
    double CalculateArea();
}