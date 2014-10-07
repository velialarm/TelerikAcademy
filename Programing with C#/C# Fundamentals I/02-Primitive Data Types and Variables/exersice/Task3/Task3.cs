using System;
 
class Task3
    {
        static void Main()
        {
            //Write a program that safely compares floating-point numbers with precision of 0.000001. 
            //Examples:(5.3 ; 6.01) -> false;  (5.00000001 ; 5.00000003) -> true

            // precision 0.000001 

            float prec = 0.000001f;
            float a=5.000000001f;
            float b=5.000000003f;
            Console.WriteLine("Float number 1 is {0}\n",a);
            Console.WriteLine("Float number 2 is {0} \n",b);
                      
            float diff = Math.Abs(a - b);
            if (diff < prec) {
                Console.WriteLine("Number 1 and Number 2 are equal");
            }
            else Console.WriteLine("Number 1 and Number 2 are not equal");
            
         
        }
    }
