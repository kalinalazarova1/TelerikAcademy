// 1. Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} in the Euclidian 3D space. 
// Implement the ToString() to enable printing a 3D point.
// 2. Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}.
// Add a static property to return the point O.
// 3. Write a static class with a static method to calculate the distance between two points in the 3D space.
// 4. Create a class Path to hold a sequence of points in the 3D space. Create a static class PathStorage 
// with static methods to save and load paths from a text file. Use a file format of your choice.

using System;
using ThreeDimensionalSpace;

namespace ThreeDimensionalSpaceTest
{
    public class ThreeDimensionalSpaceTest
    {
        static void Main()
        {
            Path testPath = new Path();                 //creates a Path class instance
            testPath = PathStorage.LoadPath(@"..\..\InputPath.txt"); //test method loading a path of points from specified file
            Console.WriteLine(testPath.ToString());         //test method Path.ToString()
            testPath.Add(Point3D.PointZero);                //test constant PointZero (0,0,0)
            Console.WriteLine(testPath.ToString());
            testPath.RemoveAt(0);                           //test remove the first point from the path
            Console.WriteLine(testPath.ToString());
            PathStorage.SavePath(testPath, @"..\..\OutputPath.txt"); //test save the path to file
            Console.WriteLine("The distance between {0} and {1} is: {2}", new Point3D(3.2, 3.5, 3.0), Point3D.PointZero, Distance3D.CalcDistance3D(new Point3D(3.2, 3.5, 3.0), Point3D.PointZero));
            //tests the calculation of the distance between two 3D points
        }
    }
}
