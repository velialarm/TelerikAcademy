//Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. 
//Display them in the standard date format for Canada.
using System;
using System.Globalization;
class Program
{
    static void Main()
    {
        string text = "One time in 12.02.2005 and before. then 01.12.2005 Gusto a prez 2012.12.";
        int index = -1;
        while (true)
        {
            index = text.IndexOf(".", index + 1);
            if (index == -1)
            {
                break;
            }
            if ((index+3<text.Length-1)&&(index !=text.Length))
            {
                if (text[index] == text[index + 3])
                {
                    //string date = text.Substring(index - 2, 10);
                    DateTime date = DateTime.ParseExact(text.Substring(index - 2, 10), "d.M.yyyy", CultureInfo.CurrentCulture);
                    Console.WriteLine("{0} {1}", date.ToString("dd.MM.yyyy", new CultureInfo("en-CA")),date.DayOfWeek);
                    index = index + 3;
                }
            }
            
            
            

        }
    }
}
