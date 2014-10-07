using System;
using System.IO;

    class Program
    {
        static void Main()
        {
            string file1 = "file1.txt";
            string file2 = "file2.txt";
            string result = "result.txt";
            CreateFile(file1);
            CreateFile(file2);
            ConcatenateFiles(file1, file2, result);

        }

        private static void ConcatenateFiles(string file1, string file2, string result)
        {
            StreamReader sr1 = new StreamReader(file1);
            StreamWriter sw = new StreamWriter(result);
            StreamReader sr2 = new StreamReader(file2);

            using (sr1)
            {
                string line = sr1.ReadLine();
                sw.WriteLine(line);
                while (line != null)
                {
                    line = sr1.ReadLine();
                    sw.WriteLine(line);
                }
            }
            using (sr2)
            {
                string line = sr2.ReadLine();
                sw.WriteLine(line);
                while (line != null)
                {
                    line = sr2.ReadLine();
                    sw.WriteLine(line);
                }
            }
            sw.Dispose();
            Console.WriteLine("Tho files: {0} and {1} was concatenates in {2} ", file1, file2, result);
        }
        private const string textat = "ABCDEFGHEFRHZDFGLalkajsdwqweeeeeddsa";
        private static void CreateFile(string pathfile)
        {
            StreamWriter sw = new StreamWriter(pathfile);
            using (sw)
            {
                Random op = new Random();
                const int lines = 30;
                for (int i = 0; i < lines; i++)
                {
                    string randTxt = String.Empty;
                    for (int x = 0; x < 10; x++)
			        {
                        randTxt += op.Next(0, textat.Length - 1);			 
			        }

                    sw.WriteLine("{0}. Line on file {2} - ({1})", i + 1,randTxt,pathfile);
                }
            }
        }

    }
