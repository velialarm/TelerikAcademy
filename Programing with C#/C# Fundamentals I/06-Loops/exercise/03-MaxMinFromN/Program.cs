using System;

    class Program
    {
        static void Main(string[] args)
        {
            //Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

            Console.WriteLine("Enter how many numbers you will enter:" );
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n+1];
            int min = 0;
            int max = 0;
            for (int i = 0; i <= n; i++)
			{
                Console.Write("Enter digit to comare: ");
                numbers[i] = int.Parse(Console.ReadLine());
                if (i == 0)
                {
                    max = numbers[i];
                    min = numbers[i];
                }
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
                if(numbers[i]<min)
                {
                    min = numbers[i];
                }
                Console.WriteLine("{0}. You enter: {1} and maximal = {2} and minimal = {3}",i+1,numbers[i], max, min);
			}

           

            
        }
    }
