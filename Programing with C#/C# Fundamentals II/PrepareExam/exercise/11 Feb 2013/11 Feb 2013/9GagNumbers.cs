using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

    class GagNumbers
    {
        private static string[] gagNum = new string[] { "-!", "**", "!!!", "&&", "&-", "!-", "*!!!", "&*!", "!!**!-" };
        private static List<int> listNum = new List<int>();
        static void Main(string[] args)
        {
            if (File.Exists("input.txt"))
            {
                Console.SetIn(new StreamReader("input.txt"));
            }

            //read and parse it
            string input = Console.ReadLine();
            int startPos = 0;
            string num;
            int numValue=-2;
           
            while (true)
            {

                if (input.Length == startPos)
                {
                    break;
                }

                //for 2    
                num = input.Substring(startPos,2);
                //num = "!!!";
                numValue = CheckExistFromAll(num);
                if (numValue != -1)
                {
                    listNum.Add(numValue);
                    startPos = startPos + 2;
                    continue;
                }

                //for 3
                num = input.Substring(startPos, 3);
                if (num == "&*!")
                {
                    numValue = 7;
                    listNum.Add(numValue);
                    startPos = startPos + 3;
                    continue;
                }
                else if (num == "!!!")
                {
                    numValue = 2;
                    listNum.Add(numValue);
                    startPos = startPos + 3;
                    continue;
                }
                
                //for 4
                num = input.Substring(startPos, 4);
                if (num == "*!!!")
                {
                    numValue = 6;
                    listNum.Add(numValue);
                    startPos = startPos + 4;
                    continue;
                }
                //for 6
                num = input.Substring(startPos, 6);
                if (num == "!!**!-")
                {
                    numValue = 8;
                    listNum.Add(numValue);
                    startPos = startPos + 6;
                    continue;
                }
          
            }
            BigInteger sum = 0;
            //calculate number
            for (int i = 0; i < listNum.Count; i++)
            {
                BigInteger.Pow(9, listNum.Count - i - 1);
                BigInteger stepen = Pow(listNum.Count - i - 1); // BigInteger.Pow(9, listNum.Count - i - 1);
                BigInteger fnum = (BigInteger)listNum[i];
                sum += (fnum * stepen);
            }
            Console.WriteLine(sum);

        }
        private static BigInteger Pow(int power) {
            BigInteger result = 1;
            for (int i = 0; i < power; i++)
            {
                result *= 9;
            }
            return result;
        }
        private static int CheckExistFromAll(string num)
        {
            for (int i = 0; i < gagNum.Length; i++)
            {
                if (gagNum[i] == num)
                {
                    return i;
                }
            }

            return -1;
        }
    }

