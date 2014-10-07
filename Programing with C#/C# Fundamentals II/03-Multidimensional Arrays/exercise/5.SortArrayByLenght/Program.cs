using System;
    class Program
    {
        static void Main()
        {
            string[] arr = { "gusto", "maina,", "ko staaa", "talasami", "kucheta", "opaa" };

            SortByLenght(arr);

            PrintMe(arr);
        }

        private static void PrintMe(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        private static void SortByLenght(string[] arr)
        {
            Array.Sort(arr, (x, y) => x.Length.CompareTo(y.Length));
        }
    }
