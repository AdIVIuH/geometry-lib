namespace GeometryLib.Triangles;

public static class TriangleExtensions
{
    /// <summary>
    ///     Checks that triangle is scalene
    /// </summary>
    /// <param name="triangle">The current triangle</param>
    /// <returns>Is triangle scalene?</returns>
    public static bool IsScalene(this Triangle triangle) => triangle.Type == TriangleType.Scalene;

    /// <summary>
    ///     Checks that triangle is equilaterial
    /// </summary>
    /// <param name="triangle">The current triangle</param>
    /// <returns>Is triangle equilaterial?</returns>
    public static bool IsEquilaterial(this Triangle triangle) => triangle.Type == TriangleType.Equilaterial;

    /// <summary>
    ///     Checks that triangle is isosceles
    /// </summary>
    /// <param name="triangle">The current triangle</param>
    /// <returns>Is triangle isosceles?</returns>
    public static bool IsIsosceles(this Triangle triangle) => triangle.Type == TriangleType.Isosceles;

    /// <summary>
    ///     Checks that triangle is right-angled
    /// </summary>
    /// <param name="triangle">The current triangle</param>
    /// <returns>Is triangle right-angled?</returns>
    public static bool IsRightAngled(this Triangle triangle) => triangle.Type == TriangleType.RightAngled;
}