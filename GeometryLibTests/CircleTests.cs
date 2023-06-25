using FluentAssertions;
using GeometryLib;

namespace GeometryLibTests;

public class CircleTests
{
    [Fact]
    public void Constructor_ThrowsNegativeRadiusException_WhenNegativeRadiusProvided()
    {
        // Arrange
        var centerPoint = new Point(0, 0);

        // Act and Assert
        Action constructor = () => new Circle(centerPoint, -1);
        constructor.Should().Throw<NegativeRadiusException>();
    }
    
    [Theory]
    [InlineData(0, 0, 1, 3.1416)]
    [InlineData(0, 0, 2, 12.5664)]
    public void CalculateArea_ReturnsCorrectArea(
        double x, double y, double radius, double expectedValue)
    {
        // Arrange
        var centerPoint = new Point(x, y);
        var circle = new Circle(centerPoint, radius);

        // Act
        var area = circle.CalculateArea();

        // Assert
        area.Should().BeApproximately(expectedValue, 0.001);
    }
}