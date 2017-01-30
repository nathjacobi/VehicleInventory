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
        //**All functions that use the Manufacturer will clear the dictionary at the beginning of their instructions**

        //Tests that a manufacturer can be added to the dictionary
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

        //Tests that the GetManufacturer will return the desired Manufacturer object
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

        //Tests that the proper exception is thrown when trying to get a Manufacturer that doesn't exist
        [TestMethod]
        [ExpectedException(typeof(Exception),
            "That manufacturer was not found")]
        public void ExceptionWhenNoMatchingManufacturer()
        {
            Methods.ManufacturerDictionary.Clear();

            Methods.GetManufacturer("I Do Not Exist");
        }

        //Tests that the proper exception is thrown when trying to add a manufacturer that exists.
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

        //Tests the the Matching year function returns the correct list
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

        //Tests that the matching year function can handle an empty list
        [TestMethod]
        public void MatchingYearEmpty_List()
        {
            List<Vehicle> testList = new List<Vehicle>();
            List<Vehicle> returnedList;

            returnedList = Methods.FindByYear(2006, testList);

            Assert.IsTrue(returnedList.Count == 0);
        }

        //Tests that the matching year function can take an Inventory and return the proper list
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

        //Tests that the matching year function can handle an empty Inventory
        public void MatchingYearEmpty_Inventory()
        {
            Inventory testInventory = new Inventory();
            List<Vehicle> returnedList;

            returnedList = Methods.FindByYear(2006, testInventory);

            Assert.IsTrue(returnedList.Count == 0);
        }

        //Tests that the matching make can take a list and return the proper one
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

        //Tests that the matching make function can handle an empty list
        [TestMethod]
        public void MatchingMakeEmpty_List()
        {
            List<Vehicle> testList = new List<Vehicle>();
            List<Vehicle> returnedList;

            returnedList = Methods.FindByMake("Chevy", testList);

            Assert.IsTrue(returnedList.Count == 0);
        }

        //Tests that the matching make function can take an Inventory and return the proper list
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

        //Tests that the matching handle an empty Inventory
        [TestMethod]
        public void MatchingMakeEmpty_Inventory()
        {
            Inventory testInventory = new Inventory();
            List<Vehicle> returnedList;

            returnedList = Methods.FindByMake("Chevy", testInventory);

            Assert.IsTrue(returnedList.Count == 0);
        }

        //Tests that the adding mileage function properly adds the miles to the given list
        [TestMethod]
        public void AddingMileage_List()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 22000, 5000);

            List<Vehicle> testList = new List<Vehicle>();
            testList.Add(testCar1);

            Methods.AddToMileage(250, testList);

            Assert.AreEqual(5250, testList[0].Mileage);
        }

        //Tests that the adding mileage function can handle an empty list
        [TestMethod]
        public void AddingMileageEmpty_List()
        {
            List<Vehicle> testList = new List<Vehicle>();

            Methods.AddToMileage(250, testList);

            Assert.IsTrue(testList.Count == 0);
        }

        //Tests the adding mileage function with an inventory
        [TestMethod]
        public void AddingMileage_Inventory()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 22000, 5000);

            Inventory testInventory = new Inventory();
            testInventory.AddVehicle(testCar1);

            Methods.AddToMileage(250, testInventory);

            Assert.AreEqual(5250, testInventory.GetVehicleList()[0].Mileage);
        }

        //Tests that the adding mileage function handles an empty inventory
        [TestMethod]
        public void AddingMileageEmpty_Inventory()
        {
            Inventory testInventory = new Inventory();

            Methods.AddToMileage(250, testInventory);

            Assert.IsTrue(testInventory.GetVehicleList().Count == 0);
        }

        //Tests the average MSRP function with a List
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

        //Tests that the average MSRP function will return 0 with an empty list
        [TestMethod]
        public void AveragingMSRPEmpty_List()
        {
            List<Vehicle> testList = new List<Vehicle>();

            Assert.AreEqual(0, Methods.AverageMSRP(testList));
        }

        //Tests the the average MSRP function with an Inventory
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

        //Tests that the average MSRP function return 0 with an empty Inventory
        [TestMethod]
        public void AveragingMSRPEmpty_Inventory()
        {
            Inventory testInventory = new Inventory();

            Assert.AreEqual(0, Methods.AverageMSRP(testInventory));
        }

        //Tests that the function to find average mileage works with a List
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

        //Tests that the function to find average mileage returns 0 with an empty List
        [TestMethod]
        public void AveragingMileageEmpty_List()
        {
            List<Vehicle> testList = new List<Vehicle>();

            Assert.AreEqual(0, Methods.AverageMileage(testList));
        }

        //Tests that the function to find average mileage works with an Inventory
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

        //Tests that the function to find average mileage returns 0 with an empty Inventory
        [TestMethod]
        public void AveragingMileageEmpty_Inventory()
        {
            Inventory testInventory = new Inventory();

            Assert.AreEqual(0, Methods.AverageMileage(testInventory));
        }

        //Tests that the function to find max MSRP works with a List
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

        //Tests that the function to find max MSRP can handle an empty List
        [TestMethod]
        public void FindingMaxMSRPEmpty_List()
        {
            List<Vehicle> testList = new List<Vehicle>();

            Assert.AreEqual(0, Methods.MaxMSRP(testList));
        }

        //Tests that the function to find max MSRP works with an Inventory
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

        //Tests that the function to find max MSRP can handle an empty Inventory
        [TestMethod]
        public void FindingMaxMSRPEmpty_Inventory()
        {
            Inventory testInventory = new Inventory();

            Assert.AreEqual(0, Methods.MaxMSRP(testInventory));
        }

        //Tests that the function to find min MSRP works with a List
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

        //Tests that the function to find min MSRP can handle an empty List
        [TestMethod]
        public void FindingMinMSRPEmpty_List()
        {
            List<Vehicle> testList = new List<Vehicle>();

            Assert.AreEqual(0, Methods.MinMSRP(testList));
        }

        //Tests that the function to find min MSRP works with an Inventory
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

        //Tests that the function to find min MSRP can handle an empty Inventory
        [TestMethod]
        public void FindingMinMSRPEmpty_Inventory()
        {
            Inventory testInventory = new Inventory();

            Assert.AreEqual(0, Methods.MinMSRP(testInventory));
        }

        //Tests that the function to find max mileage works with a given List
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

        //Tests that the function to find max mileage can handle an empty List
        [TestMethod]
        public void FindingMaxMileageEmpty_List()
        {
            List<Vehicle> testList = new List<Vehicle>();

            Assert.AreEqual(0, Methods.MaxMileage(testList));
        }

        //Tests that the function to find max mileage works properly with an Inventory
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

        //Tests that the function to find max mileage can handle an empty Inventory
        [TestMethod]
        public void FindingMaxMileageEmpty_Inventory()
        {
            Inventory testInventory = new Inventory();

            Assert.AreEqual(0, Methods.MaxMileage(testInventory));
        }

        //Tests that the function to find min mileage works properly with a given list
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

        //Tests that the function to find min mileage can handle an empty list
        [TestMethod]
        public void FindingMinMileageEmpty_List()
        {
            List<Vehicle> testList = new List<Vehicle>();

            Assert.AreEqual(0, Methods.MinMileage(testList));
        }

        //Tests that the function to find min mileage works properly with an Inventory
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

        //Tests that the function to find min mileage can handle an empty Inventory
        [TestMethod]
        public void FindingMinMileageEmpty_Inventory()
        {
            Inventory testInventory = new Inventory();

            Assert.AreEqual(0, Methods.MinMileage(testInventory));
        }

        //Tests that the function to count cars that need oil changes works properly with a given List
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

        //Tests that the function to count cars that need oil can handle an empty list
        [TestMethod]
        public void CountingNeededOilEmpty_List()
        {
            List<Vehicle> testList = new List<Vehicle>();

            Assert.AreEqual(0, Methods.CountNeedOilChange(testList));
        }

        //Tests that the function to count cars that need oil changes works properly with an Inventory
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
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 15000, 175000);
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

        //Tests that the function to count cars that need oil changes can handle an empty Inventory
        [TestMethod]
        public void CountingNeededOilEmpty_Inventory()
        {
            Inventory testInventory = new Inventory();

            Assert.AreEqual(0, Methods.CountNeedOilChange(testInventory));
        }
    }
}
