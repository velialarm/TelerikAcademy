using System;
    class Program
    {
        static void Main()
        {
            Console.Write("Enter word:");
            string word = Console.ReadLine();
            char[] letters = word.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i]!=' ')
                {
                    Console.WriteLine("{0}: {1} - {2}",i+1, letters[i],Convert.ToInt32(letters[i]));

                }
                
            }
        }
    }
