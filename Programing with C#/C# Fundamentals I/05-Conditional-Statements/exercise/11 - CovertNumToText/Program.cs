using System;

    class Program
    {
        static void Main()
        {
            //Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
	        //  0 -> "Zero"
            // 273 -> "Two hundred seventy three"
            // 400 -> "Four hundred"
            // 501 -> "Five hundred and one"
            // 711 -> "Seven hundred and eleven"
            string[] unitsMap = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tensMap = {"zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            string words = "";
            int number;
            Console.Write("Input an integer number in the range [0...999]:");

            bool check = int.TryParse(Console.ReadLine(), out number);
            if(check)
            {
                Console.WriteLine("The English pronunciation of {0} is: ", number);

                if (number == 0)
                {
                    words = "zero";
                    Console.WriteLine(words);
                }
                if ((number / 1000000) > 0)
                {
                    int temp = (number / 1000000);
                    if (temp < 20)
                        words += unitsMap[temp];
                    else
                    {
                        words += tensMap[temp / 10];
                        if ((temp % 10) > 0)
                            words += "-" + unitsMap[temp % 10];
                    }
                    words +=  " million ";
                    number %= 1000000;   
                }
                if ((number / 1000) > 0)
                {
                    int temp = (number / 1000);
                    if (temp < 20)
                        words += unitsMap[temp];
                    else
                    {
                        words += tensMap[temp / 10];
                        if ((temp % 10) > 0)
                            words += "-" + unitsMap[temp % 10];
                    }
                    words +=  " thousand ";
                    number %= 1000;     
                }
                if ((number / 100) > 0)
                {
                    int temp = (number / 100);
                    if (temp < 20)
                        words += unitsMap[temp];
                    else
                    {
                        words += tensMap[temp / 10];
                        if ((temp % 10) > 0)
                            words += "-" + unitsMap[temp % 10];
                    }

                    words +=  " hundred ";
                    number %= 100;
                }

                if (number > 0)
                {
                    if (words != "")
                        words += "and ";

                    
                    if (number < 20)
                        words += unitsMap[number];
                    else
                    {
                        words += tensMap[number / 10];
                        if ((number % 10) > 0)
                            words += "-" + unitsMap[number % 10];
                    }
                }

                Console.WriteLine(words);
            }
        }
    }
