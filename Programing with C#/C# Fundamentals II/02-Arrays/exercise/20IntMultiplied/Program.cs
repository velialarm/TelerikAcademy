using System;
    class Program
    {
        static void Main()
        {
            //Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5. 
            //Print the obtained array on the console.

            int[] arr = new int[20];
            var number = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = number.Next(100);

                Console.WriteLine("{0} Array numeber: {1} * 5 = {2}",i+1,arr[i],arr[i]*5);

            }

        }
    }
