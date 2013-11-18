//1.Define abstract class Shape with only one abstract method CalculateSurface() and fields width 
//and height. Define two new classes Triangle and Rectangle that implement the virtual method and 
//return the surface of the figure (height*width for rectangle and height*width/2 for triangle). 
//Define class Circle and suitable constructor so that at initialization height must be kept equal
//to width and implement the CalculateSurface() method. Write a program that tests the behavior of
//the CalculateSurface() method for different shapes (Circle, Rectangle, Triangle) stored in an array.

using System;
using System.Linq;

namespace Geometry
{
    public static class GeometryTest
    {
        static void Main()
        {
            try
            {
                Shape[] testShapes = { new Triangle(2, 3),
                                   new Rectangle(4, 2),
                                   new Circle(4),
                                   new Rectangle(7, 1),
                                   new Triangle(4, 4),
                                   new Circle(3),
                                   new Circle(22)
                                 };
                Console.WriteLine("Test shapes area calculation:");
                foreach (Shape shape in testShapes.OrderBy(x => x.GetType().Name))
                {
                    Console.WriteLine("{0}\tArea:{1:0.00}", shape, shape.CalculateSurface());
                }
                //Circle c = new Circle(9);
                //Console.WriteLine(c.Heigth); - this will not compile because the circle has only radius for the outer world, heigth is hidden
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
