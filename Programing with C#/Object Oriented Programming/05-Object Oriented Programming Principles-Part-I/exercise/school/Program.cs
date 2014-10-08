using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school
{
    class Program
    {
        static void Main(string[] args)
        {

            // demo code for testing
            Students student = new Students();
            Disciplines discipline = new Disciplines();
            discipline.Name = "Opala";
            Teachers teachers = new Teachers();
            List<Disciplines> listDiscpiline = new List<Disciplines>();
            listDiscpiline.Add(discipline);
            teachers.Disciplines = listDiscpiline;
            discipline.NumExercises = 2;
            discipline.NumLectures = 3;
            student.Name = "Pencho";
            student.ClassNumber = 12;
            Console.WriteLine(discipline.Name);
        }
    }
}
