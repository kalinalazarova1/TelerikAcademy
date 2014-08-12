using System;
using ComputersBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class CpuRandomTest
    {
        [TestMethod]
        public void CpuRandomShouldBeInRange()
        {
            var cpu = new Cpu32(2);
            var actual = cpu.RandomInRange(1, 1);
            var expected = 1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CpuRandomShouldBeDifferent()
        {
            var cpu = new Cpu32(2);
            var actual = cpu.RandomInRange(1, 10);
            var expected = 1;
            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void CpuRandomShouldBeLessThanMax()
        {
            var cpu = new Cpu32(2);
            for (int i = 0; i < 1000; i++)
            {
                var actual = cpu.RandomInRange(1, 100);
                Assert.IsTrue(actual <= 100);
            }
        }

        [TestMethod]
        public void CpuRandomShouldBeMoreThanMin()
        {
            var cpu = new Cpu32(2);
            for (int i = 0; i < 1000; i++)
            {
                var actual = cpu.RandomInRange(10, 100);
                Assert.IsTrue(actual >= 10);
            }
        }
    }
}
