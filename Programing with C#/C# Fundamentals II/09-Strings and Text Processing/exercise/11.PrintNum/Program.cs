//Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation. 
//Format the output aligned right in 15 symbols.

using System;
    class Program
    {
        static void Main()
        {
            // reads a number
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            //decimal number
            Console.WriteLine("Decimal number: {0,15}", number);
            //hexadecimal number
            Console.WriteLine("Hexadecimal number: {0,15:X}", number);
            //percentage
            Console.WriteLine("Percentage: {0,15:P}", number);
            //scientific notation
            Console.WriteLine("Scientific notation: {0,15:E}", number);
        }
    }