namespace GeometryLib;

public class NegativeRadiusException : Exception
{
    public double Radius { get; }

    public NegativeRadiusException(double radius) : base("The radius couldn't be negative!")
    {
        Radius = radius;
    }
    
    public static void ThrowIfNegative(double radius)
    {
        if (radius < 0)
            throw new NegativeRadiusException(radius);
    }
}