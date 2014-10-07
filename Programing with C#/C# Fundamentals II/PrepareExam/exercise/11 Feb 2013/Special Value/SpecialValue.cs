using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class SpecialValue
{
    static void Main(string[] args)
    {
        if (File.Exists("input.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }
        int n = int.Parse(Console.ReadLine());

        //jack array read...
        int[][] field = new int[n][];
        field = ReadData(field);

        //find paths

    }
    static int[][] ReadData(int[][] field) {

        for (int i = 0; i < field.GetLength(0); i++)
        {
            string[] currentLine = Console.ReadLine().Split(new char[]{ ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            field[i] = new int[currentLine.Length];

            for (int d = 0; d < currentLine.Length; d++)
            {
                field[i][d] = int.Parse(currentLine[d]);
            }
        }
        return field;
    }
}

