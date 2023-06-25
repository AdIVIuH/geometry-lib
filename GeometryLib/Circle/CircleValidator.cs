namespace GeometryLib;

internal static class CircleValidator
{
    internal static void Validate(double radius)
    {
        NegativeRadiusException.ThrowIfNegative(radius);
    }
}