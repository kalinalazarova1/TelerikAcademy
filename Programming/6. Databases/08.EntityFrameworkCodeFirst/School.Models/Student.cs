﻿namespace School.Models
{
    using System.Collections.Generic;

    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;

        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public virtual ICollection<Course> Courses 
        {
            get 
            {
                return this.courses;
            }
            set
            {
                this.courses = value;
            }
        }

        public virtual ICollection<Homework> Homeworks 
        { 
            get
            {
                return this.homeworks;
            }
            set
            {
                this.homeworks = value;
            }
        }
    }
}
