//Write a program that removes from a text file all words listed in given another text file. 
//Handle all possible exceptions in your methods.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

    class Program
    {
        static void Main()
        {
            string fileCheck = "another.txt";
            string fileRemove = "remove.txt";

            string[] checkWords = CreateCheckWord(fileCheck);
            List<string> listWords = CreateListWord(fileRemove);
            List<string> result = CompareWords(checkWords, listWords);
            WriteToFile(fileRemove, result);
        }

        private static void WriteToFile(string fileRemove, List<string> result)
        {
            try
            {
                StreamWriter sw = new StreamWriter(fileRemove);
                using (sw)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        sw.Write(result[i]);
                        sw.Write(" ");
                        //Console.WriteLine();
                    }
                }
            }
            catch (ArithmeticException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                Console.WriteLine(dnfe.Message);
            }
        }

        private static List<string> CompareWords(string[] checkWords, List<string> listWords)
        {
            // prowerka
            List<string> result = new List<string>();
            for (int i = 0; i < listWords.Count; i++)
            {
                bool rem = false;
                foreach (var words in checkWords)
                {
                    if (words == listWords[i])
                    {
                        rem = true;
                        break;
                    }
                }
                if (!rem)
                {
                    result.Add(listWords[i]);
                    //Console.WriteLine();
                }
                else
                {
                    rem = false;
                }
            }
            return result;
        }
        private static List<string> CreateListWord(string fileAnother)
        {
            List<string> listWords = new List<string>();
            try
            {
                StreamReader sr1 = new StreamReader(fileAnother);
                using (sr1)
                {
                    string[] words = sr1.ReadToEnd().Split(' '); ;
                    foreach (var word in words)
                    {
                        listWords.Add(word);
                    }
                }
            }
            catch (ArithmeticException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }
            catch(DirectoryNotFoundException dnfe)
            {
                Console.WriteLine(dnfe.Message);
            }
            return listWords;
        }
        private static string[] CreateCheckWord(string fileAnother)
        {
            //string[] listWords = new List<string>();
            StreamReader sr1 = new StreamReader(fileAnother);
            string[] words;
            using (sr1)
            {
                words = sr1.ReadToEnd().Split(' ');
            }

            return words;
        }
    }
