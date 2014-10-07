using System;

    class Program
    {

        //Write a program that calculates for given N how many trailing zeros present at the end of the number N!.

        static void Main(string[] args)
        {
            Console.Write("Enter Spiral Matrix Number: ");
            int n = int.Parse(Console.ReadLine());
            int[,] result = new int[n, n];
            int pos = 1;
            int count = n;
            int value = -n;
            int sum = -1;

            do
            {
                value = -1 * value / n;
                for (int i = 0; i < count; i++)
                {
                    sum += value;
                    result[sum / n, sum % n] = pos++;
                }
                value *= n;
                count--;
                for (int i = 0; i < count; i++)
                {
                    sum += value;
                    result[sum / n, sum % n] = pos++;
                }
            } while (count > 0);


            int k = (result.GetLength(0) * result.GetLength(1) - 1).ToString().Length + 1;
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write(result[i, j].ToString().PadLeft(k, ' '));
                }
                Console.WriteLine();
            }

        }

        
    }
