using System;
using System.IO;
using System.Linq;

class Program
{
    const string Extension = ".exe";

    static void Traverse(string root)
    {
        foreach (string file in Directory.GetFiles(root).Where(file => file.EndsWith(Extension)))
            Console.WriteLine(file);

        foreach (string directory in Directory.GetDirectories(root))
            Traverse(directory);
    }

    static void Main()
    {
        Traverse(@"C:\Program Files\");
    }
}
