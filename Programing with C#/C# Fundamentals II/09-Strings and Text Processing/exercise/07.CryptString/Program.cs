//Write a program that encodes and decodes a string using given encryption key (cipher). 
//The key consists of a sequence of characters. 
//The encoding/decoding is done by performing XOR (exclusive or) operation over the first letter of the string with the first of the key, 
//the second – with the second, etc. 
//When the last key character is reached, the next is the first.

using System;
using System.Text;
class CryptString
{
    static void Main(string[] args)
    { 
        string message = "Gusto maina kak si?";
        string cipher = "op";
        //encode
        //Console.WriteLine(Decrypt(Encrypt(message, key), key));
        string encode = EncryptDecrypt(message, cipher);
        Console.WriteLine(encode);
        //decode
        Console.WriteLine(EncryptDecrypt(encode, cipher));
    }
    static string EncryptDecrypt(string message, string cipher)
    {
        StringBuilder result = new StringBuilder(message.Length);

        for (int i = 0; i < message.Length; i++)
            result.Append((char)(message[i] ^ cipher[i % cipher.Length]));

        return result.ToString();
    }
}