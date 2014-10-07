using System;
    class Program
    {
        static void Main()
        {
            //Write a program that reads two integer numbers N and K and an array of N elements from the console. 
            //Find in the array those K elements that have maximal sum.
            int maxSum = 0;
            Console.Write("Enter number N elements of array: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter number K of elements to check it sum: ");
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter {0} element of arrays:");
                arr[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n-k+1; i++)
            {
                int sum = 0;
                for (int j = 0; j < k; j++)
			    {
			     sum += arr[i+j];
			    }
                if (sum>maxSum)
                {
                    maxSum = sum;
                }
            }
            Console.WriteLine("Maximum sum is {0}",maxSum);

            
        }
    }
