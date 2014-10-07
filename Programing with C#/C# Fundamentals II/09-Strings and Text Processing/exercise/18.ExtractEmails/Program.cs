using System;
using System.Text;
class Program
{
    static void Main()
    {
        string input = "mail@abv.bg, pesho@gmail.com, ivancho@gusto.ru";
        char[] separator = { ',', ' ' };
        string[] mails = input.Split(separator,StringSplitOptions.RemoveEmptyEntries);
        foreach (var mail in mails)
        {
            Console.Write("{0} => ",mail);
            StringBuilder sb = new StringBuilder();
            int identifyerPos = mail.IndexOf("@");
            string identifyers = mail.Substring(0,identifyerPos);
            sb.Append("<");
            sb.Append(identifyers);
            sb.Append(">@");
            int hostPos = mail.IndexOf(".");
            string host = mail.Substring(identifyerPos+1,hostPos-identifyerPos-1);
            sb.Append("<");
            sb.Append(host);
            sb.Append(">");
            string domain = mail.Substring(hostPos+1,mail.Length-hostPos-1);
            sb.Append("<");
            sb.Append(domain);
            sb.Append(">");
            Console.WriteLine(sb);
        }
    }
}
