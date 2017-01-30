﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehicleInventory;

namespace VehicleInventoryTests
{
    [TestClass]
    public class VehicleTests
    {
        [TestMethod]
        public void VehicleCreation_AllAttriubutesAssigned()
        {
            Vehicle testCar = new Vehicle("1HGCM82633A004352", "Ford", "Taurus", "Maroon", 3300, 2006, 22000, 135000);

            Assert.IsNotNull(testCar);

            Assert.AreEqual("1HGCM82633A004352", testCar.Vin);
            Assert.AreEqual("Ford", testCar.Make);
            Assert.AreEqual("Taurus", testCar.Model);
            Assert.AreEqual("Maroon", testCar.Color);
            Assert.AreEqual(3300, testCar.Weight);
            Assert.AreEqual(2006, testCar.Year);
            Assert.AreEqual(22000, testCar.OriginalMSRP);
            Assert.AreEqual(135000, testCar.Mileage);
        }

        [TestMethod]
        public void CheckingNeedForOilChange_IfTrue()
        {
            Methods.ManufacturerDictionary.Clear();

            Manufacturer testFord = new Manufacturer("Ford", "1234 Fake St", "555-222-8888");

            Methods.AddManufactuer(testFord);

            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 20000, 135000);

            Assert.IsTrue(testCar1.NeedOilChange());

            Methods.ManufacturerDictionary.Clear();
        }

        [TestMethod]
        public void CheckingNeedForOilChange_IfFalse()
        {
            Methods.ManufacturerDictionary.Clear();

            Manufacturer testFord = new Manufacturer("Ford", "1234 Fake St", "555-222-8888");

            Methods.AddManufactuer(testFord);

            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 20000, 135000);

            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            int currentDay = DateTime.Now.Day;


            testCar1.UpdateOilChangeInformation(currentYear, currentMonth, currentDay, testCar1.Mileage);

            Assert.IsFalse(testCar1.NeedOilChange());

            Methods.ManufacturerDictionary.Clear();
        }

        [TestMethod]
        public void CheckingNeedForOilChange_IfNoManufacturerNeed()
        {
            Methods.ManufacturerDictionary.Clear();

            Manufacturer testTesla = new Manufacturer("Tesla", "5566 Sun St", "555-111-9999");

            Methods.AddManufactuer(testTesla);

            Vehicle testCar1 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 50000, 75000);

            Assert.IsFalse(testCar1.NeedOilChange());

            Methods.ManufacturerDictionary.Clear();
        }
    }
}
