namespace CalendarSystemTest
{
    using System;
    using System.Linq;
    using CalendarSystem;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandParserTests
    {
        private CommandParser parser;

        [TestInitialize]
        public void CreateParserInstance()
        {
            this.parser = new CommandParser();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParsingCommandWithoutWhitespaceShouldThrowException()
        {
            this.parser.Parse("AddEvent");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ParsingCommandWithNullShouldThrowException()
        {
            this.parser.Parse(null);
        }

        [TestMethod]
        public void ParsingValidCommandShouldReturnCommandInfo()
        {
            var actual = this.parser.Parse("AddEvent 2012-03-26T09:00:00 | C# exam");
            var expected = new CommandInfo("AddEvent", new string[] { "2012-03-26T09:00:00", "C# exam" });
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.IsTrue(expected.Arguments.SequenceEqual(actual.Arguments));
        }

        [TestMethod]
        public void ParsingCommandWithoutArgumentsSeparatorShouldReturnEmptyArguments()
        {
            var actual = this.parser.Parse("AddEvent 2012-03-26T09:00:00 C# exam");
            var expected = new CommandInfo("AddEvent", new string[] { "2012-03-26T09:00:00 C# exam" });
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.IsTrue(expected.Arguments.SequenceEqual(actual.Arguments));
        }
    }
}
