using System;

namespace School
{
    public class Discipline : SchoolObject
    {
        public string Name { get; set; }

        private int lectures;
        public int Lectures
        {
            get
            {
                return this.lectures;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid number of lectures!");
                }
                else
                {
                    this.lectures = value;
                }
            }
        }

        private int exercises;
        public int Exercises
        {
            get
            {
                return this.exercises;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid number of lectures!");
                }
                else
                {
                    this.exercises = value;
                }
            }
        }

        public Discipline(string name, int lecturesNumber, int exercisesNumber)
            : this(name, lecturesNumber, exercisesNumber, null)
        {
        }

        public Discipline(string name, int lecturesNumber, int exercisesNumber, string comment)
        {
            this.Name = name;
            this.Lectures = lecturesNumber;
            this.Exercises = exercisesNumber;
            base.Comment = comment;
        }

        public override string ToString()
        {
            if (base.Comment == null)
            {
                return string.Format("Discipline: {0}, Number of lectures: {1}, Number of exercises: {2}\n", this.Name, this.Lectures, this.Exercises);
            }
            else
            {
                return string.Format("Discipline: {0}, Number of lectures: {1}, Number of exercises: {2}, Comment: {3}\n", this.Name, this.Lectures, this.Exercises, base.Comment);
            }
        }
    }
}
