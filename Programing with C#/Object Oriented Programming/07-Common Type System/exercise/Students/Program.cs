using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        Student[] students = {
            new Student("Ivan", "Petrov", "Stoqnov", "1"),
            new Student("Penka", "Vasilova", "Nichkova", "2")
        };

        Array.Sort(students);

        Console.WriteLine(String.Join<Student>(Environment.NewLine + Environment.NewLine, students));

    }
}

