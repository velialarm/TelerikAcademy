using System;
using System.IO;
    class Program
    {
        static void Main()
        {
            //Write a program that reads a text file and prints on the console its odd lines.

            string pathfile = "text.txt";

            CreateFile(pathfile);

            ReadOddLineOnFile(pathfile);
        }

        private static void ReadOddLineOnFile(string pathfile)
        {
            StreamReader sr = new StreamReader(pathfile);
            using (sr)
            {
                int lineNum = 1;
                string line = sr.ReadLine();
                Console.WriteLine(line);
                while (line != null)
                {
                    lineNum++;
                    line = sr.ReadLine();
                    if (lineNum % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                }

            }
        }

        private static void CreateFile(string pathfile)
        {
            StreamWriter sw = new StreamWriter(pathfile);
            using (sw)
            {
                const int lines = 30;
                for (int i = 0; i < lines; i++)
                {
                    sw.WriteLine("{0}. Line", i + 1);
                }
            }
        }
    }
