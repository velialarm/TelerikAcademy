using System;
    class Program
    {
        static void Main()
        {
            //Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N]. 
            Console.Write("Enter N for generate permutation: ");
            int n = int.Parse(Console.ReadLine());
            int[] used = new int[n];
            int[] per = new int[n];
            int i;
            for (i = 0; i < n; i++) 
            {
                used[i] = 0;
            }

            Permute(0, n,used, per);
        }

        private static void Permute(int i,int n, int[] used, int[] per)
        {
            if (i >= n)
            {
                PrintMe(n, per);
            }
            for (int k = 0; k < n; k++)
            {
                if (used[k] == 0)
                {
                    used[k] = 1;
                    per[i] = k;
                    Permute(i + 1,n,used,per); 
                    used[k] = 0;
                }
            }
        }

        private static void PrintMe(int n, int[] per)
        {
            for (int x = 0; x < n; x++)
            {
                char znak1 = '{';
                char znak2 = '}';
                if (x==0)
                {
                    Console.Write("{1}{0}, ", per[x] + 1, znak1);
                }
                else if (n - 1 == x)
                {
                    Console.Write("{0}{1}", per[x] + 1, znak2);
                }
                else 
                {
                    Console.Write("{0}, ", per[x] + 1);
                }
            }
            Console.WriteLine(",");
        }
    }
