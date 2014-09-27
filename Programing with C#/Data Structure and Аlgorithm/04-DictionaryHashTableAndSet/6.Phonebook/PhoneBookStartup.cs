namespace DictionaryHashTableAndSetHW
{
    using System;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// * 6. Task
    /// A text file phones.txt holds information about people, their town and phone number.
    /// Example: Mimi Shmatkata | Plovdiv | 0888 12 34 56 Kireto | Varna | 052 23 45 67 Daniela Ivanova Petrova | Karnobat | 0899 999 888 Bat Gancho | Sofia | 02 946 946 946
    ///  Duplicates can occur in people names, towns and phone numbers. 
    /// Write a program to read the phones file and execute a sequence of commands given in the file commands.txt:
    ///     -> find(name) – display all matching records by given name (first, middle, last or nickname) 
    ///     -> find(name, town) – display all matching records by given name and town
    /// </summary>
    class PhoneBookStartup
    {
        static void Main(string[] args)
        {
            using (var input = new StreamReader("../../input.txt"))
            {
                for (string line = null; (line = input.ReadLine()) != null; )
                {
                    var parts = line.Split(new[] { ContactAddress.Separator }, StringSplitOptions.None)
                        .Select(entry => entry.Trim())
                        .ToArray();

                    ContactAddressUtil.Add(parts[0], parts[1], parts[2]);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, ContactAddressUtil.Find("Bat Gancho")));
            Console.WriteLine();
            Console.WriteLine(string.Join(Environment.NewLine, ContactAddressUtil.Find("Bat Gancho", "Sofia")));
        }
    }
}