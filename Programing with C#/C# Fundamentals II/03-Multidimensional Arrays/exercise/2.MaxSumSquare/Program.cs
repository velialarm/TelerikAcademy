using System;
    class Program
    {
        static void Main()
        {
            //Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements

            int[,] matrix = 
            {
                {1,5,8,9,12,2},
                {6,2,5,3,56,1},
                {65,1,2,6,78,3}
            }; 
            
            //Find the maximal sum platform of size 3 x 3
            int maxSum = int.MinValue;
            int bestRow = 0;
            int bestCol = 0;

            for (int i = 0; i < matrix.GetLength(0)-2; i++)
            {

                for (int k = 0; k < matrix.GetLength(1)-2; k++)
                {
                    int sum = 0;
                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                             sum += matrix[i+x, k+y];
                        }
                    }
                    if (sum>maxSum)
                    {
                        maxSum = sum;
                        bestCol = i;
                        bestRow = k;

                    }
                }
                
            }

            //print result
            for (int i = 0; i < 3; i++)
            {
                string result = String.Join(",", matrix[bestCol, bestRow],bestRow,3);
                Console.WriteLine("{0}, {1}, {2}", matrix[bestCol + i, bestRow], matrix[bestCol + i, bestRow + 1], matrix[bestCol + i, bestRow+2]);
            }
            Console.WriteLine();

        }
    }