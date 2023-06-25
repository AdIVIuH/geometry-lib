namespace GeometryLib;

public static class CircleValidator
{
    public static void Validate(double radius)
    {
        NegativeRadiusException.ThrowIfNegative(radius);
    }
}