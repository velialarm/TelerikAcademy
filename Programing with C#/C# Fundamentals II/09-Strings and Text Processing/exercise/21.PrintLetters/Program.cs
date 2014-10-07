//Write a program that reads a string from the console and 
//prints all different letters in the string along with information 
//how many times each letter is found.
using System;
using System.Text;
using System.Linq;
    class Program
    {
        static void Main()
        {
            Console.Write("Enter string: ");
            string text = Console.ReadLine();

            foreach (var letter in text.GroupBy(c => c))
            {
                Console.WriteLine("{0} = {1}", letter.Key, letter.Count());
            }

        }
    }
