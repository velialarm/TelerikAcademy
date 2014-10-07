//Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.

using System;

    class Program
    {
        static void Main()
        {
            string text = "maina, gusto, napred, istok, zapad, garvan, analis, stol";
            char[] separatet = { ' ',','};
            string[] words = text.Split(separatet,StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(words);
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
