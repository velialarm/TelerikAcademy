//Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. 

using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter the first date: ");
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);
            Console.Write("Enter the second date: ");
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine("Distance {0}", (endDate - startDate).TotalDays);
        }
        catch (ArgumentNullException anEx)
        {
            Console.WriteLine(anEx.Message);
        }
        catch (FormatException fe)
        {
            Console.WriteLine(fe.Message);
        }

    }
}
