//Write a program that parses an URL address 
using System;
class ParseURL
{
    static void Main()
    {
        Console.WriteLine("Enter URL adress: ");
        string url = Console.ReadLine();
        string protocol = String.Empty;
        string server = String.Empty;
        string resource = String.Empty;

        int stProtocol = url.IndexOf("://");
        if (stProtocol != -1)
        {
            protocol = url.Substring(0, stProtocol);

            int stServer = url.IndexOf("/", stProtocol + 3);
            if (stServer != -1)
            {
                server = url.Substring(stProtocol + 3, stServer - stProtocol - 3);
                if (url.Length - stServer - 1 != 0)
                {
                    resource = url.Substring(stServer + 1, url.Length - stServer - 1);

                    Console.WriteLine("[protocol] = {0}", protocol);
                    Console.WriteLine("[server] = {0}", server);
                    Console.WriteLine("[resource] = {0}", resource);
                }
                else
                {
                    Console.WriteLine("[protocol] = {0}", protocol);
                    Console.WriteLine("[server] = {0}", server);
                }
                
            }
            else
            {
                if (url.Length - stProtocol - 3 > 0)
                {
                    server = url.Substring(stProtocol + 3, url.Length - stProtocol - 3);
                    Console.WriteLine("[protocol] = {0}", protocol);
                    Console.WriteLine("[server] = {0}", server);
                }
                else
                {
                    Console.WriteLine("[protocol] = {0}", protocol);
                    Console.WriteLine("Enter server!");
                }
            }
            
        }
        else
        {
            Console.WriteLine("Enter protocol!");
        }
        

    }
}