using System;

public class CSharpExam : Exam
{
    private const int MaximalScore = 100;

    public CSharpExam(int score)
    {
        if (score < 0 || score > CSharpExam.MaximalScore)
        {
            throw new ArgumentOutOfRangeException(
                "score",
                string.Format("The score could not be negative or greater than {0}!", CSharpExam.MaximalScore));
        }

        this.Score = score;
    }

    public int Score { get; private set; }

    public override ExamResult AccessPerformance()
    {
        return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
    }
}
