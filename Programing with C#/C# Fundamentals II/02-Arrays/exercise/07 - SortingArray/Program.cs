using System;
    class Program
    {
        static void Main()
        {
            //Sorting an array means to arrange its elements in increasing order. 
            //Write a program to sort an array. Use the "selection sort" algorithm: 
            //Find the smallest element, move it at the first position, find the smallest from the rest, move it at the second position, etc.

            Console.Write("Enter number N elements of array: ");
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter {0} elements of arrays:");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    if ((numbers[i]<numbers[k])&&(i!=k))
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[k];
                        numbers[k] = temp; 
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine( numbers[i] ); 
            }
        }
    }
