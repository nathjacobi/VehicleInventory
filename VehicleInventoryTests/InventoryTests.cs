using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehicleInventory;

namespace VehicleInventoryTests
{
    [TestClass]
    public class InventoryTests
    {
        //Tests that the contructor makes an object
        [TestMethod]
        public void InventoryCreation()
        {
            Inventory testInventory = new Inventory();

            Assert.IsNotNull(testInventory);
        }

        //Tests that an inventory will return its list correctly
        [TestMethod]
        public void ReturnsInventoryList()
        {
            Inventory testInventory1 = new Inventory();
            Inventory testInventory2 = new Inventory();

            //List that will be compared with testInventory1
            IList<Vehicle> compareList = new List<Vehicle>();

            //Creating the vehicles
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 22000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "Chevy", "Malibu", "Blue", 3000, 2010, 18000, 175000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 45000, 75000);

            //Add the vehicles to the list that will be compared
            compareList.Add(testCar1);
            compareList.Add(testCar2);
            compareList.Add(testCar3);

            //Add vehicles to the testInventory1
            testInventory1.AddVehicle(testCar1);
            testInventory1.AddVehicle(testCar2);
            testInventory1.AddVehicle(testCar3);

            //Checks that the vehicles were added and in the correct order
            Assert.IsTrue(testInventory1.GetVehicleList().SequenceEqual(compareList));

            //Checks that an empty list can be returned
            Assert.IsTrue(testInventory2.GetVehicleList().Count == 0);
        }

        //Tests that vehicles can be added to the list
        [TestMethod]
        public void AddingVehicle()
        {
            Vehicle testCar = new Vehicle("1HGCM82633A004352", "Ford", "Taurus", "Maroon", 3300, 2006, 22000, 135000);
            Inventory testInventory = new Inventory();

            testInventory.AddVehicle(testCar);

            //Checks that the Inventory's list contains the added vehicle
            Assert.IsTrue(testInventory.GetVehicleList().Contains(testCar));
        }

        //Tests that the RemoveVehicle method works as intended
        [TestMethod]
        public void RemovingVehicle()
        {
            Vehicle testCar = new Vehicle("1HGCM82633A004352", "Ford", "Taurus", "Maroon", 3300, 2006, 22000, 135000);
            Inventory testInventory = new Inventory();

            testInventory.AddVehicle(testCar);
            
            //Checks that the vehicle was added to be sure
            Assert.AreEqual(1, testInventory.GetVehicleList().Count);

            //Removes the vehicle
            testInventory.RemoveVehicle(testCar);

            //Checks that the vehicle is no longer in the list
            Assert.IsFalse(testInventory.GetVehicleList().Contains(testCar));

            //Checks that the list is now the correct size
            Assert.AreEqual(0, testInventory.GetVehicleList().Count);
        }

        //Tests the Inventory's overridden ToString method
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

            //The string testInventory1 should output
            string inventory1_compareString = "\nVIN: 1HGCM82633A001234, Make: Ford, Model: Taurus, Color: Maroon," +
                " Weight(in lbs): 3300, Year: 2006, Original MSRP: $22000, Mileage(in Miles): 135000" +
                "\nVIN: 1HGCM82633A001010, Make: Tesla, Model: Roadster, Color: Silver," +
                " Weight(in lbs): 2500, Year: 2012, Original MSRP: $45000, Mileage(in Miles): 75000";
            
            //The string testInventory2 should output, this contains a BMW so it should attach a disclaimer
            string inventory2_compareString = "\nVIN: 1HGCM82633A005678, Make: BMW, Model: M3, Color: Blue," + 
                " Weight(in lbs): 3000, Year: 2010, Original MSRP: $34000, Mileage(in Miles): 95000," +    
                " \u00a9 Copyright BMW AG, Munich, Germany" +
                "\nVIN: 1HGCM82633A001010, Make: Tesla, Model: Roadster, Color: Silver," + 
                " Weight(in lbs): 2500, Year: 2012, Original MSRP: $45000, Mileage(in Miles): 75000";

            //Compares the compare strings to the actual ToString output
            Assert.AreEqual(inventory1_compareString, testInventory1.ToString());
            Assert.AreEqual(inventory2_compareString, testInventory2.ToString());
        }
    }
}
