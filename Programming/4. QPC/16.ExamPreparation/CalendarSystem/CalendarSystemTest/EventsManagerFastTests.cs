using System;
using System.Collections.Generic;
using System.Linq;
using CalendarSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalendarSystemTest
{
    [TestClass]
    public class EventsManagerFastTests
    {
        private EventsManagerFast manager;

        [TestInitialize]
        public void CreateEventsManagerFastInstance()
        {
            this.manager = new EventsManagerFast();
        }

        [TestMethod]
        public void TestAddEventWithTwoArguments()
        {
            var entry = new EventEntry() { Title = "C# exam", Date = new DateTime(2012, 03, 26, 9, 00, 00) };
            manager.AddEvent(entry);
            var actual = manager.ListEvents(new DateTime(2012, 03, 26, 9, 00, 00), 1).ToArray()[0].ToString();
            var expected = "2012-03-26T09:00:00 | C# exam";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAddEventWithThreeArguments()
        {
            var entry = new EventEntry() { Title = "C# exam", Date = new DateTime(2012, 03, 26, 9, 00, 00), Location = "Telerik" };
            manager.AddEvent(entry);
            var actual = manager.ListEvents(new DateTime(2012, 03, 26, 9, 00, 00), 1).ToArray()[0].ToString();
            var expected = "2012-03-26T09:00:00 | C# exam | Telerik";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDeleteExistingEvent()
        {
            var entry = new EventEntry()
            {
                Title = "C# exam",
                Date = new DateTime(2012, 03, 26, 9, 00, 00),
                Location = "Telerik"
            };
            manager.AddEvent(entry);
            var actual = manager.DeleteEventsByTitle(entry.Title);
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDeleteNonExistingEvent()
        {
            var entry = new EventEntry() 
            {
                Title = "C# exam",
                Date = new DateTime(2012, 03, 26, 9, 00, 00),
                Location = "Telerik" 
            };
            var actual = manager.DeleteEventsByTitle(entry.Title);
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestListExistingNumberEvents()
        {
            var firstEntry = new EventEntry()
            {
                Title = "C# exam",
                Date = new DateTime(2012, 03, 26, 9, 00, 00),
                Location = "Telerik"
            };
            manager.AddEvent(firstEntry);
            var secondEntry = new EventEntry()
            {
                Title = "C# exam",
                Date = new DateTime(2012, 03, 26, 16, 00, 00),
                Location = "Telerik"
            };
            manager.AddEvent(secondEntry);
            var actual = manager.ListEvents(new DateTime(2012, 03, 26, 9, 00, 00), 2).ToList();
            var expected = new List<EventEntry>();
            expected.Add(firstEntry);
            expected.Add(secondEntry);
            Assert.IsTrue(expected.SequenceEqual<EventEntry>(actual));
        }

        [TestMethod]
        public void TestListNonExistingNumberEvents()
        {
            var firstEntry = new EventEntry()
            {
                Title = "C# exam",
                Date = new DateTime(2012, 03, 26, 9, 00, 00),
                Location = "Telerik"
            };
            manager.AddEvent(firstEntry);
            var secondEntry = new EventEntry()
            {
                Title = "C# exam",
                Date = new DateTime(2012, 03, 26, 16, 00, 00),
                Location = "Telerik"
            };
            manager.AddEvent(secondEntry);
            var actual = manager.ListEvents(new DateTime(2012, 03, 26, 9, 00, 00), 3).ToList();
            var expected = new List<EventEntry>();
            expected.Add(firstEntry);
            expected.Add(secondEntry);
            Assert.IsTrue(expected.SequenceEqual<EventEntry>(actual));
        }

        [TestMethod]
        public void TestListExistingButLessThanAllNumberEvents()
        {
            var firstEntry = new EventEntry()
            {
                Title = "C# exam",
                Date = new DateTime(2012, 03, 26, 9, 00, 00),
                Location = "Telerik"
            };
            manager.AddEvent(firstEntry);
            var secondEntry = new EventEntry()
            {
                Title = "C# exam",
                Date = new DateTime(2012, 03, 26, 16, 00, 00),
                Location = "Telerik"
            };
            manager.AddEvent(secondEntry);
            var actual = manager.ListEvents(new DateTime(2012, 03, 26, 9, 00, 00), 1).ToList();
            var expected = new List<EventEntry>();
            expected.Add(firstEntry);
            Assert.IsTrue(expected.SequenceEqual<EventEntry>(actual));
        }
    }
}
