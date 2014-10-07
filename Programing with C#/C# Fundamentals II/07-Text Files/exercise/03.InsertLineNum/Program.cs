using System;
using System.IO;

//Write a program that reads a text file and inserts line numbers in front of each of its lines. 
//The result should be written to another text file.


class Program
   {
   static void Main()
   {
       string fileInput = "fileInput.txt";
       string result = "result.txt";
       CreateFile(fileInput,12);

       StreamReader sr = new StreamReader(fileInput);
       StreamWriter sw = new StreamWriter(result);
       using (sr)
       {
           int count = 1;
           string line = sr.ReadLine();
           sw.WriteLine(count +" "+ line);
           while (line!=null)
           {
               count++;
               line = sr.ReadLine();
               sw.WriteLine(count+" "+line);
           }
       }
       sw.Dispose();
       Console.WriteLine("In file {0} was inserts line numbers in front of each of its lines",result);

   }
   private const string textat = "ABCDEFGHEFRHZDFGLalkajsdwqweeeeeddsa-+<>!@#$%%^&&**()";
   private static void CreateFile(string pathfile, int lines)
   {
       StreamWriter sw = new StreamWriter(pathfile);
       using (sw)
       {
           Random op = new Random();
           for (int i = 0; i < lines; i++)
           {
               string randTxt = String.Empty;
               for (int x = 0; x < 30; x++)
               {
                   randTxt += textat.Substring(op.Next(0, textat.Length - 1),1);
               }

               sw.WriteLine("Text on file {0} - ({1})", pathfile,randTxt);
           }
       }
   }
}
