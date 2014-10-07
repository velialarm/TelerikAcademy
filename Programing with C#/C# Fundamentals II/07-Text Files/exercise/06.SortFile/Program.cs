//Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.
using System;
using System.Collections.Generic;
using System.IO;
    class Program
    {
        static void Main()
        {
            string input = "input.txt";
            string output = "output.txt";

            StreamReader sr = new StreamReader(input);
            StreamWriter sw = new StreamWriter(output);
            List<string> data = new List<string>();
            using (sr)
            {
                while (!sr.EndOfStream)
                {
                    data.Add(sr.ReadLine());   
                }
            }
            data.Sort();
            using (sw)
            {
                foreach (var item in data)
                {
                    sw.WriteLine(item);
                    //Console.WriteLine(item);
                }
            }
        }
    }
