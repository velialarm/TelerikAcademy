using System;
    class Program
    {
        //Write a method GetMax() with two parameters that returns the bigger of two integers. 
        //Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

        static void Main()
        {
            Console.Write("Enter number a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter number b: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Enter number c: ");
            int c = int.Parse(Console.ReadLine());
            int[] arr = { a,b,c};

            int max = 0;
            for (int i = 0; i < arr.Length-1; i++)
            {
                int x = arr[i];
                int y = arr[i + 1];
                max = GetMax(x, y);
            }
            Console.WriteLine("Bigest number is: ",max);

        }

        private static int GetMax(int x, int y)
        {
            int max = 0;
            if (x >= y)
            {
                max = x;
            }
            else
            {
                max = y;
            }
            return max;
        }
    }
