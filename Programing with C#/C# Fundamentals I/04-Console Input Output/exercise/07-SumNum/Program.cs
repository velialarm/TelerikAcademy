using System;

    class Program
    {
        static void Main()
        {
            //Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. 

            Console.Write("Enter of input digit: ");
            int n = int.Parse(Console.ReadLine());

            int suma = 0;

            for (int i = 0; i < n; i++ ) {
                Console.Write("Enter digit {0} : ",i+1);
                int moreNum = int.Parse(Console.ReadLine());

                suma += moreNum;
            }
            Console.WriteLine("Sum of all n numbers is: {0}", suma);
        }
    }
