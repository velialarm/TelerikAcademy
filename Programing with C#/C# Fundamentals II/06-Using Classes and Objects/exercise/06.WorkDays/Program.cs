//Write a method that calculates the number of workdays between today and given date, passed as parameter. 
//Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

using System;
using System.Collections.Generic;
    class WorkDays
    {
        static void Main()
        {
            Console.WriteLine("Enter a end date in YYYY/MM/DD format");
            string endDate = Console.ReadLine();
            string[] endDateStr = endDate.Split('/');

            int woorkdays = CalcWorkDays(endDateStr);

            Console.WriteLine("Workdays between today and given date {0} is = {1}",endDate, woorkdays);

        }

        //fixed list of public holidays specified preliminary as array
        private static int currentYear = DateTime.Now.Year;
        private static List<DateTime> holidays = new List<DateTime>
            { new DateTime(currentYear, 1, 1),
               new DateTime(currentYear, 3, 3),
               new DateTime(currentYear, 5, 1),
               new DateTime(currentYear, 5, 2),
               new DateTime(currentYear, 5, 6),
               new DateTime(currentYear, 5, 24),
               new DateTime(currentYear, 9, 22),
               new DateTime(currentYear, 12, 24),
               new DateTime(currentYear, 12, 25),
               new DateTime(currentYear, 12, 26),
               new DateTime(currentYear, 12, 31),
            };

        private static int CalcWorkDays(string[] endDateStr)
        {
            

            int day = int.Parse(endDateStr[2]);
            int month = int.Parse(endDateStr[1]);
            int year = int.Parse(endDateStr[0]);

            DateTime givenDate = new DateTime(year, month, day);
            DateTime start = DateTime.Today;

            int woorkdays = 0;

            for (DateTime i = start; i <= givenDate; i = i.AddDays(1))
            {
                if ((i.DayOfWeek != DayOfWeek.Saturday) && (i.DayOfWeek != DayOfWeek.Sunday) && (holidays.IndexOf(i) == -1))
                {
                    woorkdays++;
                }
            }
            return woorkdays;
        }
    }
