using System;

    class Program
    {
        static void Main()
        {
            //Write a program that applies bonus scores to given scores in the range [1..9]. 
            // The program reads a digit as an input. If the digit is between 1 and 3, 
            // the program multiplies it by 10; if it is between 4 and 6, multiplies it by 100; 
            // if it is between 7 and 9, multiplies it by 1000. If it is zero or if the value is not a digit, 
            // the program must report an error.
		    // Use a switch statement and at the end print the calculated new value in the console.

            int bonus;
            Console.Write("Enter digit from 0 - 9:  ");
            string number = Console.ReadLine();
            bool isDigit = int.TryParse(number, out bonus);
            
            //Console.WriteLine(isDigit);
            
            if(isDigit)
            {
                switch (bonus)
                {
                    case 1:
                    case 2:
                    case 3:
                        {
                            Console.WriteLine("You recieve {0} bonus point",bonus * 10);
                            break;
                        }
                    case 4:
                    case 5:
                    case 6:
                        {
                            Console.WriteLine("You recieve {0} bonus point", bonus * 100);
                            break;
                        }
                    case 7:
                    case 8:
                    case 9:
                        Console.WriteLine("You recieve {0} bonus point", bonus * 1000);
                            break;
                    default:
                        {
                            break;
                        }
                }
            }
            else
            {
                Console.WriteLine("You enter not digit!");
            }
        }
    }
