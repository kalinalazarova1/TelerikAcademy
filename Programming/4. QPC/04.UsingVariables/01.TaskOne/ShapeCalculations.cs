using System;

public static class ShapeCalculations
{
    public static Shape GetRotatedShape(Shape shape, double rotationAngle)
    {
        double rotatedWidth = (Math.Abs(Math.Cos(rotationAngle)) * shape.Width) + (Math.Abs(Math.Sin(rotationAngle)) * shape.Heigth);
        double rotatedHeigth = (Math.Abs(Math.Sin(rotationAngle)) * shape.Width) + (Math.Abs(Math.Cos(rotationAngle)) * shape.Heigth);
        return new Shape(rotatedHeigth, rotatedWidth);
    }
}