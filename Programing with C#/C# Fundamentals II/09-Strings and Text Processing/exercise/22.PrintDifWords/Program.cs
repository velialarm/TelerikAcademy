//Write a program that reads a string from the console and lists all different words in the string along 
//with information how many times each word is found.

using System;
using System.Linq;
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter string: ");
            string input = Console.ReadLine();
            char[] separate = { ' ', '.', ',' };
            string[] words = input.Split(separate,StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words.GroupBy(c=>c))
            {
                if (word.Key.Length>1)
                {
                    Console.WriteLine("{0} = {1}", word.Key, word.Count());    
                }
                
            }

        }
    }
