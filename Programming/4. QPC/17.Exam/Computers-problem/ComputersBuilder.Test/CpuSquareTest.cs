using System;
using ComputersBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class CpuSquareTest
    {
        [TestMethod]
        public void TestCpuSquareWithNegativeNumber()
        {
            var cpu = new Cpu32(2);
            var actual = cpu.SquareNumber(-1);
            var expected = "Number too low.";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCpu32SquareWithMoreThanMaxNumber()
        {
            var cpu = new Cpu32(2);
            var actual = cpu.SquareNumber(501);
            var expected = "Number too high.";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCpu64SquareWithMoreThanMaxNumber()
        {
            var cpu = new Cpu32(2);
            var actual = cpu.SquareNumber(1001);
            var expected = "Number too high.";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCpu128SquareWithMoreThanMaxNumber()
        {
            var cpu = new Cpu32(2);
            var actual = cpu.SquareNumber(2001);
            var expected = "Number too high.";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCpu32SquareWithNormalNumber()
        {
            var cpu = new Cpu32(2);
            var actual = cpu.SquareNumber(10);
            var expected = "Square of 10 is 100.";
            Assert.AreEqual(expected, actual);
        }
    }
}
