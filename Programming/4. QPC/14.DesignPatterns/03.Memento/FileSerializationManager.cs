namespace BinarySerialization
{
    using System.IO;
    using System.Runtime.Serialization;

    public class FileSerializationManager   // Memento
    {
        public FileSerializationManager(IFormatter formatter, string fileName)
        {
            this.Formatter = formatter;
            this.FileName = fileName;
        }

        public IFormatter Formatter { get; private set; }

        public string FileName { get; private set; }

        public void Serialize(object data)  // createMemento()
        {
            var stream = new FileStream(this.FileName, FileMode.Create, FileAccess.Write, FileShare.None); // FileStream is the Caretaker class
            this.Formatter.Serialize(stream, data);
            stream.Close();
        }

        public object Deserialize()     // setMemento()
        {
            var stream = new FileStream(this.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            var deserializedObject = this.Formatter.Deserialize(stream);
            stream.Close();
            return deserializedObject;
        }
    }
}
