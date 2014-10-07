using System;
using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            //Write a method that adds two positive integer numbers represented as arrays of digits
            //(each array element arr[i] contains a digit; 
            //the last digit is kept in arr[0]). 
            //Each of the numbers that will be added could have up to 10 000 digits.

            Console.WriteLine("Enter first number: ");
            string number1 = Console.ReadLine();
            Console.WriteLine("Enter second number: ");
            string number2 = Console.ReadLine();

            SumNumbers(number1, number2);
        }

        private static void SumNumbers(string number1, string number2)
        {
            char[] arr1 = number1.ToCharArray();
            char[] arr2 = number2.ToCharArray();
            Array.Reverse(arr1);
            Array.Reverse(arr2);
            int max, min;
            string res = "";
            if (arr1.Length >= arr2.Length)
            {
                max = arr1.Length;
                min = arr2.Length;
                for (int i = 0; i < max - min; i++)
                {
                    res += number1.Substring(i, 1);
                }
            }
            else
            {
                max = arr2.Length;
                min = arr1.Length;
                for (int i = 0; i < max - min; i++)
                {
                    res += number2.Substring(i, 1);
                }
            }
            int ostatak = 0;
            List<int> result = new List<int>();
            int temp = 0;
            int lastRes = 0;
            for (int i = 0; i < min; i++)
            {
                int sum = int.Parse(Convert.ToString(arr1[i])) + int.Parse(Convert.ToString(arr2[i])) + temp;
                ostatak = sum > 9 ? 1 : 0;
                //Console.WriteLine("{0}-{1}",sum%10,ostatak);
                lastRes = sum % 10;
                result.Add((lastRes));
                temp = ostatak;
                lastRes = sum % 10;
            }

            if ((ostatak > 0) || (res != ""))
            {
                result.Add(int.Parse(res) + temp);
            }
            Console.WriteLine();
            for (int i = 0; i < result.Count; i++)
            {
                Console.Write("{0}", result[result.Count - i - 1]);
            }
        }
    }
