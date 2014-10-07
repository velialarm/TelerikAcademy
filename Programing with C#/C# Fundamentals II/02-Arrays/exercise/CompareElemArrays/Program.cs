using System;
    class CompareElements
    {
        static void Main()
        {
            //Write a program that reads two arrays from the console and compares them element by element.

            Console.WriteLine("Enter elements of two arrays for compare!");
            Console.Write("Enter N element of arrays: ");
            int n = int.Parse(Console.ReadLine());

            int[] arr1 = new int[n];
            int[] arr2 = new int[n];

            Console.WriteLine();
            Console.WriteLine("Enter Elements of first array");
            for (int i = 0; i < n; i++)
            {
                arr1[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter Elements of second array");
            for (int i = 0; i < n; i++)
            {
                arr2[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                if (arr1[i] > arr2[i])
                {
                    Console.WriteLine("{0} Element - {1} > {2}", i + 1, arr1[i], arr2[i]);
                }
                else
                {
                    if (arr1[i] < arr2[i])
                    {
                        Console.WriteLine("{0} Element - {1} < {2}", i + 1, arr1[i], arr2[i]);
                    }
                    else
                    {
                        Console.WriteLine("{0} Element - {1} = {2}", i + 1, arr1[i], arr2[i]);
                    }
                }
            }
        }
    }
