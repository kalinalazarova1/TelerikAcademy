using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Document : IDocument
{
    public string Name { get; private set; }

    public string Content { get; protected set; }

    public List<KeyValuePair<string,object>> Properties { get; private set; }

    protected Document(string name)
        : this(name, null)
    {   
    }

    protected Document(string name, string content)
    {
        this.Name = name;
        this.Properties = new List<KeyValuePair<string, object>>();
        this.Content = content;
        this.Properties.Add(new KeyValuePair<string,object>("content", content));
    }

    public void LoadProperty(string key, string value)
    {
        this.Properties.Add(new KeyValuePair<string,object>(key, value));
    }

    public void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        this.Properties.Clear();
        foreach (var property in output)
        {
            this.LoadProperty(property.Key, property.Value.ToString());
        }
    }

    public override string ToString()
    {
        StringBuilder output = new StringBuilder();
        output.Append(this.GetType().Name);
        output.Append('[');
        List<KeyValuePair<string, object>> tempProperties = new List<KeyValuePair<string, object>>(this.Properties);
        tempProperties.Add(new KeyValuePair<string, object>("name", this.Name));
        foreach (var item in tempProperties.OrderBy(x => x.Key))
        {
            output.AppendFormat("{0}={1};", item.Key, item.Value);
        }
        output.Remove(output.Length - 1, 1);
        output.Append(']');
        
        return output.ToString();
    }
}

public abstract class BinaryDocument : Document
{
    protected BinaryDocument(string name, string content = null, int? size = null)
        : base(name, content)
    {
        if (size != null)
        {
            base.LoadProperty("size", size.ToString());
        }
    }
}

public class TextDocument : Document, IEditable
{
    public TextDocument(string name, string content = null, string charset = null)
        : base(name, content)
    {
        if (charset != null)
        {
            base.LoadProperty("charset", charset.ToString());
        }
    }

    public void ChangeContent(string newContent)
    {
        if (base.Properties.Any(x => x.Key == "content"))
        {
            base.Properties.RemoveAll(x => x.Key == "content");
        }
            base.Properties.Add(new KeyValuePair<string, object>("content", newContent));
            base.Content = newContent;
    }
}

public abstract class OfficeDocument : BinaryDocument
{
    protected OfficeDocument(string name, string content = null, int? size = null, string version = null)
    : base(name, content, size)
    {
        if (version != null)
        {
            base.LoadProperty("version", version.ToString());
        }
    }
}

public abstract class MultimediaDocument : BinaryDocument
{
    protected MultimediaDocument(string name, string content = null, int? size = null, int? length = null)
        : base(name, content, size)
    {
        if (length != null)
        {
            base.LoadProperty("length", length.ToString());
        }
    }
}

public class PDFDocument : BinaryDocument, IEncryptable
{
    private bool isEncrypted;

    public PDFDocument(string name, string content = null, int? size = null, int? pages = null)
        : base(name, content, size)
    {
        if (pages != null)
        {
            base.LoadProperty("pages", pages.ToString());
        }
        isEncrypted = false;
    }

    public bool IsEncrypted
    {
        get
        {
            return this.isEncrypted;
        }
    }

    public void Encrypt()
    {
        if (!this.IsEncrypted)
        {
            this.isEncrypted = true;
        }
    }

    public void Decrypt()
    {
        if (this.isEncrypted)
        {
            this.isEncrypted = false;
        }
    }

    public override string ToString()
    {
        if (this.IsEncrypted)
        {
            return string.Format("{0}[encrypted]", this.GetType().Name);
        }
        else
        {
            return base.ToString();
        }
    }
}

public class WordDocument : OfficeDocument, IEditable, IEncryptable
{
    private bool isEncrypted;

    public WordDocument(string name, string content = null, int? size = null, string version = null, int? numberChars = null)
        : base(name, content, size, version)
    {
        if (numberChars != null)
        {
            base.LoadProperty("number of characters", numberChars.ToString());
        }
        isEncrypted = false;
    }

    public void ChangeContent(string newContent)
    {
        if (base.Properties.Any(x => x.Key == "content"))
        {
            base.Properties.RemoveAll(x => x.Key == "content");
        }
            base.Properties.Add(new KeyValuePair<string, object>("content", newContent));
            base.Content = newContent;
    }

    public bool IsEncrypted
    {
        get { return this.isEncrypted; }
    }

    public void Encrypt()
    {
        if (!this.IsEncrypted)
        {
            this.isEncrypted = true;
        }
    }

    public void Decrypt()
    {
        if (this.IsEncrypted)
        {
            this.isEncrypted = false;
        }
    }

    public override string ToString()
    {
        if (this.IsEncrypted)
        {
            return string.Format("{0}[encrypted]", this.GetType().Name);
        }
        else
        {
            return base.ToString();
        }
    }
}

public class ExcelDocument : OfficeDocument, IEditable, IEncryptable
{
    private bool isEncrypted;

    public ExcelDocument(string name, string content = null, int? size = null, string version = null, int? numberCol = null, int? numberRows = null)
        : base(name, content, size, version)
    {
        if (numberRows!= null && numberCol != null)
        {
            base.LoadProperty("number of columns", numberCol.ToString());
            base.LoadProperty("number of rows", numberRows.ToString());
        }
        isEncrypted = false;
    }

    public void ChangeContent(string newContent)
    {
        if (base.Properties.Any(x => x.Key == "content"))
        {
            base.Properties.RemoveAll(x => x.Key == "content");
        }
            base.Properties.Add(new KeyValuePair<string, object>("content", newContent));
            base.Content = newContent;
    }

