//Write a program that reads a date and time given in the format: day.month.year hour:minute:second 
//and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian
using System;
using System.Threading;
using System.Globalization;
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter date: ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "d.M.yyyy HH:mm:ss", CultureInfo.CurrentCulture);

            DateTime newDate = date.AddSeconds(6 * 3600 + 30 * 60);

            Console.WriteLine("{0} {1}", newDate.ToString("dddd", new CultureInfo("bg-BG")), newDate);

        }
    }
