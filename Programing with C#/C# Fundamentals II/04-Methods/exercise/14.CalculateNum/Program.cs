using System;
    class Program
    {
        static void Main()
        {
            //Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers. 
            //Use variable number of arguments.

            Console.Write("Enter N numbers : ");
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0}. Enter number: ",i+1);
                numbers[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(numbers);
            //min
            MinumunElement(numbers);
            //max
            MaximumElement(numbers);
            //average
            AverageElement(numbers);
            //sum
            SumElements(numbers);
            Console.WriteLine();


        }

        private static void SumElements(int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine("Sum of numbers is : {0}", sum);
        }

        private static void AverageElement(int[] numbers)
        {
            int average = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                average += numbers[i];
            }
            average = average / numbers.Length;
            Console.WriteLine("Average of numbers is : {0}", average);
        }

        private static void MaximumElement(int[] numbers)
        {
            Console.WriteLine("Maximum element of numbers is : {0}", numbers[numbers.Length - 1]);
        }

        private static void MinumunElement(int[] numbers)
        {
            Console.WriteLine("Minimum element of numbers is : {0}", numbers[0]);
        }
    }
