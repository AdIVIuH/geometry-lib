using FluentAssertions;
using GeometryLib;
using GeometryLib.Utils;

namespace GeometryLibTests;

public class DistanceCalculatorTests
{
    [Theory]
    [InlineData(1, 2, 4, 6, 5.0)]
    [InlineData(-2, -3, -5, -7, 5.0)]
    [InlineData(0, 0, 3, 4, 5.0)]
    [InlineData(-2, -2, 2, 2, 5.656854249492381)]
    [InlineData(0, 5, 0, -5, 10.0)]
    [InlineData(1.5, -2.5, -1.5, 2.5, 5.830951894845301)]
    public void GetDistance_ReturnsCorrectDistance(double x1, double y1, double x2, double y2, double expectedDistance)
    {
        // Arrange
        var p1 = new Point(x1, y1);
        var p2 = new Point(x2, y2);

        // Act
        var distance = DistanceCalculator.GetDistance(p1, p2);

        // Assert
        distance.Should().BeApproximately(expectedDistance, 0.0001);
    }
}