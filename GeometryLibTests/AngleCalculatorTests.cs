using FluentAssertions;
using GeometryLib;
using GeometryLib.Utils;

namespace GeometryLibTests;

public class AngleCalculatorTests
{
    [Theory]
    [InlineData(0, 0, 3, 0, 3, 4, 90.0)]
    [InlineData(1, 1, 4, 1, 4, 5, 90.0)]
    [InlineData(0, 0, 1, 0, 0, 1, 45.0)]
    [InlineData(0, 0, 1, 0, 0, -1, 45.0)]
    [InlineData(-2, -2, 2, 2, 0, 0, 0)]
    [InlineData(3, 0, 0, 0, 3, 5.196d, 60)]
    public void GetAngle_ReturnsCorrectAngle(
        double x1, double y1, 
        double x2, double y2, 
        double x3, double y3, 
        double expectedAngle)
    {
        // Arrange
        var p1 = new Point(x1, y1);
        var p2 = new Point(x2, y2);
        var p3 = new Point(x3, y3);

        // Act
        var angle = AngleCalculator.GetAngle(p1, p2, p3);

        // Assert
        angle.Should().BeApproximately(expectedAngle, 0.001);
    }
}