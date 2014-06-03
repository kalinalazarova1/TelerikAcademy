using System;

public class ExamResult
{
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("minGrade", "Minimal grade could not be negative!");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("maxGrade", "Maximal grade has to be greater or equal to minimal grade!");
        }

        if (grade > maxGrade || grade < minGrade)
        {
            throw new ArgumentOutOfRangeException("grade", string.Format("The grade has to be between {0} and {1}!", minGrade, maxGrade));
        }

        if (string.IsNullOrEmpty(comments))
        {
            throw new ArgumentException("comments", "The comments could not be null or empty!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade { get; private set; }

    public int MinGrade { get; private set; }

    public int MaxGrade { get; private set; }

    public string Comments { get; private set; }
}
