using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory
{
    public static class Methods
    {
        public static Dictionary<string, Manufacturer> ManufacturerDictionary = new Dictionary<string, Manufacturer>();

        //Adds the Manufacturer object to the dictionary with its name as a key
        public static void AddManufactuer(Manufacturer maker)
        {
            if (ManufacturerDictionary.ContainsKey(maker.Name))
                throw (new Exception("That Manufacturer already has information set."
                    + "If updating information, the Manufacturer class has setters for its information."));
            ManufacturerDictionary.Add(maker.Name, maker);
        }

        public static Manufacturer GetManufacturer(string name)
        {
            Manufacturer foundManufacturer;
            if (ManufacturerDictionary.TryGetValue(name, out foundManufacturer))
                return foundManufacturer;
            else
                throw (new Exception("That manufacturer was not found"));
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

        public static double AverageMSRP(List<Vehicle> givenList)
        {
            if (givenList.Count == 0)
                return 0;

            int sum = 0;
            foreach (Vehicle car in givenList)
                sum += car.OriginalMSRP;

            return (double) sum / givenList.Count;
        }

        public static double AverageMSRP(Inventory givenInventory)
        {
            if (givenInventory.GetVehicleList().Count == 0)
                return 0;

            int sum = 0;
            foreach (Vehicle car in givenInventory.GetVehicleList())
                sum += car.OriginalMSRP;

            return (double)sum / givenInventory.GetVehicleList().Count;
        }

        public static double AverageMileage(List<Vehicle> givenList)
        {
            if (givenList.Count == 0)
                return 0;

            int sum = 0;
            foreach (Vehicle car in givenList)
                sum += car.Mileage;

            return (double)sum / givenList.Count;
        }

        public static double AverageMileage(Inventory givenInventory)
        {
            if (givenInventory.GetVehicleList().Count == 0)
                return 0;

            int sum = 0;
            foreach (Vehicle car in givenInventory.GetVehicleList())
                sum += car.Mileage;

            return (double)sum / givenInventory.GetVehicleList().Count;
        }

        public static int MaxMSRP(List<Vehicle> givenList)
        {
            if (givenList.Count == 0)
                return 0;

            int maxMSRP = givenList[0].OriginalMSRP;
            foreach(Vehicle car in givenList)
            {
                if (car.OriginalMSRP > maxMSRP)
                    maxMSRP = car.OriginalMSRP;
            }
            return maxMSRP;
        }

        public static int MaxMSRP(Inventory givenInventory)
        {
            if (givenInventory.GetVehicleList().Count == 0)
                return 0;

            int maxMSRP = givenInventory.GetVehicleList()[0].OriginalMSRP;
            foreach (Vehicle car in givenInventory.GetVehicleList())
            {
                if (car.OriginalMSRP > maxMSRP)
                    maxMSRP = car.OriginalMSRP;
            }
            return maxMSRP;
        }

        public static int MinMSRP(List<Vehicle> givenList)
        {
            if (givenList.Count == 0)
                return 0;

            int minMSRP = givenList[0].OriginalMSRP;
            foreach (Vehicle car in givenList)
            {
                if (car.OriginalMSRP < minMSRP)
                    minMSRP = car.OriginalMSRP;
            }
            return minMSRP;
        }

        public static int MinMSRP(Inventory givenInventory)
        {
            if (givenInventory.GetVehicleList().Count == 0)
                return 0;

            int minMSRP = givenInventory.GetVehicleList()[0].OriginalMSRP;
            foreach (Vehicle car in givenInventory.GetVehicleList())
            {
                if (car.OriginalMSRP < minMSRP)
                    minMSRP = car.OriginalMSRP;
            }
            return minMSRP;
        }

        public static int MaxMileage(List<Vehicle> givenList)
        {
            if (givenList.Count == 0)
                return 0;

            int maxMileage = givenList[0].Mileage;
            foreach (Vehicle car in givenList)
            {
                if (car.Mileage > maxMileage)
                    maxMileage = car.Mileage;
            }
            return maxMileage;
        }

        public static int MaxMileage(Inventory givenInventory)
        {
            if (givenInventory.GetVehicleList().Count == 0)
                return 0;

            int maxMileage = givenInventory.GetVehicleList()[0].Mileage;
            foreach (Vehicle car in givenInventory.GetVehicleList())
            {
                if (car.Mileage > maxMileage)
                    maxMileage = car.Mileage;
            }
            return maxMileage;
        }
        public static int MinMileage(List<Vehicle> givenList)
        {
            if (givenList.Count == 0)
                return 0;

            int minMileage = givenList[0].Mileage;
            foreach (Vehicle car in givenList)
            {
                if (car.Mileage < minMileage)
                    minMileage = car.Mileage;
            }
            return minMileage;
        }

        public static int MinMileage(Inventory givenInventory)
        {
            if (givenInventory.GetVehicleList().Count == 0)
                return 0;

            int minMileage = givenInventory.GetVehicleList()[0].Mileage;
            foreach (Vehicle car in givenInventory.GetVehicleList())
            {
                if (car.Mileage < minMileage)
                    minMileage = car.Mileage;
            }
            return minMileage;
        }
        public static int CountNeedOilChange(List<Vehicle> givenList)
        {
            int count = 0;
            foreach (Vehicle car in givenList)
            {
                if (car.NeedOilChange())
                    count++;
            }
            return count;
        }

        public static int CountNeedOilChange(Inventory givenInventory)
        {
            int count = 0;
            foreach (Vehicle car in givenInventory.GetVehicleList())
            {
                if (car.NeedOilChange())
                    count++;
            }
            return count;
        }
    }
}
