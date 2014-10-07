using System;

    class task14
    {
        static void Main()
        {
            //Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.

            uint n = 4290772963;

            //Print the number before it has been changed for comparison
            Console.WriteLine(Convert.ToString(n, 2));

            byte p = 3;
            byte q = 2;
            byte k = 21;
            uint mask = 1;//when shifting right you need yout right side to be int

            //set the mask E.g (2^3) - 1
            for (int i = 0; i < p; i++)
            {
                mask *= 2;
            }

            //get the first bits
            uint getFirstBits = (((mask - 1) << q) & n) >> q;
            //get the second bits
            uint getSecondBits = (((mask - 1) << k) & n) >> k;

            //null the first bits
            n = n & (~((mask - 1) << q));
            //null the second bits
            n = n & (~((mask - 1) << k));

            //we concatnate the first bits and the nulled number(we exchange them)
            n = n | (getFirstBits << k);

            //we concatnate the second bits and the nulled number(we exchange them)
            n = n | (getSecondBits << q);

            //Print changed
            Console.WriteLine(Convert.ToString(n, 2));
        }
    }

