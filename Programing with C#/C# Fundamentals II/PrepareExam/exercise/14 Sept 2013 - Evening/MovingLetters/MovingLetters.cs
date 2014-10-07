using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class MovingLetters
{
    static void Main(string[] args)
    {
        if (File.Exists("input.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }
        List<string> input = Console.ReadLine().Split(' ').ToList();
        //extracts the letters 
        string result = "";
        StringBuilder sb = new StringBuilder();
        while (true)
        {
            bool exit = true;
            for (int i = 0; i < input.Count; i++)
            {
                char[] wordChars = input[i].ToCharArray();
                if (wordChars.Length > 0)
                {
                    sb.Append(wordChars.Last().ToString());
                    input[i] = input[i].Substring(0, wordChars.Length - 1);
                    exit = false;
                }
            }
            if (exit)
            {
                break;
            }
        }
        //moves each letter
        //string res = sb.ToString();
        for (int i = 0; i < sb.Length; i++)
        {
            char current = sb[i];
            int transition = char.ToLower(current) - 'a' + 1;
            int nextPos = (i+transition) % (sb.Length);

            sb.Remove(i, 1);
            sb.Insert(nextPos,current);
        }
        Console.WriteLine(sb.ToString());
    }

   
}

