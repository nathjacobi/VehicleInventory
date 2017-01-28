using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehicleInventory;

namespace VehicleInventoryTests
{
    [TestClass]
    public class ManufacturerTests
    {
        [TestMethod]
        public void ManufacturerCreation_AttributeAssignment()
        {
            Manufacturer testManufacturer1 = new Manufacturer("Ford", "1234 Huxley St, Detroit MI, 55422", "225-514-8457");
            Manufacturer testManufacturer2 = new Manufacturer("Tesla", "5678 Electric St, Palo Alto CA, 89422", "555-667-1234");


            Assert.IsNotNull(testManufacturer1);
            Assert.AreEqual("Ford", testManufacturer1.Name);
            Assert.AreEqual("1234 Huxley St, Detroit MI, 55422", testManufacturer1.MainAddress);
            Assert.AreEqual("225-514-8457", testManufacturer1.PhoneNumber);
            Assert.AreEqual(true, testManufacturer1.RequiresOilChanges);
            Assert.AreEqual(3000, testManufacturer1.MilesPerOilChange);
            Assert.AreEqual(90, testManufacturer1.DaysPerOilChange);

            Assert.AreEqual(false, testManufacturer2.RequiresOilChanges);
        }

        [TestMethod]
        public void ChagingOilRequirements()
        {
            Manufacturer testManufacturer = new Manufacturer("Ford", "1234 Huxley St, Detroit MI, 55422", "225-514-8457");

            Assert.AreEqual(true, testManufacturer.RequiresOilChanges);
            Assert.AreEqual(3000, testManufacturer.MilesPerOilChange);
            Assert.AreEqual(90, testManufacturer.DaysPerOilChange);

            testManufacturer.changeManufacturerOilRequirements(true, 5000, 115);

            Assert.AreEqual(true, testManufacturer.RequiresOilChanges);
            Assert.AreEqual(5000, testManufacturer.MilesPerOilChange);
            Assert.AreEqual(115, testManufacturer.DaysPerOilChange);
        }

        [TestMethod]
        public void ManufacturerToString()
        {
            Manufacturer testManufacturer = new Manufacturer("Ford", "1234 Huxley St, Detroit MI, 55422", "225-514-8457");

            string expectedString = "Name: Ford, Main Address: 1234 Huxley St, Detroit MI, 55422, Telephone: 225-514-8457\n";

            Assert.AreEqual(expectedString, testManufacturer.ToString());
        }
    }
}
