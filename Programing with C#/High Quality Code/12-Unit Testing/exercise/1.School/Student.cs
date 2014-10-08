using System;

public class Student : IComparable<Student>
{
    private string name = null;
    public string Name
    {
        get { return this.name; }
        private set
        {
            if (value == null)
                throw new ArgumentNullException("Name can not be empty");
            this.name = value;
        }
    }

    private int id = 0;
    public int Id
    {
        get { return this.id; }
        private set
        {
            if (!(10000 <= value && value <= 99999))
                throw new ArgumentOutOfRangeException("the unique number is between 10000 and 99999");
            this.id = value;
        }
    }

    public Student(string name, int id)
    {
        this.Name = name;
        this.Id = id;
    }

    public int CompareTo(Student other)
    {
        return this.Id.CompareTo(other.Id);
    }
}
