//Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one. 
//Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".
using System;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string: ");
            //string input = "aaaaabbbbbcdddeeeedssaa";
            string input = Console.ReadLine();
            int length = input.Length;
            char bef = input[0];
            Console.Write(input[0]);
            for (int i = 1; i < length; i++)
			{
                if (bef!=input[i])
	            {
                    Console.Write(input[i]);
	            }
                bef = input[i];
			}
        }
    }
