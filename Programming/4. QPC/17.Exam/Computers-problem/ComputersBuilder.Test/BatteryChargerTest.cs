using System;
using ComputersBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class BatteryChargerTest
    {
        private LaptopBattery battery;

        [TestInitialize]
        public void CreateBatteryInstance()
        {
            this.battery = new LaptopBattery();
        }

        [TestMethod]
        public void TestInitialChargeShouldReturn50Percent()
        {
            var actual = this.battery.ChargePercentage;
            var expected = 50;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChargeWithPositiveNumberLessThan100()
        {
            this.battery.Charge(20);
            var actual = this.battery.ChargePercentage;
            var expected = 70;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChargeWithPositiveNumberMoreThan100()
        {
            this.battery.Charge(101);
            var actual = this.battery.ChargePercentage;
            var expected = 100;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChargeWithNegativeNumberBiggerThanCurrentCharge()
        {
            this.battery.Charge(-60);
            var actual = this.battery.ChargePercentage;
            var expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChargeWithNegativeNumberLessThanCurrentCharge()
        {
            this.battery.Charge(-20);
            var actual = this.battery.ChargePercentage;
            var expected = 30;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChargeWitZeroCharge()
        {
            this.battery.Charge(0);
            var actual = this.battery.ChargePercentage;
            var expected = 50;
            Assert.AreEqual(expected, actual);
        }
    }
}
