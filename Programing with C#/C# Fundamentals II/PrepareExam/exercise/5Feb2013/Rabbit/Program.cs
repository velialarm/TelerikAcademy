using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        //string line = "1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 0";
        string line = Console.ReadLine();
        string[] strNums = line.Split(new char[]{',',' '},StringSplitOptions.RemoveEmptyEntries);
        int countNums = strNums.Length;
        int[] numbers = new int[countNums];
        bool[] reserved;
        for (int i = 0; i < strNums.Length; i++)
        {
            numbers[i] = int.Parse(strNums[i]);
        }

        int maxStep = int.MinValue;

        //each position
        for (int numPosFrom = 0; numPosFrom < countNums ; numPosFrom++)
        {
            //get steps
            for (int step = 1; step < countNums; step++)
            {
                //Console.WriteLine("{0} - {1}", i, numbers[i]);
                int curPos = numPosFrom;
                reserved = new bool[countNums];
                //int curPos = 6;
                int nextPos = curPos + step;
                if (nextPos >= countNums)
                {
                    nextPos = nextPos - countNums;
                }
                int curStep = 0;
                reserved[curPos] = true;
                //create while step in circle
                while (true)
                {
                    if (numbers[curPos] < numbers[nextPos]
                        && !reserved[nextPos])
                    {
                        curStep++;
                        reserved[nextPos] = true;
                        curPos = nextPos;
                        nextPos += step;
                        if (nextPos >= countNums)
                        {
                            nextPos = nextPos - countNums;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                if (curStep > maxStep)
                {
                    maxStep = curStep;
                }
            }
        }
        Console.WriteLine(maxStep+1);
    }
}