    public bool IsEncrypted
    {
        get { return this.isEncrypted; }
    }

    public void Encrypt()
    {
        if (!this.IsEncrypted)
        {
            this.isEncrypted = true;
        }
    }

    public void Decrypt()
    {
        if (this.IsEncrypted)
        {
            this.isEncrypted = false;
        }
    }

    public override string ToString()
    {
        if (this.IsEncrypted)
        {
            return string.Format("{0}[encrypted]", this.GetType().Name);
        }
        else
        {
            return base.ToString();
        }
    }
}

public class AudioDocument : MultimediaDocument
{
    public AudioDocument(string name, string content = null, int? size = null, int? length = null, int? sampleRate = null)
        : base(name, content, size, length)
    {
        if (sampleRate != null)
        {
            base.LoadProperty("samplerate", sampleRate.ToString());
        }
    }
}

public class VideoDocument : MultimediaDocument
{
    public VideoDocument(string name, string content = null, int? size = null, int? length = null, int? frameRate = null)
        : base(name, content, size, length)
    {
        if (frameRate != null)
        {
            base.LoadProperty("framerate", frameRate.ToString());
        }
    }
}

public interface IDocument
{
	string Name { get; }
	string Content { get; }
	void LoadProperty(string key, string value);
	void SaveAllProperties(IList<KeyValuePair<string, object>> output);
	string ToString();
}

public interface IEditable
{
	void ChangeContent(string newContent);
}

public interface IEncryptable
{
	bool IsEncrypted { get; }
	void Encrypt();
	void Decrypt();
}

public class DocumentSystem
{
    public static List<Document> DocumentSystem = new List<Document>();

    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }
  
    private static void AddDocument(string[] attributes, string type)
    {
        string name = string.Empty;
        List<KeyValuePair<string, object>> documentAttributes = new List<KeyValuePair<string, object>>();
        foreach (var item in attributes)
        {
            string[] splitAttributes = item.Split('=');
            if (splitAttributes[0] == "name")
            {
                name = splitAttributes[1];
            }
            else
            {
                documentAttributes.Add(new KeyValuePair<string, object>(splitAttributes[0], splitAttributes[1]));
            }
        }
        Document currentDocument = null;
        if (name != string.Empty)
        {
            switch (type)
            {
                case "txt":
                    currentDocument = new TextDocument(name);
                    break;
                case "pdf":
                    currentDocument = new PDFDocument(name);
                    break;
                case "doc":
                    currentDocument = new WordDocument(name);
                    break;
                case "xls":
                    currentDocument = new ExcelDocument(name);
                    break;
                case "audio":
                    currentDocument = new AudioDocument(name);
                    break;
                case "video":
                    currentDocument = new VideoDocument(name);
                    break;
            }
            Console.WriteLine("Document added: {0}", name);
            currentDocument.SaveAllProperties(documentAttributes);
            DocumentSystem.Add(currentDocument);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void AddTextDocument(string[] attributes)
    {
        AddDocument(attributes, "txt");
    }

    private static void AddPdfDocument(string[] attributes)
    {
        AddDocument(attributes, "pdf");
    }

    private static void AddWordDocument(string[] attributes)
    {
        AddDocument(attributes, "doc");
    }

    private static void AddExcelDocument(string[] attributes)
    {
        AddDocument(attributes, "xls");
    }

    private static void AddAudioDocument(string[] attributes)
    {
        AddDocument(attributes, "audio");
    }

    private static void AddVideoDocument(string[] attributes)
    {
        AddDocument(attributes, "video");
    }

    private static void ListDocuments()
    {
        if (DocumentSystem.Count != 0)
        {
            foreach (var document in DocumentSystem)
            {
                Console.WriteLine(document);
            }
        }
        else
        {
            Console.WriteLine("No documents found");
        }
    }

    private static void EncryptDocument(string name)
    {
        if (DocumentSystem.Any(x => x.Name == name))
        {
            foreach (var document in DocumentSystem.Where(x => x.Name == name))
            {
                if (document is IEncryptable)
                {
                    IEncryptable currDoc = document as IEncryptable;
                    currDoc.Encrypt();
                    Console.WriteLine("Document encrypted: {0}", name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: {0}", name);
                }
            }
        }
        else
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void DecryptDocument(string name)
    {
        if (DocumentSystem.Any(x => x.Name == name))
        {
            foreach (var document in DocumentSystem.Where(x => x.Name == name))
            {
                if (document is IEncryptable)
                {
                    IEncryptable currDoc = document as IEncryptable;
                    currDoc.Decrypt();
                    Console.WriteLine("Document decrypted: {0}", name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: {0}", name);
                }
            }
        }
        else
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void EncryptAllDocuments()
    {
        if (DocumentSystem.Any(x => x is IEncryptable))
        {
            foreach (IEncryptable document in DocumentSystem.Where(x => x is IEncryptable))
            {
                document.Encrypt();
            }
            Console.WriteLine("All documents encrypted");
        }
        else
        {
            Console.WriteLine("No encryptable documents found");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        if (DocumentSystem.Any(x => x.Name == name))
        {
            foreach (var document in DocumentSystem.Where(x => x.Name == name))
            {
                if (document is IEditable)
                {
                    IEditable currDoc = document as IEditable;
                    currDoc.ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: {0}", name);
                }
            }
        }
        else
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }
}
