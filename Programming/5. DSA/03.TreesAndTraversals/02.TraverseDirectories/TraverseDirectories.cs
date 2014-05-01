//2. Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively and to display all files 
//matching the mask *.exe. Use the class System.IO.Directory.

using System;
using System.IO;

class Program
{
    static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();
    static void Main()
    {
        DirectoryInfo rootDir = new DirectoryInfo(@"C:\WINDOWS");
        WalkDirectoryTree(rootDir);
        Console.WriteLine("Files with restricted access:");
        foreach (string s in log)
        {
            Console.WriteLine(s);
        }
        Console.WriteLine("Press any key");
        Console.ReadKey();
    }

    static void WalkDirectoryTree(DirectoryInfo root)
    {
        FileInfo[] files = null;
        DirectoryInfo[] subDirs = null;
        
        try
        {
            files = root.GetFiles("*.exe");
        }
         
        catch (UnauthorizedAccessException e)
        {
            log.Add(e.Message);
        }

        catch (DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

        if (files != null)
        {
            foreach (FileInfo file in files)
            {
                Console.WriteLine(file.FullName);
            }

            subDirs = root.GetDirectories();

            foreach (DirectoryInfo dirInfo in subDirs)
            {
                WalkDirectoryTree(dirInfo);
            }
        }            
    }
}

