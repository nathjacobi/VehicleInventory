using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehicleInventory;

namespace VehicleInventoryTests
{
    [TestClass]
    public class ManufacturerTests
    {
        //Tests that a manufacturer is created and that all proper values are assigned.
        //Also tests that if a special Oil Requirement will be applied if applicable
        [TestMethod]
        public void ManufacturerCreation_AllAttributeAssigned()
        {
            Manufacturer testManufacturer1 = new Manufacturer("Ford", "1234 Huxley St, Detroit MI, 55422", "225-514-8457");
            Manufacturer testManufacturer2 = new Manufacturer("Tesla", "5678 Electric St, Palo Alto CA, 89422", "555-667-1234");

            //Test that the Manufacturer is created
            Assert.IsNotNull(testManufacturer1);

            //Test that the values are assigned
            Assert.AreEqual("Ford", testManufacturer1.Name);
            Assert.AreEqual("1234 Huxley St, Detroit MI, 55422", testManufacturer1.MainAddress);
            Assert.AreEqual("225-514-8457", testManufacturer1.PhoneNumber);
            Assert.AreEqual(true, testManufacturer1.RequiresOilChanges);
            Assert.AreEqual(3000, testManufacturer1.MilesPerOilChange);
            Assert.AreEqual(90, testManufacturer1.DaysPerOilChange);

            //Test that if will assign the correct oil requirement
            Assert.AreEqual(false, testManufacturer2.RequiresOilChanges);
        }

        //Tests that you can change the oil requirements for a manufacturer.
        [TestMethod]
        public void ChagingOilRequirements()
        {
            Manufacturer testManufacturer = new Manufacturer("Ford", "1234 Huxley St, Detroit MI, 55422", "225-514-8457");

            //Tests the default values to make sure they are assigned
            Assert.AreEqual(true, testManufacturer.RequiresOilChanges);
            Assert.AreEqual(3000, testManufacturer.MilesPerOilChange);
            Assert.AreEqual(90, testManufacturer.DaysPerOilChange);

            testManufacturer.changeManufacturerOilRequirements(true, 5000, 115);

            //Tests the new values assigned
            Assert.AreEqual(true, testManufacturer.RequiresOilChanges);
            Assert.AreEqual(5000, testManufacturer.MilesPerOilChange);
            Assert.AreEqual(115, testManufacturer.DaysPerOilChange);
        }

        //Tests the Manufacturer's ToString method
        [TestMethod]
        public void ManufacturerToString()
        {
            Manufacturer testManufacturer = new Manufacturer("Ford", "1234 Huxley St, Detroit MI, 55422", "225-514-8457");

            string expectedString = "Name: Ford, Main Address: 1234 Huxley St, Detroit MI, 55422, Telephone: 225-514-8457\n";

            Assert.AreEqual(expectedString, testManufacturer.ToString());
        }
    }
}
