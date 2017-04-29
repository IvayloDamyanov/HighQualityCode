using System;

public class CSharpExam : Exam
{
    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get { return score; }

        private set
        {
            if (value < 0 || 100 < value)
            {
                throw new ArgumentOutOfRangeException("Exam score can not be less than 0 or more than 100");
            }
            else { score = value; }
        }
    }

    public override ExamResult Check()
    {
        ExamResult examResult = new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
        return examResult;
    }
}
