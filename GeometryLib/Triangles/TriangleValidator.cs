﻿using GeometryLib.Triangles.Exceptions;

namespace GeometryLib;

internal static class TriangleValidator
{
    internal static void Validate(Point p1, Point p2, Point p3)
    {
        EqualsPointsException.ThrowIfEquals(p1,p2,p3);
        CollinearPointsException.ThrowIfCollinear(p1, p2, p3);
    }
}