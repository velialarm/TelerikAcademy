using System;
    class Program
    {
        static void Main()
        {
            //Write a program that finds the maximal sequence of equal elements in an array.

           int[] numbers = { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
           int[] check = new int[numbers.Length];
           int size = numbers.Length;
            int curEl = numbers[0];
            int max = 0;
            int curCh = 0;
            bool change = true;
           for (int i = 1; i < size; i++)
           {
               if (curEl == numbers[i])
               {
                   max++;
                   if (change)
                   {
                       curCh = i - 1;
                       change = false;
                   }
               }
               else
               {
                   check[i-1] = max;
                   max = 0;
                   change = true;
               }
               curEl = numbers[i];

           }
           curEl = check[0];
           for (int i = 1; i < size; i++)
           {
               //find max
               if ((curEl<check[i])&&(check[i]>0))
	            {
                    max = i;
                    curEl = check[i];
	            }
           }
           int curPos = check[max]+1;
           Console.Write("{");
           for (int i = 0; i < curPos; i++)
           {
               if (i + 1 == curPos)
               {
                   Console.Write("{0}", numbers[max - curPos + i + 1]);
               }
               else
               {
                   Console.Write("{0}, ", numbers[max - curPos + i + 1]);
               }
               
           }
           Console.WriteLine("}");
        }
    }
