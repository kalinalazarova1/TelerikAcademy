using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public Student(string firstName, string lastName, IList<Exam> exams)
    {
        if (string.IsNullOrEmpty(firstName))
        {
            throw new ArgumentException("firstName", "The first name could not be null or empty!");
        }

        if (string.IsNullOrEmpty(lastName))
        {
            throw new ArgumentException("lastName", "The last name could not be null or empty!");
        }

        if (exams == null)
        {
            throw new ArgumentNullException("exams", "The exams list could not be null!");
        }

        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public IList<Exam> Exams { get; private set; }

    public IList<ExamResult> LoadExamResults()
    {
        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].AccessPerformance());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("Could not calculate average, because no exams are present!");
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.LoadExamResults();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
