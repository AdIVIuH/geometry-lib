namespace GeometryLib;

/// <summary>
///     Contains extension methods for a <see cref="double" />
/// </summary>
public static class DoubleExtensions
{
    public static bool Equals3DigitPrecision(this double left, double right) => Math.Abs(left - right) < 1e-3;
    public static bool Equals4DigitPrecision(this double left, double right) => Math.Abs(left - right) < 1e-4;
    public static bool Equals5DigitPrecision(this double left, double right) => Math.Abs(left - right) < 1e-5;
    public static bool Equals6DigitPrecision(this double left, double right) => Math.Abs(left - right) < 1e-6;
    public static bool Equals7DigitPrecision(this double left, double right) => Math.Abs(left - right) < 1e-7;
}