using System;
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Enter number: ");
            string n = Console.ReadLine();

            LastDigit(n);
           
        }

        private static void LastDigit(string n)
        {
            string result = n.Substring(n.Length-1,1);
            string[] digits = { "zero","one", "two", "tree", "four", "five", "six", "seven", "eight", "nine" };
            Console.WriteLine("{1}->\"{0}\"",digits[int.Parse(result)],n);
        }
    }
