using System;
using System.IO;
//Write a program that compares two text files line by line and 
//prints the number of lines that are the same and the number of lines that are different. 
//Assume the files have equal number of lines.

    class Program
    {
        static void Main()
        {
            string file1 = "file1.txt";
            string file2 = "file2.txt";


            StreamReader sr1 = new StreamReader(file1);
            StreamReader sr2 = new StreamReader(file2);
            int someLine = 0;
            int diferLine = 0;
            using(sr1)
	        {
		        using(sr2)
	            {
                    
		            while (!sr1.EndOfStream && !sr2.EndOfStream)
	                {

                        if (sr1.ReadLine() == sr2.ReadLine())
                        {
                            //Console.WriteLine("{0}.Line ({1})==({2})",someLine,sr1.ReadLine(),sr2.ReadLine());
                            someLine++;
                        }
                        else
                        {
                            diferLine++;
                        }
	                }
                    
	            }
	        }
            Console.WriteLine("The number of the same lines is: {0}", someLine);
            Console.WriteLine("The number of the diferent lines is: {0}", diferLine);
        }
    }
