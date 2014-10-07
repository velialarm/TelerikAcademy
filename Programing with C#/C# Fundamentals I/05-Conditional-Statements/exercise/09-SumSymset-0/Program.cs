using System;

    class Program
    {
        static void Main()
        {
            //We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. 
            // Example: 3, -2, 1, 1, 8 -> 1+1-2=0.

            int[] dig= {-3, -5, 1, -1, 8};
            int sum=0;
            for(int i = 0; i<dig.Length;i++)
            {
                sum += dig[i];
            }
            if (sum == 0)
            {
                Console.WriteLine("Sum of all digit is 0");
            }

            for (int i = 0; i < dig.Length;i++ )
            {
                for (int j = 0; j < dig.Length;j++ )
                {
                    if (dig[i] + dig[j] == 0)
                    {
                        Console.WriteLine("{0} + {1} == 0",dig[i], dig[j]);
                    }
                    for (int k = 2; k < dig.Length;k++ )
                    {
                        if(dig[i] + dig[j] + dig[k] == 0)
                        {
                            Console.WriteLine("{0} + {1} + {2} == 0", dig[i], dig[j], dig[k]);
                        }
                        for (int m = 3; m < dig.Length; m++ )
                        {
                            if (dig[i] + dig[j] + dig[k] + dig[m]== 0)
                            {
                                Console.WriteLine("{0} + {1} + {2} + {3} == 0", dig[i], dig[j], dig[k], dig[m]);
                            }
                        }
                    }
                }
            }
        }
    }
