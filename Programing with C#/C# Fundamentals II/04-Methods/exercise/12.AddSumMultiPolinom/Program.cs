using System;
    class Program
    {
        static void Main()
        {
            Console.Write("Enter coefficients of first polinom with space:");
            string[] pol1 = Console.ReadLine().Split(' ');
            Array.Reverse(pol1);
            Console.Write("Enter coefficients of second polinom with space:");
            string[] pol2 = Console.ReadLine().Split(' ');
            Array.Reverse(pol2);

            int[] result = MultiPoligon(pol1, pol2);

            PrintPolinom(result);
            result = SubPolinom(pol1, pol2);
            PrintPolinom(result);
        }

        private static int[] MultiPoligon(string[] pol1, string[] pol2)
        {
            //multiplication polinom
            int min = 0;
            int max = 0;
            bool first = true;
            if (pol1.Length >= pol2.Length)
            {
                max = pol1.Length;
                min = pol2.Length;
            }
            else
            {
                min = pol1.Length;
                max = pol2.Length;
                first = false;
            }
            int diferen = max - min;
            int[] result = new int[max];
            for (int i = 0; i < min; i++)
            {
                result[i] = int.Parse(pol1[i]) * int.Parse(pol2[i]);
            }
            for (int i = min; i < max; i++)
            {
                if (first)
                {
                    result[i] = int.Parse(pol1[i]);
                }
            }
            return result;
        }

        private static int[] SubPolinom(string[] pol1, string[] pol2)
        {
            //subtraction polinom
            int min = 0;
            int max = 0;
            bool first = true;
            if (pol1.Length >= pol2.Length)
            {
                max = pol1.Length;
                min = pol2.Length;
            }
            else
            {
                min = pol1.Length;
                max = pol2.Length;
                first = false;
            }
            int diferen = max - min;
            int[] result = new int[max];
            for (int i = 0; i < min; i++)
            {
                result[i] = int.Parse(pol1[i]) + int.Parse(pol2[i]);
            }
            for (int i = min; i < max; i++)
            {
                if (first)
                {
                    result[i] = int.Parse(pol1[i]);
                }
            }
            return result;
        }

        private static void PrintPolinom(int[] pol1)
        {
            for (int i = 0; i < pol1.Length; i++)
            {
                //string[] x = { "","x" };
                if (i != pol1.Length - 1)
                {
                    Console.Write("{0}x^{1}+", pol1[pol1.Length - i - 1], pol1.Length - i - 1);
                }
                else
                {
                    Console.Write("{0}", pol1[pol1.Length - i - 1]);
                }
            }
            Console.WriteLine();
        }
    }
