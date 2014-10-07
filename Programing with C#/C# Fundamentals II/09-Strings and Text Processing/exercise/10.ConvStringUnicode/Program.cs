using System;
    class ConvStringUnicode
    {
        static void Main()
        {
            string input = "Hi!";
            foreach (char symbol in input)
            {
                Console.Write("\\u{0:X4} ",(int)symbol);
            }
            Console.WriteLine();
        }
    }
