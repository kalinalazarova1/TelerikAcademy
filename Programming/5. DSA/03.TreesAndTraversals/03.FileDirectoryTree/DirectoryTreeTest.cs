//3. Define classes File { string name, int size } and Folder { string name, File[] files,
//Folder[] childFolders } and using them build a tree keeping all files and folders on the
//hard drive starting from C:\WINDOWS. Implement a method that calculates the sum of the file 
//sizes in given subtree of the tree and test it accordingly. Use recursive DFS traversal.

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class Program
{
    static System.Collections.Specialized.StringCollection log = new System.Collections.Specialized.StringCollection();
    static void Main()
    {
        DirectoryInfo rootDir = new DirectoryInfo(@"C:\WINDOWS");
        var rootFolder = new Folder(rootDir.Name);
        var folderTree = new DirectoryTree(rootFolder);
        WalkDirectoryTree(rootDir, folderTree, rootFolder);
        foreach (string s in log)
        {
            Console.WriteLine(s);
        }

        Console.WriteLine("The directory {0} size is: {1} MB ( {2} bytes ).", rootDir.FullName, folderTree.Root.GetFolderSize() / 1024 / 1024, folderTree.Root.GetFolderSize());
    }

    static void WalkDirectoryTree(DirectoryInfo root, DirectoryTree folderTree, Folder currentFolder)
    {
        FileInfo[] files = null;
        DirectoryInfo[] subDirs = null;

        try
        {
            files = root.GetFiles("*.*");
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
            currentFolder.Files = files.Select(f => new File(f.Name, f.Length)).ToList();

            subDirs = root.GetDirectories();

            currentFolder.ChildFolders = subDirs.Select(d => new Folder(d.Name)).ToList();
            var i = 0;
            foreach (DirectoryInfo dirInfo in subDirs)
            {
                WalkDirectoryTree(dirInfo, folderTree, currentFolder.ChildFolders[i]);
                i++;
            }
        }
    }
}
