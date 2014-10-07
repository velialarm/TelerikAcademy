using System;
    class CheckExpresions
    {
        static void Main()
        {
            Console.WriteLine("Enter expresions: ");
            string expresions = Console.ReadLine();
            int countOpenBrakets = 0;
            int countCloseBrakets = 0;
            foreach (var sumbol in expresions)
            {
                if (sumbol == '(')
                {
                    countOpenBrakets++;
                }
                if (sumbol == '(')
                {
                    countCloseBrakets++;
                }
            }
            if (countCloseBrakets==countOpenBrakets)
            {
                Console.WriteLine("Brackets are put correctly");
            }
            else
            {
                Console.WriteLine("Brackets are no put correctly");
            }
            


        }
    }
