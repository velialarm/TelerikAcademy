using System;

    class task13
    {
        static void Main()
        {
            //Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.

            uint n = 2147418112; //for easier exchange watch
            uint mask = 7;
            uint getFirstBits = (7 << 3) & n; //get bits 3 4 5
            uint getSecondBits = (7 << 24) & n;  //get bits 24 25 26
            getFirstBits = getFirstBits << 21; //push 3, 4, 5 bit, twenty one positions to the left
            getSecondBits = getSecondBits >> 21; //push 24,25,26 bit, twenty one positions to the right

            n = n & (~(mask << 3)); //null the 3,4,5 bits for easier concatination
            Console.WriteLine(Convert.ToString(n, 2));
            n = n & (~(mask << 21)); //null the 24,25,26 bits for easier concatination
            Console.WriteLine(Convert.ToString(n, 2));
            n = n | getFirstBits; //concatinate the number and the pushed 3,4,5 bits
            Console.WriteLine(Convert.ToString(n, 2));
            n = n | getSecondBits; //concatinate the number and the pushed 24,25,26 bits
            Console.WriteLine(Convert.ToString(n, 2));
            Console.WriteLine(n);
        }
    }
