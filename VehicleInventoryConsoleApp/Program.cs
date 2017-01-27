using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory;

namespace VehicleInventoryConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Vehicle car1 = new Vehicle();
            Console.WriteLine("Hello world!");
            Vehicle testCar1 = new Vehicle("1HGCM82633A001234", "Ford", "Taurus", "Maroon", 3300, 2006, 22000, 135000);
            Vehicle testCar2 = new Vehicle("1HGCM82633A005678", "BMW", "M3", "Blue", 3000, 2010, 34000, 95000);
            Vehicle testCar3 = new Vehicle("1HGCM82633A001010", "Tesla", "Roadster", "Silver", 2500, 2012, 45000, 75000);
            Vehicle testCar4 = new Vehicle("1HGCM82633A006767", "Ford", "Explorer", "Maroon", 4500, 2011, 28000, 91000);
            Vehicle testCar5 = new Vehicle("1HGCM82633A001122", "BMW", "E300", "Maroon", 2800, 1999, 22000, 155000);

            Inventory testInventory1 = new Inventory();
            List<Vehicle> testList = new List<Vehicle>();

            testInventory1.AddVehicle(testCar1);
            testInventory1.AddVehicle(testCar2);
            testInventory1.AddVehicle(testCar3);
            testInventory1.AddVehicle(testCar4);
            testInventory1.AddVehicle(testCar5);

            Console.WriteLine(testInventory1);

            testInventory1.GetVehicleList(0);
            Console.WriteLine(testInventory1);

            testInventory1.GetVehicleList(1);
            Console.WriteLine(testInventory1);

            testInventory1.GetVehicleList(2);
            Console.WriteLine(testInventory1);

            testList = GlobalData.FindByMake("Ford", testInventory1);
            Console.WriteLine(testList.Count);

            testList = GlobalData.FindByYear(2006, testInventory1);
            Console.WriteLine(testList.Count);

            GlobalData.AddToMileage(111, testInventory1);
            Console.WriteLine(testInventory1);

            Console.ReadLine();
        }
    }
}
