using System;
using System.IO;
using System.Collections.Generic;

namespace ThreeDimensionalSpace
{
    static public class PathStorage
    {
        static public Path LoadPath(string fileName)
        {
            Path currPath = new Path();
            using (StreamReader reader = new StreamReader(fileName))
            {
                for (string input = reader.ReadLine(); input != "end"; input = reader.ReadLine())
                {
                    string[] coord = input.Split(',');
                    Point3D currPoint = new Point3D(double.Parse(coord[0]), double.Parse(coord[1]), double.Parse(coord[2]));
                    currPath.Add(currPoint);
                }
            }
            return currPath;
        }

        static public void SavePath(Path currPath, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                for (int i = 0; i < currPath.Length; i++)
                {
                    writer.WriteLine(string.Format("{0},{1},{2}", currPath[i].X, currPath[i].Y, currPath[i].Z));
                }
                writer.WriteLine("end");
            }
        }
    }
}
