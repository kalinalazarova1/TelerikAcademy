namespace _01.Sigleton
{
    using System;

    public class Score : IComparable
    {
        public Score(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public string Name { get; set; }

        public int Points { get; set; }

        public override string ToString()
        {
            return string.Format("{0} --> {1} points", this.Name, this.Points);
        }

        public int CompareTo(object obj)
        {
            return this.Points.CompareTo((obj as Score).Points);
        }
    }
}
