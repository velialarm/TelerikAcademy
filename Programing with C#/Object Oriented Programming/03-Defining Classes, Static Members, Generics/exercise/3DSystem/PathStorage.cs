using System;
using System.Collections.Generic;
using System.IO;

namespace _3DSystem
{
    class PathStorage
    {
        //Create a static class PathStorage with static methods to save and load paths from a text file. 

        public static void loadPath(Path path)
        {
            String file = @"../../pathsave.txt";
            StreamWriter writer = new StreamWriter(file);
            using (writer)
            {
                foreach (var point in path.AllPoints)
                {
                    writer.WriteLine(point);
                }
            }
        }
        public static List<Path> loadPath()
        {
            String file = @"../../pathload.txt";
            StreamReader reader = new StreamReader(file);
            using (reader)
            {
                string line = reader.ReadLine();
                while (line !=null)
                {
                    //read line from string ...
                }
            }
            return null;
        }
    }
}
