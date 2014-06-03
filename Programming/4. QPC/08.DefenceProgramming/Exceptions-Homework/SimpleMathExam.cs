using System;

public class SimpleMathExam : Exam
{
    private const int MaximumSolvedProblems = 2;

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0)
        {
            throw new ArgumentOutOfRangeException("problemSolved", "The solved problems could not be less than zero!");
        }

        if (problemsSolved > SimpleMathExam.MaximumSolvedProblems)
        {
            throw new ArgumentOutOfRangeException(
                "problemSolved",
                string.Format("The solved problems could not be greater than {0}!", SimpleMathExam.MaximumSolvedProblems));
        }

        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved { get; private set; }

    public override ExamResult AccessPerformance()
    {
        if (this.ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: almost done.");
        }
        else
        {
            return new ExamResult(6, 2, 6, "Excellent result: well done.");
        }
    }
}
