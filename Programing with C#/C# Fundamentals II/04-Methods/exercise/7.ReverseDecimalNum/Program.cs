using System;
    class Program
    {
        static void Main()
        {
            //Write a method that reverses the digits of given decimal number. 
            Console.WriteLine("Enter decimal number");

            string enter = Console.ReadLine();
            char[] numbers = enter.ToCharArray();
            Console.Write("{0}->",enter);
            for (int i = 0; i < numbers.Length; i++)
            {

                Console.Write(numbers[numbers.Length - i-1]);
            }
            Console.WriteLine();
        }
    }
