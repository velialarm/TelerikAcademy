using System;

public class ExamResult
{
    private int grade;
    private int maxGrade;
    private int minGrade;
    private String comments;

    public int Grade
    {
        get { return this.grade; }
        private set
        {
            if (!(this.minGrade <= value && value <= this.maxGrade))
                throw new ArgumentOutOfRangeException("Grade");

            this.grade = value;
        }
    }
    public int MinGrade
    {
        get { return this.minGrade; }
        private set
        {
            if (!(value >= 0))
                throw new ArgumentOutOfRangeException("Min grade");

            this.minGrade = value;
        }
    }
    public int MaxGrade
    {
        get { return this.maxGrade; }
        private set
        {
            if (!(value > this.minGrade))
                throw new ArgumentOutOfRangeException("Max grade");

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get { return this.comments; }
        private set
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("Comments is null or empty!");

            this.comments = value;
        }
    }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new Exception();
        }
        if (minGrade < 0)
        {
            throw new Exception();
        }
        if (maxGrade <= minGrade)
        {
            throw new Exception();
        }
        if (comments == null || comments == "")
        {
            throw new Exception();
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
