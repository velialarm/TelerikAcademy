using System;
    class Program
    {
        static void Main()
        {

            //Write a program that finds the maximal increasing sequence in an array

            int[] numbers = { 3, 2, 3, 4, 2, 2, 4 };
            int size = numbers.Length;

            int position = 0;

            int maxValue = 0;
            int maxPos = 0;
            int curVal = numbers[0];

            for (int i = 1; i < size; i++)
            {
                if (curVal + 1 == numbers[i])
                {
                    position ++;
                }
                else
                {
                    position = 0;
                }
                if ((position>0)&&(position>maxPos))
                {
                    maxPos = position;
                    maxValue = i;
                }

                curVal = numbers[i];
            }
            for (int i = maxValue-maxPos; i <= maxValue; i++)
            {
                Console.Write("{0} ",numbers[i]);
            }

        }
    }
