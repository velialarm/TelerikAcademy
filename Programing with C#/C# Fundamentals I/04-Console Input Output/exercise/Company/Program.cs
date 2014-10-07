using System;

    class Program
    {
        static void Main()
        {
            //A company has name, address, phone number, fax number, web site and manager. 
            //The manager has first name, last name, age and a phone number. 
            //Write a program that reads the information about a company and its manager and prints them on the console.

            Console.Write("Enter company name: ");
            string compName = Console.ReadLine();
            Console.Write("Enter company address: ");
            string compAddr = Console.ReadLine();
            Console.Write("Enter company phone number: ");
            string compPhone = Console.ReadLine();
            Console.Write("Enter company fax number: ");
            string compFax = Console.ReadLine();
            Console.Write("Enter company web site: ");
            string compWeb = Console.ReadLine();

            Console.Write("Enter Managery first name: ");
            string manName = Console.ReadLine();
            Console.Write("Enter Managery last name: ");
            string manFam = Console.ReadLine();
            Console.Write("Enter Managery age: ");
            string manAge = Console.ReadLine();
            Console.Write("Enter Managery Phone number: ");
            string manPhone = Console.ReadLine();

            Console.WriteLine("Company infomoration \n");
            Console.WriteLine("Company name: {0}",compName);
            Console.WriteLine("Company address: {0}", compAddr);
            Console.WriteLine("Company phone number: {0}", compPhone);
            Console.WriteLine("Company fax number: {0}", compFax);
            Console.WriteLine("Company  web site: {0} \n", compWeb);

            Console.WriteLine("Manager information \n");
            Console.WriteLine("Manager first name: {0}",manName);
            Console.WriteLine("Manager last name: {0}", manFam);
            Console.WriteLine("Manager age: {0}", manAge);
            Console.WriteLine("Manager phone number: {0}", manPhone);


        }
    }
