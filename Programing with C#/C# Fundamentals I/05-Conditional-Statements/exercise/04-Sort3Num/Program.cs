using System;

    class Program
    {
        static void Main()
        {
            //Sort 3 real values in descending order using nested if statements.

            Console.Write("Enter first digit: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second digit: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Enter third digit: ");
            int c = int.Parse(Console.ReadLine());

            int[] numbers = {0,0,0};

            if ((a > b && a > c))
            {
                numbers[0] = a;

                if (b > c)
                {
                    numbers[1] = b;
                    numbers[2] = c;
                }
                else 
                {
                    numbers[1] = c;
                    numbers[2] = b;   
                }
            }
            else if ((b > a && b > c))
            {
                numbers[0] = b;

                if (a > c)
                {
                    numbers[1] = a;
                    numbers[2] = c;
                }
                else
                {
                    numbers[1] = c;
                    numbers[2] = a;
                }
            }
            else if ((c > a && c > b))
            {
                numbers[0] = c;

                if (a > b)
                { 
                    numbers[1] = a;
                    numbers[2] = b;
                }
                else
                {
                    numbers[1] = b;
                    numbers[2] = a;
                }
            }
            Console.WriteLine("result decrease sort");
            for (int i = 0; i <numbers.Length ; i++ )
            {
                Console.WriteLine(numbers[i]);
            }
            
            Console.WriteLine("result descending sort");

            for (int i = (numbers.Length-1); i > -1; i--)
            {
                Console.WriteLine(numbers[i]);
            }

        }
    }
