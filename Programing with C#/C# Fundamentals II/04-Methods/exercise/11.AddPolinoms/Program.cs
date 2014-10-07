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

            PrintPolinom(pol1);
            PrintPolinom(pol2);
        }

        private static void PrintPolinom(string[] pol1)
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
