//Write a program that downloads a file from Internet and stores it the current directory. 
//Be sure to catch all exceptions and to free any used resources in the finally block.

using System;
using System.Net;
    class Program
    {
        static void Main()
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", "image.jpg");
                Console.WriteLine("File successfully downloaded.");
            }
            catch (WebException e)
            {
                Console.WriteLine("Error while downloading file.");
            }
        }
    }
