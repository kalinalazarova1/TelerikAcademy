namespace BinarySerialization
{
    using System;
    using System.Runtime.Serialization.Formatters.Binary;

    internal class MementoTest
    {
        internal static void Main()
        {
            var mother = new Parent("Velichka", false);
            var father = new Parent("Gancho", true);
            var pesho = new Person("Pesho Goshov", 23, true);
            pesho.Add(mother);
            pesho.Add(father);
            Console.WriteLine("Original object:");
            Console.WriteLine("---------------------------");
            Console.WriteLine(pesho);
            Console.WriteLine("---------------------------");

            var memento = new FileSerializationManager(new BinaryFormatter(), "test.bin");
            memento.Serialize(pesho);
            Person newPesho = (Person)memento.Deserialize();
            Console.WriteLine("Retrieved from memento:");
            Console.WriteLine("---------------------------");
            Console.WriteLine(newPesho);
        }

        private static void SerializeChanged(object sender, EventArgs e)
        {
            var manager = new FileSerializationManager(new BinaryFormatter(), "test.bin");
            manager.Serialize(sender);
        }
    }
}
