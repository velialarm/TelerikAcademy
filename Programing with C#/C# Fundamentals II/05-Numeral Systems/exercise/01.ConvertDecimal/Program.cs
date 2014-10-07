using System;
    class Program
    {
        static void Main()
        {
            //Write a program to convert decimal numbers to their binary representation.

            Console.WriteLine("Enter number: ");
            int number = int.Parse(Console.ReadLine());

            int temp;
            string result = string.Empty;
            while (number > 0)
            {
                temp = number % 2;
                number /= 2;
                result = temp.ToString() + result;
            }
            Console.WriteLine("Binary representation:  {0}", result);
        }
    }