
//Write a program that prints to the console which day of the week is today.
using System;
using System.Data;

class WeekDay
{
    static void Main()
    {
        Console.WriteLine(PrintWeekOfDay(DateTime.Now));
    }
    public static string PrintWeekOfDay(DateTime today)
    {
        string result = today.DayOfWeek.ToString();
        return result;
    }
}