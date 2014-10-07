using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

    class Program
    {
        private static string[] numbers = new string[] {    "1111110",//0
                                                            "0110000",//1
                                                            "1101101",//2
                                                            "1111001",//3
                                                            "0110011",//4
                                                            "1011011",//5
                                                            "1011111",//6
                                                            "1110000",//7
                                                            "1111111",//8
                                                            "1111011"};//9
        static void Main(string[] args)
        {
            if (File.Exists("input.txt"))
            {
                Console.SetIn(new StreamReader("input.txt"));
            }

            int n = int.Parse(Console.ReadLine());
            List<string> numbers = new List<string>();  
            for (int i = 0; i < n; i++)
            {
                string segments = Console.ReadLine();
                string resultNum = RecognizeNumber(segments);
                numbers.Add(resultNum);
            }
          
        }

        private static string RecognizeNumber(string segments)
        {
           
            for (int raz = 0; raz < numbers.Length; raz++)
            {
                if (segments == numbers[raz])
                {
                   return raz.ToString();
                }
            }
            return "";
        }
    }

