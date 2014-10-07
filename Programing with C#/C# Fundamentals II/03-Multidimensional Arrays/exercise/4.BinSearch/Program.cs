using System;
    class Program
    {
        static void Main()
        {
            Console.Write("Enter n number elements of aray to sort: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("Enter K number for compare: ");
            int k = int.Parse(Console.ReadLine());
            Array.Sort(arr);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(arr[i]);
            }
           int index = Array.BinarySearch(arr,k);

           if (index<0)
           {
               index = index * -1;
           }
            Console.WriteLine("Largest number in the array which is < or = of {0} is {1}", k,arr[index-1]);

        }
    }
