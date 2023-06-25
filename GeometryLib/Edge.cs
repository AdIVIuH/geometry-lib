namespace GeometryLib;

/// <summary>
///     Represents an edge of a figure
/// </summary>
public struct Edge : IEquatable<Edge>
{
    /// <summary>
    ///     Constructor of current type
    /// </summary>
    /// <param name="firstPoint">First point of the edge created</param>
    /// <param name="secondPoint">Second point of the edge created</param>
    public Edge(Point firstPoint, Point secondPoint)
    {
        FirstPoint = firstPoint;
        SecondPoint = secondPoint;
    }

    /// <summary>
    ///     First point of the edge
    /// </summary>
    public Point FirstPoint { get; }

    /// <summary>
    ///     Second point of the edge
    /// </summary>
    public Point SecondPoint { get; }

    /// <summary>
    ///     The length of the edge
    /// </summary>
    public double Length => FirstPoint.GetDistance(SecondPoint);

    public static bool operator ==(Edge first, Edge second) => first.Equals(second);
    public static bool operator !=(Edge first, Edge second) => !(first == second);
    public bool Equals(Edge other) => FirstPoint.Equals(other.FirstPoint) && SecondPoint.Equals(other.SecondPoint);
    public override bool Equals(object? obj) => obj is Edge other && Equals(other);

    public override int GetHashCode()
    {
        unchecked
        {
            var hash = 17;
            hash = hash * 23 + FirstPoint.GetHashCode();
            hash = hash * 23 + SecondPoint.GetHashCode();
            return hash;
        }
    }
    public override string ToString() => $"Edge: [{FirstPoint.ShortString()}-{SecondPoint.ShortString()}]";
}