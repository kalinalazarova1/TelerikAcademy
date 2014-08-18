namespace _05.ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    // 60/100 BGCoder memory limit
    internal class Program
    {
        private static OrderedBag<Product> productsByName = new OrderedBag<Product>(new NameComaparer());
        private static OrderedBag<Product> productsByProducer = new OrderedBag<Product>(new ProducerComaparer());
        private static OrderedBag<Product> productsByPrice = new OrderedBag<Product>(new PriceComaparer());
        private static OrderedBag<Product> productsByNameProducer = new OrderedBag<Product>(new NameProducerComaparer());

        internal static void Main()
        {
            var output = new StringBuilder();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine();
                output.AppendLine(Execute(command));
            }

            Console.Write(output);
        }

        private static string Execute(string command)
        {
            var indexFirstSpace = command.IndexOf(' ');
            var commandName = command.Substring(0, indexFirstSpace);
            var commandArgs = command.Substring(indexFirstSpace + 1);
            switch (commandName)
            {
                case "AddProduct":
                    return AddProduct(commandArgs.Split(';'));
                case "DeleteProducts":
                    return DeleteProducts(commandArgs.Split(';'));
                case "FindProductsByName":
                    return FindProductsByName(commandArgs.Split(';'));
                case "FindProductsByPriceRange":
                    return FindProductsByPriceRange(commandArgs.Split(';'));
                case "FindProductsByProducer":
                    return FindProductsByProducer(commandArgs.Split(';'));
                default:
                    throw new ArgumentException("Invalid command!");
            }
        }

        private static string AddProduct(string[] args)
        {
            var product = new Product(args[0], args[2], decimal.Parse(args[1]));
            productsByName.Add(product);
            productsByProducer.Add(product);
            productsByPrice.Add(product);
            productsByNameProducer.Add(product);
            return "Product added";
        }

        private static string DeleteProducts(string[] args)
        {
            int count = 0;
            if (args.Length == 1)
            {
                var forDeletion = productsByProducer.GetEqualItems(new Product(null, args[0]));
                foreach (var product in forDeletion)
                {
                    productsByName.RemoveAllCopies(product);
                    productsByPrice.RemoveAllCopies(product);
                    productsByNameProducer.RemoveAllCopies(product);
                    count++;
                }

                productsByProducer.RemoveAllCopies(new Product(null, args[0]));
            }
            else
            {
                var forDeletion = productsByNameProducer.GetEqualItems(new Product(args[0], args[1]));
                foreach (var product in forDeletion)
                {
                    productsByName.RemoveAllCopies(product);
                    productsByPrice.RemoveAllCopies(product);
                    productsByProducer.RemoveAllCopies(product);
                    count++;
                }

                productsByNameProducer.RemoveAllCopies(new Product(args[0], args[1]));
            }

            if (count == 0)
            {
                return "No products found";
            }

            return string.Format("{0} products deleted", count);
        }

        private static string FindProductsByName(string[] args)
        {
            var result = productsByName.GetEqualItems(new Product(args[0], null));
            if (result.Count() == 0)
            {
                return "No products found";
            }

            return string.Join(Environment.NewLine, result.OrderBy(p => p.Producer));
        }

        private static string FindProductsByPriceRange(string[] args)
        {
            var result = productsByPrice.Range(
                new Product(null, null, decimal.Parse(args[0])),
                true,
                new Product(null, null, decimal.Parse(args[1])),
                true);
            if (result.Count == 0)
            {
                return "No products found";
            }

            return string.Join(Environment.NewLine, result.OrderBy(p => p.Name).ThenBy(p => p.Producer));
        }

        private static string FindProductsByProducer(string[] args)
        {
            var result = productsByProducer.GetEqualItems(new Product(null, args[0]));
            if (result.Count() == 0)
            {
                return "No products found";
            }

            return string.Join(Environment.NewLine, result.OrderBy(p => p.Name).ThenBy(p => p.Producer));
        }
    }
}
