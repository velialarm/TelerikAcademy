//Write a program that deletes from a text file all words that start with the prefix "test". 
//Words contain only the symbols 0...9, a...z, A…Z, _.

using System;
using System.IO;
using System.Text;
    class Program
    {
        static void Main()
        {
            string fileName = "file.txt";
            string prefiks = "test";

            StreamReader sr = new StreamReader(fileName);
            StringBuilder sb = new StringBuilder();
            
            StringBuilder result = new StringBuilder();
            using (sr)
            { 
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(' ');
                    for (int i = 0; i < line.Length; i++)
                    {
                        foreach (var symbol in line[i])
                        {
                            if (!((symbol >= '0' && symbol <= '9') || (symbol >= 'A' && symbol <= 'Z') || (symbol >= 'a' && symbol <= 'z')))
                            {
                                //
                            }
                        }
                        if (line[i].Length >= 4)
                        {
                            if (line[i].Substring(0, 4) != prefiks)
                            {
                                sb.Append(line[i]);
                                sb.Append(" ");
                                //Console.WriteLine(line[i]);
                            }
                        }
                        else
                        {
                            sb.Append(line[i]);
                            sb.Append(" ");
                        }
                        
                    }
                    //Console.WriteLine(sb.ToString());
                    result.Append(sb.ToString());
                    sb.Clear();
                }
                sr.Dispose();
                StreamWriter sw = new StreamWriter(fileName);
                using (sw)
                {
                    sw.WriteLine(result.ToString());
                }
            }

        }
    }
