using System;

public class SimpleMathExam : Exam
{
    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get { return problemsSolved; }
        private set
        {
            if (value < 0)
            {
                problemsSolved = 0;
            }
            else if (value > 10)
            {
                problemsSolved = 10;
            }
            else
            {
                problemsSolved = value;
            }
        }
    }

    public override ExamResult Check()
    {
        if (ProblemsSolved == 0)
        {
            ExamResult examResult = new ExamResult(2, 2, 6, "Bad result: nothing done.");
            return examResult;
        }
        else if (ProblemsSolved == 1)
        {
            ExamResult examResult = new ExamResult(4, 2, 6, "Average result: nothing done.");
            return examResult;
        }
        else if (ProblemsSolved == 2)
        {
            ExamResult examResult = new ExamResult(6, 2, 6, "Average result: nothing done.");
            return examResult;
        }
        else
        {
            ExamResult examResult = new ExamResult(0, 0, 0, "Invalid number of problems solved!");
            return examResult;
        }
    }
}
