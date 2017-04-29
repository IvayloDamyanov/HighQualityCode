using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get { return grade; }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Grade cannot be less than 0");
            }
            else { grade = value; }
        }
    }

    public int MinGrade
    {
        get { return minGrade; }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Minimum grade cannot be less than 0");
            }
            else { minGrade = value; }
        }
    }

    public int MaxGrade
    {
        get { return maxGrade; }

        private set
        {
            if (value <= MinGrade)
            {
                throw new ArgumentOutOfRangeException("Maximum grade cannot be less than or equal to minimum grade");
            }
            else { maxGrade = value; }
        }
    }

    public string Comments
    {
        get { return comments; }

        private set
        {
            if (value == null || value == "")
            {
                throw new ArgumentNullException("Comments can not be empty");
            }
            else { comments = value; }
        }
    }
}
