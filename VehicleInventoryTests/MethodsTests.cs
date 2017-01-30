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
            Methods.ManufacturerDictionary.Clear();

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
            Methods.ManufacturerDictionary.Clear();

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
            Methods.ManufacturerDictionary.Clear();

            Methods.GetManufacturer("I Do Not Exist");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "That Manufacturer already has information set."
             + " If updating information, the Manufacturer class has setters for its information.")]
        public void ExceptionWhenAddingManufacturerWithSameName()
        {
            Methods.ManufacturerDictionary.Clear();

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
            testList.Add(testCar1);

            Methods.AddToMileage(250, testList);

            Assert.AreEqual(5250, testList[0].Mileage);
        }

        [TestMethod]
        public void AddingMileageEmpty_List()
        {
            List<Vehicle> testList = new List<Vehicle>();

            Methods.AddToMileage(250, testList);

            Assert.IsTrue(testList.Count == 0);
        }

        [TestMethod]
        public void AddingMileage_Inventory()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 22000, 5000);

            Inventory testInventory = new Inventory();
            testInventory.AddVehicle(testCar1);

            Methods.AddToMileage(250, testInventory);

            Assert.AreEqual(5250, testInventory.GetVehicleList()[0].Mileage);
        }

        [TestMethod]
        public void AddingMileageEmpty_Inventory()
        {
            Inventory testInventory = new Inventory();

            Methods.AddToMileage(250, testInventory);

            Assert.IsTrue(testInventory.GetVehicleList().Count == 0);
        }

        [TestMethod]
        public void AveragingMSRP_List()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 20000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 15000, 175000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 50000, 75000);

            List<Vehicle> testList = new List<Vehicle>();
            double expectedMSRP = (double)(20000 + 15000 + 50000) / (3);

            testList.Add(testCar1);
            testList.Add(testCar2);
            testList.Add(testCar3);

            Assert.AreEqual(expectedMSRP, Methods.AverageMSRP(testList));
        }

        [TestMethod]
        public void AveragingMSRPEmpty_List()
        {
            List<Vehicle> testList = new List<Vehicle>();

            Assert.AreEqual(0, Methods.AverageMSRP(testList));
        }

        [TestMethod]
        public void AveragingMSRP_Inventory()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 20000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 15000, 175000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 50000, 75000);

            Inventory testInventory = new Inventory();
            double expectedMSRP = (double)(20000 + 15000 + 50000) / (3);

            testInventory.AddVehicle(testCar1);
            testInventory.AddVehicle(testCar2);
            testInventory.AddVehicle(testCar3);

            Assert.AreEqual(expectedMSRP, Methods.AverageMSRP(testInventory));
        }

        [TestMethod]
        public void AveragingMSRPEmpty_Inventory()
        {
            Inventory testInventory = new Inventory();

            Assert.AreEqual(0, Methods.AverageMSRP(testInventory));
        }

        [TestMethod]
        public void AveragingMileage_List()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 20000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 15000, 175000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 50000, 75000);

            List<Vehicle> testList = new List<Vehicle>();
            double expectedMSRP = (double)(135000 + 175000 + 75000) / (3);

            testList.Add(testCar1);
            testList.Add(testCar2);
            testList.Add(testCar3);

            Assert.AreEqual(expectedMSRP, Methods.AverageMileage(testList));
        }

        [TestMethod]
        public void AveragingMileageEmpty_List()
        {
            List<Vehicle> testList = new List<Vehicle>();

            Assert.AreEqual(0, Methods.AverageMileage(testList));
        }

        [TestMethod]
        public void AveragingMileage_Inventory()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 20000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 15000, 175000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 50000, 75000);

            Inventory testInventory = new Inventory();
            double expectedMSRP = (double)(135000 + 175000 + 75000) / (3);

            testInventory.AddVehicle(testCar1);
            testInventory.AddVehicle(testCar2);
            testInventory.AddVehicle(testCar3);

            Assert.AreEqual(expectedMSRP, Methods.AverageMileage(testInventory));
        }

        [TestMethod]
        public void AveragingMileageEmpty_Inventory()
        {
            Inventory testInventory = new Inventory();

            Assert.AreEqual(0, Methods.AverageMileage(testInventory));
        }

        [TestMethod]
        public void FindingMaxMSRP_List()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 20000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 15000, 175000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 50000, 75000);

            List<Vehicle> testList = new List<Vehicle>();
            int expectedMSRP = 50000;

            testList.Add(testCar1);
            testList.Add(testCar2);
            testList.Add(testCar3);

            Assert.AreEqual(expectedMSRP, Methods.MaxMSRP(testList));
        }

        [TestMethod]
        public void FindingMaxMSRPEmpty_List()
        {
            List<Vehicle> testList = new List<Vehicle>();

            Assert.AreEqual(0, Methods.MaxMSRP(testList));
        }

        [TestMethod]
        public void FindingMaxMSRP_Inventory()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 20000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 15000, 175000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 50000, 75000);

            Inventory testInventory = new Inventory();
            int expectedMSRP = 50000;

            testInventory.AddVehicle(testCar1);
            testInventory.AddVehicle(testCar2);
            testInventory.AddVehicle(testCar3);

            Assert.AreEqual(expectedMSRP, Methods.MaxMSRP(testInventory));
        }

        [TestMethod]
        public void FindingMaxMSRPEmpty_Inventory()
        {
            Inventory testInventory = new Inventory();

            Assert.AreEqual(0, Methods.MaxMSRP(testInventory));
        }

        [TestMethod]
        public void FindingMinMSRP_List()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 20000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 15000, 175000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 50000, 75000);

            List<Vehicle> testList = new List<Vehicle>();
            int expectedMSRP = 15000;

            testList.Add(testCar1);
            testList.Add(testCar2);
            testList.Add(testCar3);

            Assert.AreEqual(expectedMSRP, Methods.MinMSRP(testList));
        }

        [TestMethod]
        public void FindingMinMSRPEmpty_List()
        {
            List<Vehicle> testList = new List<Vehicle>();

            Assert.AreEqual(0, Methods.MinMSRP(testList));
        }

        [TestMethod]
        public void FindingMinMSRP_Inventory()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 20000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 15000, 175000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 50000, 75000);

            Inventory testInventory = new Inventory();
            int expectedMSRP = 15000;

            testInventory.AddVehicle(testCar1);
            testInventory.AddVehicle(testCar2);
            testInventory.AddVehicle(testCar3);

            Assert.AreEqual(expectedMSRP, Methods.MinMSRP(testInventory));
        }

        [TestMethod]
        public void FindingMinMSRPEmpty_Inventory()
        {
            Inventory testInventory = new Inventory();

            Assert.AreEqual(0, Methods.MinMSRP(testInventory));
        }

        [TestMethod]
        public void FindingMaxMileage_List()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 20000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 15000, 175000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 50000, 75000);

            List<Vehicle> testList = new List<Vehicle>();
            int expectedMileage = 175000;

            testList.Add(testCar1);
            testList.Add(testCar2);
            testList.Add(testCar3);

            Assert.AreEqual(expectedMileage, Methods.MaxMileage(testList));
        }

        [TestMethod]
        public void FindingMaxMileageEmpty_List()
        {
            List<Vehicle> testList = new List<Vehicle>();

            Assert.AreEqual(0, Methods.MaxMileage(testList));
        }

        [TestMethod]
        public void FindingMaxMileage_Inventory()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 20000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 15000, 175000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 50000, 75000);

            Inventory testInventory = new Inventory();
            int expectedMileage = 175000;

            testInventory.AddVehicle(testCar1);
            testInventory.AddVehicle(testCar2);
            testInventory.AddVehicle(testCar3);

            Assert.AreEqual(expectedMileage, Methods.MaxMileage(testInventory));
        }

        [TestMethod]
        public void FindingMaxMileageEmpty_Inventory()
        {
            Inventory testInventory = new Inventory();

            Assert.AreEqual(0, Methods.MaxMileage(testInventory));
        }

        [TestMethod]
        public void FindingMinMileage_List()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 20000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 15000, 175000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 50000, 75000);

            List<Vehicle> testList = new List<Vehicle>();
            int expectedMileage = 75000;

            testList.Add(testCar1);
            testList.Add(testCar2);
            testList.Add(testCar3);

            Assert.AreEqual(expectedMileage, Methods.MinMileage(testList));
        }

        [TestMethod]
        public void FindingMinMileageEmpty_List()
        {
            List<Vehicle> testList = new List<Vehicle>();

            Assert.AreEqual(0, Methods.MinMileage(testList));
        }

        [TestMethod]
        public void FindingMinMileage_Inventory()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 20000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 15000, 175000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 50000, 75000);

            Inventory testInventory = new Inventory();
            int expectedMileage = 75000;

            testInventory.AddVehicle(testCar1);
            testInventory.AddVehicle(testCar2);
            testInventory.AddVehicle(testCar3);

            Assert.AreEqual(expectedMileage, Methods.MinMileage(testInventory));
        }

        [TestMethod]
        public void FindingMinMileageEmpty_Inventory()
        {
            Inventory testInventory = new Inventory();

            Assert.AreEqual(0, Methods.MinMileage(testInventory));
        }

        [TestMethod]
        public void CountingNeededOil_List()
        {
            Methods.ManufacturerDictionary.Clear();

            Manufacturer testFord = new Manufacturer("Ford", "1234 Fake St", "555-222-8888");
            Manufacturer testChevy = new Manufacturer("Chevy", "4568 Fake St", "555-444-7777");
            Manufacturer testTesla = new Manufacturer("Tesla", "5566 Sun St", "555-111-9999");

            Methods.AddManufactuer(testFord);
            Methods.AddManufactuer(testChevy);
            Methods.AddManufactuer(testTesla);

            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 20000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 15000, 175000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 50000, 75000);

            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            int currentDay = DateTime.Now.Day;


            testCar1.UpdateOilChangeInformation(currentYear, currentMonth, currentDay, testCar1.Mileage);

            List<Vehicle> testList = new List<Vehicle>();
            int expectedCount = 1;

            testList.Add(testCar1);
            testList.Add(testCar2);
            testList.Add(testCar3);

            Assert.AreEqual(expectedCount, Methods.CountNeedOilChange(testList));

            Methods.ManufacturerDictionary.Clear();
        }

        [TestMethod]
        public void CountingNeededOilEmpty_List()
        {
            List<Vehicle> testList = new List<Vehicle>();

            Assert.AreEqual(0, Methods.CountNeedOilChange(testList));
        }

        [TestMethod]
        public void CountingNeededOil_Inventory()
        {
            Methods.ManufacturerDictionary.Clear();

            Manufacturer testFord = new Manufacturer("Ford", "1234 Fake St", "555-222-8888");
            Manufacturer testChevy = new Manufacturer("Chevy", "4568 Fake St", "555-444-7777");
            Manufacturer testTesla = new Manufacturer("Tesla", "5566 Sun St", "555-111-9999");

            Methods.AddManufactuer(testFord);
            Methods.AddManufactuer(testChevy);
            Methods.AddManufactuer(testTesla);

            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 20000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 15000, 1000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 50000, 75000);

            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            int currentDay = DateTime.Now.Day;


            testCar1.UpdateOilChangeInformation(currentYear, currentMonth, currentDay, testCar1.Mileage);

            Inventory testInventory = new Inventory();
            int expectedCount = 1;

            testInventory.AddVehicle(testCar1);
            testInventory.AddVehicle(testCar2);
            testInventory.AddVehicle(testCar3);

            Assert.AreEqual(expectedCount, Methods.CountNeedOilChange(testInventory));

            Methods.ManufacturerDictionary.Clear();
        }

        [TestMethod]
        public void CountingNeededOilEmpty_Inventory()
        {
            Inventory testInventory = new Inventory();

            Assert.AreEqual(0, Methods.CountNeedOilChange(testInventory));
        }
    }
}
