using System;

public class CSharpExam : Exam
{
    private int score;
    public int Score
    {
        get { return this.score; }
        private set
        {
            if (score < 0)
            {
                throw new ArgumentOutOfRangeException("Score");
            }

            this.score = value;
        }
    }

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public override ExamResult Check()
    {
        if (Score < 0 || Score > 100)
        {
            throw new InvalidOperationException();
        }
        else
        {
            return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
        }
    }
}
