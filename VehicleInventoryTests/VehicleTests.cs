using System;
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

  
    }
}
