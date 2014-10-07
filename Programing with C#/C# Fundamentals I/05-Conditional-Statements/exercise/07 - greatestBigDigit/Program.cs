using System;

    class Program
    {
        static void Main()
        {
            //Write a program that finds the greatest of given 5 variables.


            int[] numbers={0,0,0,0,0};
            
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("Enter digit: ");
                numbers[i] = int.Parse(Console.ReadLine());
            }
            int bigest = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > bigest)
                {
                    bigest = numbers[i];
                }
                

            }
            Console.WriteLine("The bigest digit is: {0}",bigest);
               
            

        }
    }
