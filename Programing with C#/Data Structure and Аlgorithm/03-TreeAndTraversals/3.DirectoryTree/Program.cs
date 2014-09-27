using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static Folder Traverse(string root)
    {
        var folder = new Folder(root);

        foreach (string file in Directory.GetFiles(root))
            folder.Add(new File(file, new FileInfo(file).Length));

        foreach (string directory in Directory.GetDirectories(root))
            folder.AddFolder(Traverse(directory));

        return folder;
    }

    static void Main()
    {
        Console.WriteLine(Traverse(@"../../"));
    }
}
