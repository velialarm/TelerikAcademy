using System;
    class Program
    {
        static void Main()
        {
            //Write a program to convert binary numbers to their decimal representation.

            Console.Write("Enter binary number: ");
            string binary = Console.ReadLine();

            var dec = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[binary.Length - i - 1] == '0')
                {
                    continue;
                }
                dec += (int)Math.Pow(2, i);
            }
            Console.WriteLine(dec);


        }
    }
