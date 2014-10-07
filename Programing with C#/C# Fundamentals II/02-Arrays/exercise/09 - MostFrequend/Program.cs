using System;
    class Program
    {
        static void Main()
        {
            //Write a program that finds the most frequent number in an array

            int[] numbers = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };

            int count = 0;
            int maxCount = 0;
            int maxVal = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int k = 1; k < numbers.Length; k++)
                {
                    if (numbers[k] == numbers[i])
                    {
                        count++;
                    }
                    if (count>maxCount)
                    {
                        maxCount = count;
                        maxVal = i;
                    }
                }
                count = 0;
            }

            Console.WriteLine("{0} ({1} times)",numbers[maxVal],maxCount+1);

        }
    }
