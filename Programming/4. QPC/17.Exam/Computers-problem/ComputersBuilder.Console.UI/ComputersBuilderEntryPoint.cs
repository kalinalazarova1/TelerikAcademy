namespace ComputersBuilder.Console.UI
{
    using System;
    using ComputersBuilder;

    public class ComputersBuilderEntryPoint
    {
        public static void Main()
        {
            IPc pc;
            ILaptop laptop;
            IServer server;
            IManufacturer brand;

            var drawer = new StringBuilderDrawer();
            var factory = new ComputerFactory();
            var manufacturerFactory = new ManufacturerFactory(factory, drawer);

            var manufacturer = Console.ReadLine();
            brand = manufacturerFactory.GetManufacturer(manufacturer);

            pc = brand.GetPc();
            server = brand.GetServer();
            laptop = brand.GetLaptop();

            while (true)
            {
                var command = Console.ReadLine();
                if (command == null || command.StartsWith("Exit"))
                {
                    break;
                }

                var splittedCommand = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (splittedCommand.Length != 2)
                {
                    throw new ArgumentException("Invalid command!");
                }

                var commandName = splittedCommand[0];
                var commandArguments = int.Parse(splittedCommand[1]);
                if (commandName == "Charge")
                {
                    laptop.ChargeBattery(commandArguments);
                }
                else if (commandName == "Process")
                {
                    server.Process(commandArguments);
                }
                else if (commandName == "Play")
                {
                    pc.Play(commandArguments);
                }
                else
                {
                    drawer.Draw(new ColorStringBuilder(ConsoleColor.Gray, "Invalid command!"));
                }
            }

            var printer = new ConsolePrinter();
            printer.Print(drawer.GetAllOutput());
        }
    }
}
