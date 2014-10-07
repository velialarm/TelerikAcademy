using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class EncodeEncrypt
{
    static void Main(string[] args)
    {
        if (File.Exists("input.txt"))
        {
            Console.SetIn(new StreamReader("input.txt"));
        }

        string message = Console.ReadLine();
        string cypher = Console.ReadLine();
        StringBuilder sb = new StringBuilder();

        string encriptText = Encrypt(message, cypher) + cypher; //encrypted message
        string encodeText = Encode(encriptText);
        Console.WriteLine(encodeText+cypher.Length);
    }


    /*
     *The function replaces symbols in the aforementioned way 
     *ONLY if the run-length encoding of the same-symbol sequence is shorter than the sequence itself 
     */
    private static string Encode(string text) {
        //run-length encoding
        StringBuilder sb = new StringBuilder();
        text.ToCharArray();
        int count = 0;
        char save = ' ';
        char next = ' ';
        for (int i = 0; i < text.Length-1; i++)
        {
            next = text[i + 1];
            if (text[i] == text[i + 1])
            {
                count++;
                save = text[i];
            }
            else
            {
                if (count != 0)
                {
                    sb.Append(count + 1);
                    sb.Append(save);
                    count = 0;
                }
                else
                {
                    sb.Append(text[i]);
                }
            }
        }
        if (count!=0)
        {
            if (save != next)
            {
                sb.Append(count + 1);
                sb.Append(save);
                sb.Append(next);
            }
            else
            {
                sb.Append(count + 1);
                sb.Append(save);
            }
        }
        else
        {
            if (save != ' ')
            {
                sb.Append(save);
            }
            sb.Append(next);
        }
        return sb.ToString();
    }
    private static string Encrypt(string message, string cypher)
    {
        char[] symbols = message.ToCharArray();
        char[] symbolsCypher = cypher.ToCharArray();

        string result = "";
        //calculate
        StringBuilder sb = new StringBuilder();
        if (symbols.Length >= symbolsCypher.Length)
        {
            int x = -1;
            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbolsCypher.Length <= x + 1 || x == -1)
                {
                    x = 0;
                }
                else
                {
                    x++;
                }
                int res = ((int)symbols[i] - 65) ^ ((int)symbolsCypher[x] - 65);
                sb.Append((char)(res + 65));
            }
            result = sb.ToString();
        }
        else 
        {
            int messageIndex = 0;
            StringBuilder data = new StringBuilder(message);
            for (int z = 0; z < symbolsCypher.Length; z++)
            {
                char messegeSymbol = symbols[messageIndex];
                char cypherSymbol = symbolsCypher[z];

                int res = ((int)messegeSymbol - 65) ^ ((int)cypherSymbol - 65);
                char encryptedSymbol = ((char)(res + 65));
                
                data[messageIndex] = encryptedSymbol;
                messageIndex++;
                if (messageIndex == symbols.Length)
                {
                    messageIndex = 0;
                }
               
            }
        }

        return result;
    }
   
}

