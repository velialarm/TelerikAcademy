//Write a program that reads a text file containing a square matrix of numbers and 
//finds in the matrix an area of size 2 x 2 with a maximal sum of its elements. 
//The first line in the input file contains the size of matrix N. 
//Each of the next N lines contain N numbers separated by space. 
//The output should be a single number in a separate text file.

using System;
using System.IO;
    class Program
    {
        static void Main()
        {
            string fileIn = "input.txt";
            string output = "output.txt";
            StreamReader sr = new StreamReader(fileIn);
            StreamWriter sw = new StreamWriter(output);
            using (sr)
            {
                int n = int.Parse(sr.ReadLine());
                //Console.WriteLine(n);

                string[,] numbers = new string[n, n];
                int sum = 0;
                int maxsum = 0;
                for (int i = 0; i < n; i++)
                {
                    string[] line = sr.ReadLine().Split(' ');
                    for (int j = 0; j < n; j++)
			        {
                        numbers[i, j] = line[j];
                        //Console.WriteLine("Line {0}",numbers[i, j]);
                        if (i>=1 && j>=1)
                        {
                            sum = int.Parse(numbers[i, j]) + int.Parse(numbers[i - 1, j]) + int.Parse(numbers[i, j - 1]) + int.Parse(numbers[i - 1, j - 1]);
                            if (sum>maxsum)
                            {
                                maxsum = sum;
                            }
                        }
			        }
                }
                using (sw)
                {
                    sw.WriteLine(maxsum);
                }
                //Console.WriteLine(maxsum);
            }
        }
    }
