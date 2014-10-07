using System;
    class Program
    {
        static void Main()
        {
            //Write a method that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).

            int[] arr = { 5, 1, 5, 3, 6, 5, 7, 5, 3, 3, 5 };

            Console.WriteLine("Enter position to check: ");
            int position = int.Parse(Console.ReadLine());

            CheckNeighbors(arr, position);
            
            
        }

        private static void CheckNeighbors(int[] arr, int position)
        {
            bool checkBig = false;

            if ((position > 0) && (position < arr.Length - 1))
            {
                if ((arr[position] > arr[position + 1]) || (arr[position] > arr[position - 1]))
                {
                    checkBig = true;
                }

                if (checkBig)
                {
                    Console.WriteLine("Element {0} of position {1} is bigger the its two neighbors", arr[position], position);
                }
                else
                {
                    Console.WriteLine("Element {0} of position {1} is not bigger than neigbors", arr[position], position);
                }
            }
            else
            {
                Console.WriteLine("Position is out of range to check!");
            }
        }
    }
