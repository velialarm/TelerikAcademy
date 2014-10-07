using System;
    class Program
    {
        static void Main()
        {
            //Write a program that compares two char arrays lexicographically (letter by letter).

            Console.WriteLine("Compare leter by leter two strings!");
            Console.Write("Enter first string to compare: ");
            string input1 = Console.ReadLine();
             Console.Write("Enter second string to compare: ");
            string input2 = Console.ReadLine();
            char[] arr1 = input1.ToCharArray();
            char[] arr2 = input2.ToCharArray();

            int n = 0;
            if (input1.Length <= input2.Length)
            {
                n = input1.Length;
            }
            else
            {
                n = input2.Length;
            }
            for (int i = 0; i < n; i++)
            {
                string compare = "";
                if ((int)arr1[i] > (int)arr2[i])
                {
                    compare = "e po golqmo ot";
                }
                else
                {
                    if ((int)arr1[i] == (int)arr2[i])
                    {
                        compare = "e ravno na";
                    }
                    else
                    {
                        compare = "e po malko ot";
                    }
                }
                Console.WriteLine("{0} {2} {1}",arr1[i],arr2[i],compare); 
            }

        }
    }
