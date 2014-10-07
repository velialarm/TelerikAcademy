using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

class StrangeLandNumbers
{
    //private static string[] numbers = new string[] {"f","bIN","oBJEC","mNTRAVL","lPVKNQ","pNWE","hT" };

    private static Dictionary<string, int> numbers = new Dictionary<string, int>();
    private static void InitDic() {
        numbers.Add("f", 0);
        numbers.Add("bIN", 1);
        numbers.Add("oBJEC", 2);
        numbers.Add("mNTRAVL", 3);
        numbers.Add("lPVKNQ", 4);
        numbers.Add("pNWE", 5);
        numbers.Add("hT", 6);
    }
    static void Main(string[] args)
    {
        if (File.Exists("input.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }
        InitDic();
        string line = Console.ReadLine();

        List<int> resNum = new List<int>();
        StringBuilder buffer = new StringBuilder();
        //int starIndex = 0;
        //buffer.Append(line.Substring(0, 1));
        for (int i = 0; i < line.Length; i++)
        {
            string curChar = line.Substring(i,1);
            buffer.Append(curChar);
            if (numbers.ContainsKey(buffer.ToString()))//found in buffer
            {
                int n = numbers[buffer.ToString()];
                resNum.Add(n);
                buffer.Clear();
            }
       
        }
        BigInteger sum = 0;
        //calculate number
        for (int i = 0; i < resNum.Count; i++)
        {
            
            //BigInteger stepen = BigInteger.Pow(7, resNum.Count - i - 1);
            BigInteger stepen = Pow(resNum.Count - i - 1); // BigInteger.Pow(9, listNum.Count - i - 1);
            BigInteger fnum = (BigInteger)resNum[i];
            sum = BigInteger.Add(sum, (BigInteger.Multiply(fnum, stepen)));
        }
        Console.WriteLine(sum);

    }

    private static BigInteger Pow(int power)
    {
        BigInteger result = 1;
        for (int i = 0; i < power; i++)
        {
            result *= 7;
        }
        return result;
    }
}

