using System;
    class Program
    {
        static void Main()
        {
            //Write a method that counts how many times given number appears in given array. 
            //Write a test program to check if the method is working correctly.

            //generate random arrays

            int[] arr = { 5, 1, 5, 3, 6, 5, 7, 5, 3, 3, 5 };

            TimesAppears(arr);

        }

        private static void TimesAppears(int[] arr)
        {
            Array.Sort(arr);
            int count = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {

                if (arr[i] == arr[i + 1])
                {
                    count++;
                }
                else
                {
                    Console.WriteLine("Number {0} -> {1} times", arr[i], count + 1);
                    count = 0;
                }
            }
        }
    }
