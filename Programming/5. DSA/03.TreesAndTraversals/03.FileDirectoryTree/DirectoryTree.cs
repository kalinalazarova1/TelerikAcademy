public class DirectoryTree
{
    public DirectoryTree(Folder rootDirectory)
    {
        this.Root = rootDirectory;
    }

    public Folder Root { get; set; }
}
