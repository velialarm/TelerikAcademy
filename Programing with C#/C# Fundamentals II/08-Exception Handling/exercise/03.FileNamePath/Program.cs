//Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), 
//reads its contents and prints it on the console. 
using System;
using System.IO;
    class Program
    {
        static void Main()
        {
            Console.Write("Enter the full path of the file you want to read: ");
            string filePath = Console.ReadLine();

            ReadFile(filePath);
        }

        private static void ReadFile(string filePath)
        {
            try
            {
                string fileContent = File.ReadAllText(filePath);
                Console.WriteLine(fileContent);
            }
            catch (DirectoryNotFoundException dirEx)
            {
                Console.WriteLine(dirEx.Message);
            }
            catch (FileNotFoundException fileEx)
            {
                Console.WriteLine(fileEx.Message);
     
            }
            catch (ArgumentNullException anEx)
            {
                Console.WriteLine(anEx.Message);
            }
            catch (ArgumentException aEx)
            {
                Console.WriteLine(aEx.Message);
            }
            catch (UnauthorizedAccessException unAutEx)
            {
                Console.WriteLine(unAutEx.Message);
            }
            catch (NotSupportedException nonSupEx)
            {
                Console.WriteLine(nonSupEx.Message);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine(ioEx.Message);
            }

           
        }
    }
