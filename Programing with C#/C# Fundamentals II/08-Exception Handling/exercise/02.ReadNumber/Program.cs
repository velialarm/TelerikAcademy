//Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. 
//If an invalid number or non-number text is entered, the method should throw an exception. 
using System;
    class Program
    {
        static void Main()
        {
            int count = 10;
            int start = 1;
            int end = 100;
            Console.WriteLine("Please enter 10 integer numbers:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("{0}. Enter number: ",i+1);
                ReadNumber(start,end);
            }
        }
        static void ReadNumber(int start, int end)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < start || number > end)
                {
                    throw new System.ArgumentOutOfRangeException();
                }
                else
                {
                    Console.WriteLine("The number is in the range [{0},{1}]", start, end);
                }

            }
            catch (FormatException fe)// Catches exception if the input is not a number
            {
                Console.WriteLine("Not an integer number. Error: {0}",fe.Message);
            }
            catch (OverflowException) // Catches exception if the input out of integer scope
            {
                Console.WriteLine("Not in the scope of integer.");
            }
            catch (System.ArgumentNullException) // Catches exception if the input is null
            {
                Console.WriteLine("Null is not an integer number.");
            }
            catch (System.ArgumentOutOfRangeException) // Catches exception if the input is not in range
            {
                Console.WriteLine("The entered number is not in range."); // This one i rise my self inside the method
            }
        }
    }
