//Write a program that reads an integer number and calculates and prints its square root. 
//If the number is invalid or negative, print "Invalid number". 
//In all cases finally print "Good bye". Use try-catch-finally.

using System;
    class Program
    {
        static void Main()
        {
            Console.Write("Enter integer number: ");
            uint number = 0;
            try
            {
                number = uint.Parse(Console.ReadLine());
                double calculateSquare = CalcSquare(number);
                PrintResult(calculateSquare);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
           
            
        }

        private static void PrintResult(double calculateSquare)
        {
            Console.WriteLine("Result of square root is {0}",calculateSquare);
        }

        private static double CalcSquare(uint number)
        {
            double calculateSquare = Math.Sqrt((double)number);
            return calculateSquare;
        }
    }
