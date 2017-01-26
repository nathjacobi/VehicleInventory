using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory
{
    public static class GlobalData
    {
        public static Dictionary<string, Manufacturer> ManufacturerDictionary { get; set; }

        public static void AddManufactuer(Manufacturer maker)
        {
            ManufacturerDictionary.Add(maker.Name, maker);
        }

        public static List<Vehicle> FindByYear(int givenYear, List<Vehicle> givenList)
        {
            List<Vehicle> matchingYear = new List<Vehicle>();
            foreach (Vehicle car in givenList)
            {
                if (car.Year == givenYear)
                    matchingYear.Add(car);
            }
            return matchingYear;
        }

        public static List<Vehicle> FindByYear(int givenYear, Inventory givenInventory)
        {
            List<Vehicle> matchingYear = new List<Vehicle>();
            foreach (Vehicle car in givenInventory.GetVehicleList())
            {
                if (car.Year == givenYear)
                    matchingYear.Add(car);
            }
            return matchingYear;
        }

        public static List<Vehicle> FindByMake(string givenMake, List<Vehicle> givenList)
        {
            List<Vehicle> matchingMake = new List<Vehicle>();
            foreach (Vehicle car in givenList)
            {
                if (car.Make == givenMake)
                    matchingMake.Add(car);
            }
            return matchingMake;
        }

        public static List<Vehicle> FindByMake(string givenMake, Inventory givenInventory)
        {
            List<Vehicle> matchingMake = new List<Vehicle>();
            foreach (Vehicle car in givenInventory.GetVehicleList())
            {
                if (car.Make == givenMake)
                    matchingMake.Add(car);
            }
            return matchingMake;
        }

        public static List<Vehicle> AddToMileage(int additionalMileage, List<Vehicle> givenList)
        {
            foreach (Vehicle car in givenList)
            {
                car.Mileage += additionalMileage;
            }
            return givenList;
        }

        public static List<Vehicle> AddToMileage(int additionalMileage, Inventory givenInventory)
        {
            foreach (Vehicle car in givenInventory.GetVehicleList())
            {
                car.Mileage += additionalMileage;
            }
            return givenInventory.GetVehicleList();
        }
    }
}
