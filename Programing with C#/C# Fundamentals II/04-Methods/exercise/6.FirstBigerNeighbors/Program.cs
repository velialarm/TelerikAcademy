using System;
    class Program
    {
        static void Main()
        {
            //Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.

            int[] arr = { 5, 1, 5, 3, 6, 5, 7, 5, 3, 3, 5 };

            FirstBigerNeighbors(arr);
            
        }

        private static void FirstBigerNeighbors(int[] arr)
        {
            for (int i = 1; i < arr.Length - 1; i++)
            {
                int index = CheckNeighbors(arr, i);
                if (index > 0)
                {
                    Console.WriteLine("First bigest number than its neighbors is {0} on position {1}", arr[i], i);
                    break;
                }
            }
        }

        private static int CheckNeighbors(int[] arr, int position)
        {
            bool checkBig = false;
            int x = -1;
            if ((position > 0) && (position < arr.Length - 1))
            {
                if ((arr[position] > arr[position + 1]) || (arr[position] > arr[position - 1]))
                {
                    checkBig = true;
                }

                if (checkBig)
                {
                    x = 1;
                }
            }
            return x;
        }
 }
  
