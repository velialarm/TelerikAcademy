using System;

    class Program
    {
        static void Main()
        {
            //Write a program that, depending on the user's choice inputs int, double or string variable. If the variable is integer or double, increases it with 1. If the variable is string, appends "*" at its end. The program must show the value of that variable as a console output. Use switch statement.

            Console.WriteLine("Choose type of variable \n (1) for int , (2) for double , (3) for string \n");
            int variable = int.Parse(Console.ReadLine());
            Console.Write("Enter value: ");
            string value = Console.ReadLine();

            switch(variable)
            {
                case 1:
                    {
                        Console.WriteLine(int.Parse(value)+1);
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine(double.Parse(value)+1);
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine(value + "*");
                        break;
                    }
            }
        }
    }
