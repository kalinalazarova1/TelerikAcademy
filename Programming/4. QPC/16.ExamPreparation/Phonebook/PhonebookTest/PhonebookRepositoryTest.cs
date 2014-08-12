using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phonebook;
using System.Collections.Generic;

namespace PhonebookTest
{
    [TestClass]
    public class TestPhonebookRepository
    {
        private IRemovablePhonebookRepository repo = new PhonebookRepository();

        [TestMethod]
        public void TestAddPhoneNewName()
        {
            var actual = repo.AddPhone("me", new List<string> { "+35929811111", "+359899777235", "+359899777236" });
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void TestAddPhoneExistingName()
        {
            repo.AddPhone("me", new List<string> { "+35929811112" });
            var actual = repo.AddPhone("me", new List<string> { "+35929811111", "+359899777235", "+359899777236" });
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TestChangePhoneExisting()
        {
            repo.AddPhone("me", new List<string> { "+35929811111" });
            var actual = repo.ChangePhone("+35929811111", "+359899777235");
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChangePhoneNonExisting()
        {
            repo.AddPhone("me", new List<string> { "+35929811111" });
            var actual = repo.ChangePhone("+35929811112", "+359899777235");
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRemovePhoneExisting()
        {
            repo.AddPhone("me", new List<string> { "+35929811111" });
            var actual = repo.RemovePhone("+35929811111");
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestRemovePhoneNonExisting()
        {
            repo.AddPhone("me", new List<string> { "+35929811111" });
            var actual = repo.RemovePhone("+35929811112");
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestListEntries()
        {
            repo.AddPhone("me", new List<string> { "+35929811111", "+35929811112", "+359899777235" });
            PhonebookEntry[] actual = (PhonebookEntry[])repo.ListEntries(0, 1);
            var entry = new PhonebookEntry();
            entry.Name = "me";
            entry.PhoneNumbers = new SortedSet<string> { "+35929811111", "+35929811112", "+359899777235" };
            var expected = new PhonebookEntry[1];
            expected[0] = entry;
            Assert.AreEqual(expected[0].ToString(), actual[0].ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestListInvalidStartIndex()
        {
            repo.ListEntries(-1, 1).ToList();
        }
    }
}
