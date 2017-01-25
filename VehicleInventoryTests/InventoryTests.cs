using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehicleInventory;

namespace VehicleInventoryTests
{
    [TestClass]
    public class InventoryTests
    {
        [TestMethod]
        public void InventoryCreation()
        {
            Inventory testInventory = new Inventory();

            Assert.IsNotNull(testInventory);
        }

        [TestMethod]
        public void ReturnsInventoryList()
        {
            Inventory testInventory = new Inventory();
            List<Vehicle> compareList = new List<Vehicle>();

            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 22000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 18000, 175000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 45000, 75000);

            compareList.Add(testCar1);
            compareList.Add(testCar2);
            compareList.Add(testCar3);

            testInventory.AddVehicle(testCar1);
            testInventory.AddVehicle(testCar2);
            testInventory.AddVehicle(testCar3);

            Assert.AreEqual(compareList, testInventory.GetVehicleList());
        }

        [TestMethod]
        public void AddingVehicle()
        {
            Vehicle testCar = new Vehicle("1HGCM82633A004352", "Ford", "Taurus", "Maroon", 3300, 2006, 22000, 135000);
            Inventory testInventory = new Inventory();

            testInventory.AddVehicle(testCar);

            Assert.IsTrue(testInventory.GetVehicleList().Contains(testCar));
        }

        [TestMethod]
        public void RemovingVehicle()
        {
            Vehicle testCar = new Vehicle("1HGCM82633A004352", "Ford", "Taurus", "Maroon", 3300, 2006, 22000, 135000);
            Inventory testInventory = new Inventory();

            testInventory.AddVehicle(testCar);
            testInventory.RemoveVehicle(testCar);

            Assert.IsFalse(testInventory.GetVehicleList().Contains(testCar));
        }

        [TestMethod]
        public void InventoryListToString_AndDisclaimer()
        {
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 22000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "BMW", "M3", "Blue", 3000, 2010, 34000, 95000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 45000, 75000);

            Inventory testInventory1 = new Inventory();
            Inventory testInventory2 = new Inventory();

            testInventory1.AddVehicle(testCar1);
            testInventory1.AddVehicle(testCar3);

            testInventory2.AddVehicle(testCar2);
            testInventory2.AddVehicle(testCar3);

            string inventory1_compareString = @"VIN: 1HGCM82633A001234, Make: Ford, Model: Taurus, Color: Maroon, 
                Weight(in lbs): 3300, 
                Year: 2006, Original MSRP: $22000, 
                Mileage(in miles): 135000\n
                VIN: 1HGCM82633A001010, Make: Tesla, Model: Roadster, Color: Silver, 
                Weight(in lbs): 2500, 
                Year: 2006, Original MSRP: $45000, 
                Mileage(in miles): 75000\n";

            string inventory2_compareString = @"VIN: 1HGCM82633A005678, Make: BMW, Model: M3, Color: Blue, 
                Weight(in lbs): 3000, 
                Year: 2006, Original MSRP: $34000, 
                Mileage(in miles): 95000    
                \u00A9 Copyright BMW AG, Munich, Germany\n
                VIN: 1HGCM82633A001010, Make: Tesla, Model: Roadster, Color: Silver, 
                Weight(in lbs): 2500, 
                Year: 2006, Original MSRP: $45000, 
                Mileage(in miles): 75000\n";

            Assert.AreEqual(inventory1_compareString, testInventory1.ToString());
            Assert.AreEqual(inventory2_compareString, testInventory2.ToString());
        }
    }
}
