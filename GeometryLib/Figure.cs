namespace GeometryLib;

/// <summary>
///     Represents the geometric figure
/// </summary>
public abstract class Figure : IFigure, IAreaCalculable
{
    #region IAreaCalculable Members

    /// <summary>
    ///     Calculates the area of an figure
    /// </summary>
    /// <returns>The area of an figure</returns>
    public abstract double CalculateArea();

    #endregion

    #region IFigure Members

    public virtual IFigure Clone() => (IFigure) MemberwiseClone();

    #endregion
}