using System;
using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            //Write a program to convert hexadecimal numbers to binary numbers (directly).

            Dictionary<char, string> hexCharacterToBinary = new Dictionary<char, string>
            {
                { '0', "0000" },
                { '1', "0001" },
                { '2', "0010" },
                { '3', "0011" },
                { '4', "0100" },
                { '5', "0101" },
                { '6', "0110" },
                { '7', "0111" },
                { '8', "1000" },
                { '9', "1001" },
                { 'a', "1010" },
                { 'b', "1011" },
                { 'c', "1100" },
                { 'd', "1101" },
                { 'e', "1110" },
                { 'f', "1111" }
            };
            Console.WriteLine("Program that convert hexadecimal numbers to binary numbers (directly).\n");
            Console.Write("Enter hexadecimal numbers: ");
            string number = Console.ReadLine();
            Console.Write("Binary numbers of {0} is ", number);
            foreach (char c in number)
            {
                Console.Write("{0}", hexCharacterToBinary[char.ToLower(c)]);
            }
            Console.WriteLine();
        }
    }
