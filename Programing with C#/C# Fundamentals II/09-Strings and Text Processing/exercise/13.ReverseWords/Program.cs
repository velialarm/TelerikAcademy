//Write a program that reverses the words in given sentence.

using System;
class Program
{
    static void Main()
    {
        string message = @"C# is not C++, not PHP and not Delphi";
        Console.WriteLine(message);
        string[] words = message.Split(' ');

        Array.Reverse(words);
        foreach (var word in words)
        {
            Console.Write("{0} ",word);
        }
        Console.WriteLine();
    }
}
