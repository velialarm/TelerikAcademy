using System;

class LeapsYears
{
    static void Main()
    {
        //Write a program that reads a year from the console and checks whether it is a leap
        Console.Write("Enter Year: ");
        int godina = int.Parse(Console.ReadLine());
        IsLeapYear(godina);
    }
  
    private static void IsLeapYear(int godina)
    {
        if (DateTime.IsLeapYear(godina))
        {
            Console.WriteLine("{0} is leap year", godina);
        }
        else
        {
            Console.WriteLine("{0} is not leap year", godina);
        }
    }
}
