using System;
    class Program
    {
        static void Main()
        {
            //We are given a matrix of strings of size N x M. 
            //Sequences in the matrix we define as sets of several neighbor elements located on the same line, column or diagonal. 
            //Write a program that finds the longest sequence of equal strings in the matrix
            
            string[,] arr = 
            {
                {"ha","to","to","op"},
                {"to","yu","pa","as"},
                {"ha","yu","ha","jk"},
                {"ha","to","ha","ty"}, 

            }; //  matrix of strings of size N x M
            int maxLengt = 0;
            string maxResult = "";
            int row = arr.GetLength(1);
            int col = arr.GetLength(0);
           
            // check column

            for (int i = 0; i < col; i++)
            {
                int count = 0;
                string result = "";
                for (int k = 1; k < row; k++)
                {
                    if (arr[i, k] == arr[i, k - 1])
                    {
                        count++;
                        if (result == "")
                        {
                            result += arr[i, k - 1] + "," + arr[i,k];
                        }
                        else
                        {
                            result += "," + arr[i,k];
                        }
                    }
                    else 
                    {
                        count = 0;
                    }
                }
                if (count > maxLengt)
                {
                    maxLengt = count;
                    maxResult = result;
                }
            }

            // check row
            for (int i = 0; i < row; i++)
            {
                int count = 0;
                string result = "";
                for (int k = 1; k < col; k++)
                {
                    if (arr[k-1, i] == arr[k, i])
                    {
                        count++;
                        if (result == "")
                        {
                            result += arr[k-1, i] + "," + arr[k, i];
                        }
                        else
                        {
                            result += "," + arr[k, i];
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }
                if (count > maxLengt)
                {
                    maxLengt = count;
                    maxResult = result;
                }
            }


            // check diagonal


            for (int i = 0; i < row; i++)
            {
                int count = 0;
                string result = "";
                string temp = arr[0, i];
                for (int j = 0; j < i + 1; j++)
                {
                    if (temp == arr[j, i - j])
                    {
                        temp = arr[j, i - j];
                        count++;
                        if (result == "")
                        {
                            result += temp + "," + arr[j, i - j];
                        }
                        else
                        {
                            result += "," + arr[j, i - j];
                        }
                    }
                    else
                    {
                        count = 0;
                        result = "";
                    }
                    if (count > maxLengt)
                    {
                        maxLengt = count;
                        maxResult = result;
                    }
                    // Console.WriteLine(" {0}= {1}", count+1, result);
                }
                if (count > maxLengt)
                {
                    maxLengt = count;
                    maxResult = result;
                }

                //Console.WriteLine();
            }

            for (int i = 1; i < col; i++)
            {
                int count = 0;
                string result = "";
                string temp = arr[i, col - 1];
                for (int j = 0; j < col - i; j++)
                {
                    if (temp == arr[i + j, col - j - 1])
                    {
                        temp = arr[i + j, col - j - 1];
                        count++;
                        if (result == "")
                        {
                            result += temp + "," + arr[i + j, col - j - 1];
                        }
                        else
                        {
                            result += "," + arr[i + j, col - j - 1];
                        }
                    }
                    else
                    {
                        count = 0;
                        result = "";
                    }
                    // Console.WriteLine(" {0}- {1}", count + 1, result);
                }
                if (count > maxLengt)
                {
                    maxLengt = count;
                    maxResult = result;
                }
                //Console.WriteLine();
            }

            Console.WriteLine(maxResult);
        }
    }
