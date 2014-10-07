using System;

    class task12
    {
        static void Main()
        {
            //We are given integer number n, value v (v=0 or 1) and a position p. 
            // Write a sequence of operators that modifies n to hold the value v at the position p from the binary representation of n.
	        //Example: n = 5 (00000101), p=3, v=1 -> 13 (00001101) n = 5 (00000101), p=2, v=0 -> 1 (00000001)

            Console.Write("Enter integer digit n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter integer digit p: ");
            int p = int.Parse(Console.ReadLine());
            Console.Write("Enter integer digit v: ");
            int v = int.Parse(Console.ReadLine());
            int mask = 1 << p;
            int maskIf = (mask & n) != 0 ? 1 : 0; //determine the bit in position p
            int res;
            if (maskIf == 0)
            {
                res = (n | (1 << p));
                Console.WriteLine("n={0} ({4}), p={1}, v={2} -> {3} ({5})", n, p, v, res, Convert.ToString(n, 2), Convert.ToString(res, 2));
            }
            else
            {
                res = n & ~(1 << p);
                Console.WriteLine("n={0} ({4}), p={1}, v={2} -> {3} ({5})", n, p, v, res, Convert.ToString(n, 2), Convert.ToString(res, 2));
            }
        }
    }

