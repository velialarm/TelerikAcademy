using System;
using System.Collections.Generic;

class ContainValue
{
    static void Main()
    {
        int currentValue = 0;
        for (int i = 0; i < 100; i++)
        {
            List<int> array  = new List<int>();
            if (i % 10 == 0)
            {
                Console.WriteLine(array[i]);
                int expectedValue = 5;
                if (array[i] == expectedValue)
                {
                    currentValue = 666;
                }
                i++;
            }
            else
            {
                Console.WriteLine(array[i]);
                i++;
            }
        }
        // More code here
        if (currentValue == 666)
        {
            Console.WriteLine("Value Found");
        }

    }
}
