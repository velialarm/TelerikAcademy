//Write a program that extracts from given XML file all the text without the tags
using System;
using System.IO;
using System.Text;
    class Program
    {
        static void Main()
        {
            string fileName = "input.xml";

            StreamReader sr = new StreamReader(fileName);
            StringBuilder sb = new StringBuilder();
            string result = String.Empty;
            using (sr)
            {
                result = sr.ReadToEnd();
            }
            bool start = false;
            foreach (char item in result)
            {
                //Console.WriteLine(item);
                
                switch (item)
                {
                    case '<':
                        {
                            start = false;
                            break;
                        }
                    case '>':
                        {
                            start = true;
                            break;
                        }
                    default:
                        {
                            if (start)
                            {
                                Console.Write(item);
                            }
                            
                            break;
                        }
                }
            }
            //Console.WriteLine(result);
        }
    }
