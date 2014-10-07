//Write a program that deletes from given text file all odd lines. The result should be in the same file.

using System;
using System.IO;
using System.Text;

    class Program
    {
        static void Main()
        {
            string fileName = "file.txt";

            CreateFile(fileName,20);
            StreamReader sr = new StreamReader(fileName);
            StringBuilder sb = new StringBuilder();
            int count = 0;
            using (sr)
            {
                
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (count % 2 != 0)
                    {
                        Console.WriteLine(line);
                        sb.AppendLine(sr.ReadLine());
                    }
                    count++;
                }
            }
            StreamWriter sw = new StreamWriter(fileName);
            using (sw)
            {
                sw.WriteLine(sb.ToString());
            }

        }
        private static void CreateFile(string pathfile, int lines)
        {
            StreamWriter sw = new StreamWriter(pathfile);
            using (sw)
            {
                for (int i = 0; i < lines; i++)
                {
                    sw.WriteLine("{0}. Line", i + 1);
                }
            }
        }
    }
