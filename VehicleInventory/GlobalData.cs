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

        //Adds the Manufacturer object to the dictionary with its name as a key
        public static void AddManufactuer(Manufacturer maker)
        {
            ManufacturerDictionary.Add(maker.Name, maker);
        }

        //Given a list of vehicles, returns a list of all the vehicles that have the year given
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

        //Given an Inventory, returns a list of all the vehicles that have the year given
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

        //Given a list of vehicles, returns a list of all the vehicles that have the make given
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
        
        //Given an Inventory, returns a list of all the vehicles that have the make given
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

        //Given a list of vehicles, returns a list of all the vehicles with the given mileage added on
        public static void AddToMileage(int additionalMileage, List<Vehicle> givenList)
        {
            foreach (Vehicle car in givenList)
                car.Mileage += additionalMileage;
        }

        //Given an Inventory, returns a list of all the vehicles with the given mileage added on
        public static void AddToMileage(int additionalMileage, Inventory givenInventory)
        {
            foreach (Vehicle car in givenInventory.GetVehicleList())
                car.Mileage += additionalMileage;
        }
    }
}
