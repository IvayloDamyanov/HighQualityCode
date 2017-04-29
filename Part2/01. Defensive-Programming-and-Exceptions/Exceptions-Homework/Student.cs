using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    private string firstName;
    private string lastName;
    private IList<Exam> exams;

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public string FirstName
    {
        get { return firstName; }

        set
        {
            if (value == null)
            {
                Console.WriteLine("Invalid first name!");
                Environment.Exit(0);
            }
            else { firstName = value; }
        }
    }

    public string LastName
    {
        get { return lastName; }

        set
        {
            if (value == null)
            {
                Console.WriteLine("Invalid first name!");
                Environment.Exit(0);
            }
            else { lastName = value; }
        }
    }

    public IList<Exam> Exams
    {
        get { return exams; }
        set { exams = value; }
    }

    public IList<ExamResult> CheckExams()
    {
        if (this.Exams == null || this.Exams.Count == 0)
        {
            Console.WriteLine("The student has no exams!");
            return null;
        }

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        IList<ExamResult> examResults = CheckExams();
        if (examResults == null)
        {
            // No exams --> return -1;
            return -1;
        }

        double[] examScore = new double[this.Exams.Count];
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
