using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class DogeCoin
{
    //private static List<string> allMoves = new List<string>();
    private static int maxSum = 0;
    private static int[,] data;
    static void Main(string[] args)
    {
        if (File.Exists("input.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }
        string[] line = Console.ReadLine().Split();
        int n = int.Parse(line[0]);
        int m = int.Parse(line[1]);
        int numberOfCoins = int.Parse(Console.ReadLine());
        data = new int[n, m];
        for (int i = 0; i < numberOfCoins; i++)
        {
            line = Console.ReadLine().Split();
            int row = int.Parse(line[0]);
            int col = int.Parse(line[1]);
            data[row, col] += 1;
        }

        //int maxMove = m + n; // create Variation .... 

        //int maxSum = 0;
        //
        findPaths(n - 1, m - 1, "");
        //Console.WriteLine("Total possible paths: {0}", findPaths(n - 1, m - 1, ""));
        //for (int i = 0; i < allMoves.Count; i++)
        //{
        //    //Console.WriteLine(allMoves[i]);
        //    //read each path and execute 
        //    string[] coordinates = allMoves[i].Split(new char[]{' '},StringSplitOptions.RemoveEmptyEntries);
        //    int currentSum = 0;
        //    for (int pos = 0; pos < coordinates.Length; pos++)
        //    {
        //       string[] comm =  coordinates[coordinates.Length - pos - 1].Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries);
        //       int x = int.Parse(comm[0]);
        //       int y = int.Parse(comm[1]);
                
        //        //get sum from current cell in data
        //       currentSum += data[x, y];
        //    }
        //    if (maxSum<currentSum)
        //    {
        //        maxSum = currentSum;
        //    }
        //}
        Console.WriteLine(maxSum);
    }

    private static int findPaths(int n, int m, string path)
    {
        path = path + n + "," + m + "  ";
        //path.Append(path).Append(down).Append(",").Append(right).Append(" ");
        if (n == 0 && m == 0)
        {
            //Console.WriteLine(path);
            //allMoves.Add(path);

            string[] coordinates = path.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int currentSum = 0;
            for (int pos = 0; pos < coordinates.Length; pos++)
            {
                string[] comm = coordinates[coordinates.Length - pos - 1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                int x = int.Parse(comm[0]);
                int y = int.Parse(comm[1]);

                //get sum from current cell in data
                currentSum += data[x, y];
            }
            if (maxSum < currentSum)
            {
                maxSum = currentSum;
            }


            return 1;
        }

        int counter = 0;

        if (n == 0)
            counter = findPaths(n, m - 1, path);
        else if (m == 0)
            counter = findPaths(n - 1, m, path);
        else
            counter = findPaths(n, m - 1, path) + findPaths(n - 1, m, path);

        return counter;
    }
}

