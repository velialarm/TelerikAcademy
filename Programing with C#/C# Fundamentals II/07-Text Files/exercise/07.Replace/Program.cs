//Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. 
//Ensure it will work with large files (e.g. 100 MB).

using System;
using System.Collections.Generic;
using System.IO;
    class Program
    {
        static void Main()
        {
            string input = "input.txt";
            string result = "result.txt";
            const long fileLenght = 50000;
            if (!File.Exists(input))
            {
                CreateFile(input,fileLenght);   
            }
            StreamReader sr = new StreamReader(input);
            StreamWriter sw = new StreamWriter(result);
            using(sw)
            {
                using (sr)
                {
                    string line = sr.ReadLine();
                    
                    //List<string> list = new List<string>();
                    while (!sr.EndOfStream)
                    {
                        string[] lineSplit = line.Split();
                        string writeLine = String.Empty;
                        for (int i = 0; i < lineSplit.Length; i++)
                        {
                            if (lineSplit[i] == "start")
                            {
                                if (i == 0)
                                {
                                    writeLine += "finish";
                                }
                                else
                                {
                                    writeLine += " finish";
                                }
                            }
                            else 
                            {
                                if (i == 0)
                                {
                                    writeLine += lineSplit[i];
                                }
                                else
                                {
                                    writeLine += " " + lineSplit[i];
                                }
                                
                            }
                        }
                        sw.WriteLine(writeLine);
                        line = sr.ReadLine();
                    }
                }
            }
            

        }
        private static void CreateFile(string input, long lengtFile)
        {  
            StreamWriter sw = new StreamWriter(input);
            using (sw)
            {
                FileInfo infoFile = new FileInfo(input);
                string line = "Installing start Android SDK can be time consuming, but Xamarin's start all-in-one installer simplifies start the process. Get everything you need with only a few clicks.";
                while (infoFile.Length < lengtFile)
                {
                    sw.WriteLine(line);
                    infoFile.Refresh();
                }
            }
        }
    }
