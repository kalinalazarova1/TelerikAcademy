using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ThreeDimensionalSpace
{
    public class Path
    {
        private List<Point3D> points;

        public Path()
        {
            this.points = new List<Point3D>();
        }

        public void Add(Point3D item)
        {
            this.points.Add(item);
        }

        public void RemoveAt(int index)
        {
            this.points.RemoveAt(index);
        }

        public Point3D this[int index]
        {
            get
            {
                return this.points[index];
            }
            set
            {
                points[index] = value;
            }
        }

        public int Length 
        {
            get
            {
                return points.Count;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Length; i++)
            {
                sb.Append(this[i].ToString());
                sb.Append(' ');
            }
            return sb.ToString();
        }
    }
}
