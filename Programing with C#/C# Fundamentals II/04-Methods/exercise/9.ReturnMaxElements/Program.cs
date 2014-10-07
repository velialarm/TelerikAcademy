using System;
using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            //Write a method that return the maximal element in a portion of array of integers starting at given index. 

            int[] elements = { 5, 67, 12, 6, 7, 78, 123, 5, 8, 3, 78, 9 };

            Console.Write("Enter portion of elements: ");
            int portion = int.Parse(Console.ReadLine());
            Console.Write("Enter starting index: ");
            int index = int.Parse(Console.ReadLine());

            MaxElements(elements, portion, index);

        }

        private static void MaxElements(int[] elements, int portion, int index)
        {
            int[] arr = new int[portion];
            int x = 0;
            for (int i = index; i < portion + index; i++)
            {
                arr[x] = elements[i];
                //Console.WriteLine(elements[i]);
                x++;
            }
            Array.Sort(arr);
            Console.WriteLine("Maximal element is {0} on position {1}", arr[arr.Length - 1], arr.Length - 1);
        }
    }
