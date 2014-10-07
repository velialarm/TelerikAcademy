using System;

    class Program
    {
        static void Main()
        {
            //Write program that asks for a digit and depending on the input shows the name of that digit (in English) using a switch statement.

            Console.Write("Enter digit: ");
            int digit = int.Parse(Console.ReadLine());

            switch(digit)
            {
                case 0:
                    {
                        Console.WriteLine("You enter zero");
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("You enter one");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("You enter two");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("You enter three");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("You enter four");
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("You enter five");
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("You enter six");
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("You enter seven");
                        break;
                    }
                case 8:
                    {
                        Console.WriteLine("You enter eight");
                        break;
                    }
                case 9:
                    {
                        Console.WriteLine("You enter nine");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("It is not digit?!");
                        break;
                    }
            }
        }
    }
