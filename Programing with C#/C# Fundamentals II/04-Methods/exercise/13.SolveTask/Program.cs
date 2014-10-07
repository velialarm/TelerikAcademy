using System;
    class Program
    {
        static void Main()
        {
            //Reverses the digits of a number
            //Calculates the average of a sequence of integers
            //Solves a linear equation a * x + b = 0
            //Create appropriate methods.
            //Provide a simple text-based menu for the user to choose which task to solve.
            //Validate the input data
            //The decimal number should be non-negative
            //The sequence should not be empty a should not be equal to 0

            bool exit = false;
            do
            {
                int choise = PrintMenu();
                switch (choise)
                {
                    case 1:
                        {
                            ReverseNum();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine();
                            Console.WriteLine("You enter 2 - Calculates the average of a sequence of integers");
                            //exit = true;
                            //Calculates the average of a sequence of integers
                            Console.Write("Enter the length of the integer sequence: ");
                            int n = int.Parse(Console.ReadLine());
                            //The sequence should not be empty a should not be equal to 0
                            if (n==0)
                            {
                                Console.WriteLine("The sequence should not be empty a should not be equal to 0");
                                break;
                            }
                            CalculateAverage(n);
                            break;
                        }
                    case 3:
                        {
                            Equation();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Your choise is EXIT!");
                            exit = true;
                            break;
                        }
                    default:
                        Console.Write("Please Enter number between 1-4 :");
                        choise = int.Parse(Console.ReadLine());
                        Console.WriteLine();
                        break;
                } 
            } while (!exit);
        }
        private static void Equation()
        {
            Console.WriteLine("You enter 3 - Solves a linear equation a * x + b = 0");
            //exit = true;
            //Solves a linear equation a * x + b = 0
            Console.WriteLine("Enter coeficient of equation:");
            decimal a = -1;
            do
            {
                Console.Write("a = ");
                a = decimal.Parse(Console.ReadLine());
                if (a < 0)
                {
                    Console.WriteLine("Please enter positive number again!");
                }
            } while (a <= 0);
            decimal b = -1;
            do
            {
                Console.Write("b = ");
                b = decimal.Parse(Console.ReadLine());
                if (b < 0)
                {
                    Console.WriteLine("Please enter positive number again!");
                }
            } while (b <= 0);
            decimal x = -b / a;
            Console.WriteLine("{0} * x + {1} = 0 , \nx = {2}", a, b, x);
        }

        private static void CalculateAverage(int n)
        {
            int[] digits = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0}. Enter number: ", i + 1);
                digits[i] = int.Parse(Console.ReadLine());
            }
            int average = 0;
            foreach (var digit in digits)
            {
                average += digit;
            }
            average = average / n;
            Console.WriteLine("Average of a sequence is : {0}", average);
            Console.WriteLine();
        }

        private static void ReverseNum()
        {
            Console.WriteLine();
            Console.WriteLine("You enter 1 - Reverses the digits of a number");
            //exit = true;
            ////Reverses the digits of a number
            Console.Write("Enter number: ");
            char[] number = Console.ReadLine().ToCharArray();
            Console.Write("Reverse of number is : ");
            for (int i = 0; i < number.Length; i++)
            {
                Console.Write("{0}", number[number.Length - i - 1]);
            }
            Console.WriteLine();
        }

        private static int PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine(" Choose which task to solve");
            Console.WriteLine("1. Reverses the digits of a number.");
            Console.WriteLine("2. Calculates the average of a sequence of integers");
            Console.WriteLine("3. Solves a linear equation a * x + b = 0");
            Console.WriteLine("4. Exit");
            Console.Write("Enter number between 1-4 : ");
            int choise = int.Parse(Console.ReadLine());
            return choise;
        }
    }
