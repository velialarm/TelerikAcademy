using System;
    class Program
    {
        static void Main()
        {
            //Write a program that finds in given array of integers a sequence of given sum S
            int[] numebers = { 4,3,1,4,2,5,8};
            int sum = 11;
            int posStart = 0;
            int posEnd = 0;
            bool exFor = false;
            for (int i = 0; i < numebers.Length; i++)
            {
                int curSum = 0;
                for (int k = i ; k < numebers.Length; k++)
                {
                    curSum += numebers[k];


                    if (curSum == sum)
                    {
                        exFor = true;
                        posStart = i;
                        posEnd = k;
                    }
                }
                if (exFor)
                {
                    break;
                }
            }
            for (int i = posStart; i <= posEnd; i++)
            {
                Console.Write("{0} ",numebers[i]); 
            }
        }
    }
