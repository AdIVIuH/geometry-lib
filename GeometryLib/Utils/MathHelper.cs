namespace GeometryLib.Utils;

public static class MathHelper
{
    /// <summary>
    ///     Returns a min value for a list of double values
    /// </summary>
    /// <param name="values">An array of double values</param>
    /// <returns>A min value for a list of double values</returns>
    public static double GetMinValue(params double[] values) => values.Min();

    /// <summary>
    ///     Returns a max value for a list of double values
    /// </summary>
    /// <param name="values">An array of double values</param>
    /// <returns>A max value for a list of double values</returns>
    public static double GetMaxValue(params double[] values) => values.Max();
}