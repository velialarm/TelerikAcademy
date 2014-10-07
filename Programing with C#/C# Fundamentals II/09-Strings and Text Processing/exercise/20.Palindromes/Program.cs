//Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

using System;
class Program
{
    static void Main()
    {
        string text = "gusto abba ima v lamal i tova e file exe. Ima li kapak";
     
        string[] words = text.Split(new char[]{' ','.'},StringSplitOptions.RemoveEmptyEntries);
        foreach (var word in words)
        {
            int lenght = word.Length;
            int mid = lenght / 2;
            bool palindromword = true;
            if (lenght>1)
            {
                for (int i = 0; i < mid; i++)
                {
                    if (word.Substring(i, 1) != word.Substring(lenght - i - 1, 1))
                    {
                        palindromword = false;
                        break;
                    }
                }
                if (palindromword)
                {
                    Console.WriteLine(word);
                }    
            }
            
        }

    }
}