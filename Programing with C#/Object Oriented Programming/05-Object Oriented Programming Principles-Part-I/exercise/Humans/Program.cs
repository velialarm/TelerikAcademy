using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humans
{
    class Program
    {
        static void Main(string[] args)
        {
            //10 students
            List<Students> listStudents = new List<Students>();
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                Students studenta = new Students("FName"+i,"LName"+i,r.Next(12));
                listStudents.Add(studenta);
            }
            listStudents = listStudents.OrderByDescending(studenta => studenta.Grade).ToList();
            foreach (Students student in listStudents)
            {
                Console.WriteLine(student.FirstName+ " "+ student.LastName+" "+ student.Grade);
            }

            // 10 workers
            List<Worker> listWorker = new List<Worker>();
            for (int i = 0; i < 10; i++)
            {
                Worker worker = new Worker((decimal)r.Next(500), (decimal)r.Next(15), "FName" + i, "LastName" + i);
                listWorker.Add(worker);
            }
            listWorker = listWorker.OrderByDescending(worker => worker.moneyPerHour()).ToList();
            foreach (Worker workera in listWorker)
            {
                Console.WriteLine(workera.FirstName+" "+workera.LastName+" week Salary: "+workera.WeekSalary+" Work Hours Per Day: "+workera.WorkHoursPerDay+" \nmoney Per Hour: "+workera.moneyPerHour());
            }
        }
    }
}
