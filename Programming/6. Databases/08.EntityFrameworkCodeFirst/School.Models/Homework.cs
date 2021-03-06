﻿namespace School.Models
{
    using System;

    public class Homework
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime TimeSent { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        virtual public Student Student { get; set; }

        virtual public Course Course { get; set; }
    }
}
