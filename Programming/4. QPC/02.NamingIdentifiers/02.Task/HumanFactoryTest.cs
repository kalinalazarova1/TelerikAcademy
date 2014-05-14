public static class HumanFactoryTest
{
    public static void Main()
    {
        System.Console.WriteLine("Name: {0}, Gender:{1}, Age:{2}", HumanFactory.CreateHuman(23).Name, HumanFactory.CreateHuman(23).Gender, HumanFactory.CreateHuman(23).Age);
    }
}