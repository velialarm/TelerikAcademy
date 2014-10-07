using System;
    class Program
    {
        static void Main()
        {
            //Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).

            Console.Write("Enter base of number s: ");
            int s = int.Parse(Console.ReadLine());
            Console.Write("Enter number to convert: ");
            string n = Console.ReadLine();
            Console.Write("Enter system to convert base d:");
            int d = int.Parse(Console.ReadLine());

           
            if (s < 2 || d < 2 || s > 16 || d > 16)
            {
                Console.WriteLine("The numeral systems must be in the range [2 .. 16]");
                return;
            }

            //to Decimal

            int temp = ConvertFromDec(d, ToDecimal(s, n));
            Console.WriteLine(temp);
        }

        private static int ConvertFromDec(int d, int todec)
        {
            int temp;
            if (d < 10)
            {
                //DecToBin
                string result = string.Empty;
                while (todec > 0)
                {
                    temp = todec % 2;
                    todec /= 2;
                    result = temp.ToString() + result;
                }
                temp = int.Parse(result);
            }
            else
            {
                //DecToHex
                temp = int.Parse(todec.ToString("X"));
            }
            return temp;
        }

        private static int ToDecimal(int s, string n)
        {
            int decNum = 0;
            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] > '9')
                {
                    decNum += (n[i] - '7') * (int)Math.Pow(s, (n.Length - 1 - i));
                }
                else
                {
                    decNum += (n[i] - '0') * (int)Math.Pow(s, (n.Length - 1 - i));
                }
            }
            return decNum;
        }
    }
