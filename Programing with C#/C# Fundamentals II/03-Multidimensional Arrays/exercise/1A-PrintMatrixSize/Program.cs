using System;
    class Program
    {
        static void Main()
        {

            int[,] arr1 = new int[4, 4];
            int[,] arr2 = new int[4, 4];
            int[,] arr3 = new int[4, 4];
            int[,] arr4 = new int[4, 4];

            CreateMatrixA(arr1);
            CreateMatrixB(arr2);
            CreateMatrixC(arr3);
            CreateMatrixD(arr4);

            PrintMe(arr1);
            PrintMe(arr2);
            PrintMe(arr3);
            PrintMe(arr4);
        }

        private static void CreateMatrixD(int[,] matrix)
        {
            //x,y   x, y+size-1
            //x+1, y+size-1     x+size-1, y+size-1
            //x+size-1, y+size-2    x+size-1, y
            //x+size-2, y   x+1, y
            int x = 0, y = 0, index = 4;
            int currentCount = 1;
            while (index > 0)
            {
                for (int i = y; i <= y + index - 1; i++)
                {
                    matrix[x, i] = currentCount++;
                }

                for (int j = x + 1; j <= x + index - 1; j++)
                {
                    matrix[j, y + index - 1] = currentCount++;
                }

                for (int i = y + index - 2; i >= y; i--)
                {
                    matrix[x + index - 1, i] = currentCount++;
                }

                for (int i = x + index - 2; i >= x + 1; i--)
                {
                    matrix[i, y] = currentCount++;
                }

                x = x + 1;
                y = y + 1;
                index = index - 2;
            }
        }

        private static void CreateMatrixB(int[,] arr)
        {
            int printNum = 1;
            int row = arr.GetLength(0);
            int col = arr.GetLength(1);
            for (int i = 0; i < row; i++)
            {

                for (int k = 0; k < col; k++)
                {
                    if (i % 2 == 1)
                    {
                        arr[col - k - 1, i] = printNum;
                    }
                    else
                    {
                        arr[k, i] = printNum;
                    }
                    printNum++;
                }
            }

        }

        private static void CreateMatrixA(int[,] arr)
        {
            int printNum = 1;
            int row = arr.GetLength(0);
            int col = arr.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int k = 0; k < col; k++)
                {
                    arr[k, i] = printNum;
                    printNum++;
                }
            }
        }

        private static void PrintMe(int[,] arr)
        {
            int row = arr.GetLength(0);
            int col = arr.GetLength(1);
            for (int i = 0; i < row; i++)
            {
                for (int k = 0; k < col; k++)
                {
                    Console.Write("{0} ", arr[i, k]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n{0}\n", new string('-', arr.Length));
        }

        private static void CreateMatrixC(int[,] arr)
        {
            int printMe = 1;
            int row = arr.GetLength(0);
            int col = arr.GetLength(1);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    arr[j, i - j] = printMe;
                    //Console.Write("{0} ", printMe);
                    printMe++;
                }
                //Console.WriteLine();
            }

            for (int i = 1; i < col; i++)
            {
                for (int j = 0; j < col - i; j++)
                {
                    arr[i + j, col - j - 1] = printMe;
                    //Console.Write("{0} ", printMe);
                    printMe++;
                }
                //Console.WriteLine();
            }
        }
       
    }
