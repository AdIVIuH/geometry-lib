using FluentAssertions;
using GeometryLib;
using GeometryLib.Triangles.Exceptions;

namespace GeometryLibTests;

public class TriangleTests
{
    [Theory]
    [InlineData(0, 0, 1, 1, 1, 1)]
    [InlineData(0, 0, 0, 0, 2, 2)]
    [InlineData(3, 3, 3, 3, 3, 3)]
    public void Constructor_ThrowsEqualsPointsException_WhenEqualsPointsProvided(
        double x1, double y1,
        double x2, double y2,
        double x3, double y3)
    {
        // Arrange
        var p1 = new Point(x1, y1);
        var p2 = new Point(x2, y2);
        var p3 = new Point(x3, y3);

        // Act and Assert
        Action constructor = () => new Triangle(p1, p2, p3);
        constructor.Should().Throw<EqualsPointsException>();
    }

    [Theory]
    [InlineData(0, 0, 1, 1, 2, 2)]
    [InlineData(0, 0, 1, 0, 2, 0)]
    public void Constructor_ThrowsCollinearPointsException_WhenCollinearPointsProvided(
        double x1, double y1,
        double x2, double y2,
        double x3, double y3)
    {
        // Arrange
        var p1 = new Point(x1, y1);
        var p2 = new Point(x2, y2);
        var p3 = new Point(x3, y3);

        // Act and Assert
        Action constructor = () => new Triangle(p1, p2, p3);
        constructor.Should().Throw<CollinearPointsException>();
    }

    [Theory]
    [InlineData(0, 0, 2, 0, 1, 1.732, TriangleType.Equilaterial, 1.732)]
    [InlineData(0, 0, 3, 0, 0, 4, TriangleType.RightAngled, 6)]
    [InlineData(0, 0, 4, 1, 2, 3, TriangleType.Scalene, 5)]
    [InlineData(0, 0, 4, 0, 2, 3, TriangleType.Isosceles, 6)]
    public void CalculateArea_ReturnsCorrectArea(
        double x1, double y1,
        double x2, double y2,
        double x3, double y3,
        TriangleType triangleType,
        double expectedValue)
    {
        // Arrange
        var p1 = new Point(x1, y1);
        var p2 = new Point(x2, y2);
        var p3 = new Point(x3, y3);
        var triangle = new Triangle(p1, p2, p3);

        // Act
        var area = triangle.CalculateArea();

        // Assert
        area.Should().BeApproximately(expectedValue, 0.001, triangleType.ToString());
    }


    [Theory]
    [InlineData(0, 0, 3, 0, 0, 4, 12)]
    [InlineData(0, 0, 3, 4, 6, 0, 16)]
    public void CalculatePerimeter_ReturnsCorrectPerimeter(
        double x1, double y1,
        double x2, double y2,
        double x3, double y3,
        double expectedValue)
    {
        // Arrange
        var p1 = new Point(x1, y1);
        var p2 = new Point(x2, y2);
        var p3 = new Point(x3, y3);
        var triangle = new Triangle(p1, p2, p3);

        // Act
        var perimeter = triangle.CalculatePerimeter();

        // Assert
        perimeter.Should().BeApproximately(expectedValue, 0.000001);
    }

    [Fact]
    public void Equals_ReturnsTrue_WhenEqualTriangles()
    {
        // Arrange
        var p1 = new Point(0, 0);
        var p2 = new Point(3, 0);
        var p3 = new Point(0, 4);
        var triangle1 = new Triangle(p1, p2, p3);

        var p4 = new Point(0, 0);
        var p5 = new Point(3, 0);
        var p6 = new Point(0, 4);
        var triangle2 = new Triangle(p4, p5, p6);

        // Act
        var equalsResult = triangle1.Equals(triangle2);
        var operatorResult = triangle1 == triangle2;

        // Assert
        equalsResult.Should().BeTrue();
        operatorResult.Should().BeTrue();
    }

    [Fact]
    public void Equals_ReturnsFalse_WhenNotEqualTriangles()
    {
        // Arrange
        var p1 = new Point(0, 0);
        var p2 = new Point(3, 0);
        var p3 = new Point(0, 4);
        var triangle1 = new Triangle(p1, p2, p3);

        var p4 = new Point(1, 0); // difference here
        var p5 = new Point(3, 0);
        var p6 = new Point(0, 4);
        var triangle2 = new Triangle(p4, p5, p6);

        // Act
        var equalsResult = triangle1.Equals(triangle2);
        var operatorResult = triangle1 != triangle2;

        // Assert
        equalsResult.Should().BeFalse();
        operatorResult.Should().BeTrue();
    }

    [Theory]
    [InlineData(0, 0, 3, 0, 0, 4, 3)]
    [InlineData(0, 0, 5, 0, 0, 4, 5)]
    [InlineData(-1, 0, 3, 0, 0, 4, 4)]
    public void Width_ShouldBeCalculatedCorrectly(
        double x1, double y1,
        double x2, double y2,
        double x3, double y3,
        double expectedValue)
    {
        // Arrange
        var p1 = new Point(x1, y1);
        var p2 = new Point(x2, y2);
        var p3 = new Point(x3, y3);
        var triangle = new Triangle(p1, p2, p3);

        // Act
        var width = triangle.Width;

        // Assert
        width.Should().BeApproximately(expectedValue, 0.000001);
    }

    [Theory]
    [InlineData(0, 0, 3, 0, 0, 4, 4)]
    [InlineData(0, 0, 5, 2, 0, 4, 4)]
    [InlineData(-1, -4, 3, 2, 0, 6, 10)]
    public void Height_ShouldBeCalculatedCorrectly(
        double x1, double y1,
        double x2, double y2,
        double x3, double y3,
        double expectedType)
    {
        // Arrange
        var p1 = new Point(x1, y1);
        var p2 = new Point(x2, y2);
        var p3 = new Point(x3, y3);
        var triangle = new Triangle(p1, p2, p3);

        // Act
        var width = triangle.Height;

        // Assert
        width.Should().BeApproximately(expectedType, 0.000001);
    }

    [Theory]
    [InlineData(0, 0, 3, 0, 0, 4, TriangleType.RightAngled)]
    [InlineData(0, 0, 2, 0, 1, 1, TriangleType.Isosceles)]
    [InlineData(0, 0, 6, 1, 3, 4, TriangleType.Scalene)]
    [InlineData(1, 2, 4, 3, 6, 1, TriangleType.Scalene)]
    [InlineData(0, 0, 5, 3, 2, 4, TriangleType.Scalene)]
    public void Type_ReturnsCorrectTriangleType(
        double x1, double y1,
        double x2, double y2,
        double x3, double y3,
        TriangleType expectedType)
    {
        // Arrange
        var p1 = new Point(x1, y1);
        var p2 = new Point(x2, y2);
        var p3 = new Point(x3, y3);
        var triangle = new Triangle(p1, p2, p3);

        // Act
        var actualType = triangle.Type;

        // Assert
        actualType.Should().Be(expectedType);
    }

    [Fact]
    public void Type_ReturnsEquilateral_ForEqualSides()
    {
        // Arrange
        var p1 = new Point(0, 0);
        var p2 = new Point(2, 0);
        var p3 = new Point(1, Math.Sqrt(3));
        var triangle = new Triangle(p1, p2, p3);
        var expectedType = TriangleType.Equilaterial;

        // Act
        var actualType = triangle.Type;

        // Assert
        actualType.Should().Be(expectedType);
    }
}