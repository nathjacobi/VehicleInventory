using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehicleInventory;

namespace VehicleInventoryTests
{
    [TestClass]
    public class MethodsTests
    {
        [TestMethod]
        public void ManufacturerAdded()
        {
            Manufacturer testManufacturer = new Manufacturer("Ford", "1234 Fake St", "555-255-9999");

            Methods.AddManufactuer(testManufacturer);
            Assert.AreEqual(1, Methods.ManufacturerDictionary.Count);
            Assert.IsTrue(Methods.ManufacturerDictionary.ContainsKey("Ford"));
            Assert.IsTrue(Methods.ManufacturerDictionary.ContainsValue(testManufacturer));

            Methods.ManufacturerDictionary.Clear();
        }

        [TestMethod]
        public void ReturnManufacturer()
        {
            Manufacturer testManufacturer = new Manufacturer("Ford", "1234 Fake St", "555-255-9999");
            Methods.AddManufactuer(testManufacturer);

            Manufacturer returnedManufacturer;

            returnedManufacturer = Methods.GetManufacturer(testManufacturer.Name);

            Assert.AreEqual(testManufacturer, returnedManufacturer);

            Methods.ManufacturerDictionary.Clear();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "That manufacturer was not found")]
        public void ExceptionWhenNoMatchingManufacturer()
        {
            Methods.GetManufacturer("I Do Not Exist");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "That Manufacturer already has information set."
             + " If updating information, the Manufacturer class has setters for its information.")]
        public void ExceptionWhenAddingManufacturerWithSameName()
        {
            Manufacturer testManufacturer1 = new Manufacturer("Ford", "1234 Fake St", "555-255-9999");
            Manufacturer testManufacturer2 = new Manufacturer("Ford", "5678 ReallyFake St", "555-888-9999");

            Methods.AddManufactuer(testManufacturer1);
            Methods.AddManufactuer(testManufacturer2);
        }

        [TestMethod]
        public void MatchingYear_List()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 22000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 18000, 175000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 45000, 75000);

            List<Vehicle> testList = new List<Vehicle>();
            List<Vehicle> returnedList;

            testList.Add(testCar1);
            testList.Add(testCar2);
            testList.Add(testCar3);

            returnedList = Methods.FindByYear(2006, testList);

            Assert.IsTrue(returnedList.Count == 1 && returnedList.Contains(testCar1));
        }

        [TestMethod]
        public void MatchingYear_Inventory()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 22000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 18000, 175000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 45000, 75000);

            Inventory testInventory = new Inventory();
            List<Vehicle> returnedList;

            testInventory.AddVehicle(testCar1);
            testInventory.AddVehicle(testCar2);
            testInventory.AddVehicle(testCar3);

            returnedList = Methods.FindByYear(2006, testInventory);

            Assert.IsTrue(returnedList.Count == 1 && returnedList.Contains(testCar1));
        }

        [TestMethod]
        public void MatchingMake_List()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 22000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 18000, 175000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 45000, 75000);

            List<Vehicle> testList = new List<Vehicle>();
            List<Vehicle> returnedList;

            testList.Add(testCar1);
            testList.Add(testCar2);
            testList.Add(testCar3);

            returnedList = Methods.FindByMake("Chevy", testList);

            Assert.IsTrue(returnedList.Count == 1 && returnedList.Contains(testCar2));
        }

        [TestMethod]
        public void MatchingMake_Inventory()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 22000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 18000, 175000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 45000, 75000);

            Inventory testInventory = new Inventory();
            List<Vehicle> returnedList;

            testInventory.AddVehicle(testCar1);
            testInventory.AddVehicle(testCar2);
            testInventory.AddVehicle(testCar3);

            returnedList = Methods.FindByMake("Chevy", testInventory);

            Assert.IsTrue(returnedList.Count == 1 && returnedList.Contains(testCar2));
        }

        [TestMethod]
        public void AddingMileage_List()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 22000, 5000);

            List<Vehicle> testList = new List<Vehicle>();

            Methods.AddToMileage(250, testList);

            Assert.AreEqual(5250, testList[0].Mileage);
        }

        [TestMethod]
        public void AddingMileage_Inventory()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 22000, 5000);

            Inventory testInventory = new Inventory();

            Methods.AddToMileage(250, testInventory);

            Assert.AreEqual(5250, testInventory.GetVehicleList()[0].Mileage);
        }


    }
}
