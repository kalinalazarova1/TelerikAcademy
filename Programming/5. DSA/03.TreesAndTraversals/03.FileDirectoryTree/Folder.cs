using System.Collections.Generic;

public class Folder
{
    public Folder(string name)
    {
        this.Name = name;
        this.Files = new List<File>();
        this.ChildFolders = new List<Folder>();
    }

    public string Name { get; set; }

    public List<File> Files { get; set; }

    public List<Folder> ChildFolders { get; set; }

    public long GetFolderSize()
    {
        long sum = 0;
        foreach (var file in this.Files)
        {
            sum += file.Size;
        }

        foreach (var folder in this.ChildFolders)
        {
            sum += folder.GetFolderSize();
        }

        return sum;
    }
}
