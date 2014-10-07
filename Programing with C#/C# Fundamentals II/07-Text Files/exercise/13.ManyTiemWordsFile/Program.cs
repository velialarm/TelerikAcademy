//Write a program that reads a list of words from a file words.txt and 
//finds how many times each of the words is contained in another file test.txt. 
//The result should be written in the file result.txt and 
//the words should be sorted by the number of their occurrences in descending order. 
//Handle all possible exceptions in your methods.
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            string wordsFile = "words.txt";
            string testsFile = "test.txt";
            string resultFile = "result.txt";

            List<string> words = CreateListWord(wordsFile);
            List<string> tests = CreateListWord(testsFile);

            CountWords(resultFile, words, tests);  
        }

        private static void CountWords(string resultFile, List<string> words, List<string> tests)
        {
            try
            {
                string[,] result = new string[tests.Count, 2];

                for (int i = 0; i < tests.Count; i++)
                {
                    int count = 0;
                    foreach (var word in words)
                    {
                        if (word == tests[i])
                        {
                            count++;
                        }
                    }
                    result[i, 0] = tests[i];
                    result[i, 1] = count.ToString();
                    //Console.WriteLine("{0} - {1}",tests[i],count);
                }

                //sorted by the number of their occurrences in descending order. 
                //Array.Sort(result,((x,y)=> x.Compare(y)));
                StreamWriter sw = new StreamWriter(resultFile);
                using (sw)
                {
                    for (int i = 0; i < result.GetLength(0); i++)
                    {
                        sw.WriteLine(result[i, 1] + " " + result[i, 0]);
                        //Console.WriteLine("{0} - {1}", result[i, 0], result[i, 1]);
                    }
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (FileNotFoundException fnf)
            {
                Console.WriteLine(fnf.Message);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                Console.WriteLine(dnfe.Message);
            }
            
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
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (FileNotFoundException fnf)
            {
                Console.WriteLine(fnf.Message);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                Console.WriteLine(dnfe.Message);
            }
            return listWords;

           
        }
    }
