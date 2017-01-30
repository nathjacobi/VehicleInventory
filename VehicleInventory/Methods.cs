using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory
{
    public static class Methods
    {
        //A public static dictionary to store the manufacturer info, and accessible to all classes
        public static Dictionary<string, Manufacturer> ManufacturerDictionary = new Dictionary<string, Manufacturer>();

        //Adds the Manufacturer object to the dictionary with its name as a key
        public static void AddManufactuer(Manufacturer maker)
        {
            //If the manufacturer already has an entry, it throws an exception
            //The exception suggests that if trying to update the info, the Manufacturer class should have the functiions needed.
            if (ManufacturerDictionary.ContainsKey(maker.Name))
                throw (new Exception("That Manufacturer already has information set."
                    + "If updating information, the Manufacturer class has setters for its information."));

            //Add the Manufacturer with the name as the key
            ManufacturerDictionary.Add(maker.Name, maker);
        }

        //Function that takes a string and searches the dictionary for that key
        public static Manufacturer GetManufacturer(string name)
        {
            //To store the key's value
            Manufacturer foundManufacturer;

            //Uses TryGetValue funtion, returns the Manufacturer if it exists
            if (ManufacturerDictionary.TryGetValue(name, out foundManufacturer))
                return foundManufacturer;
            else
                //If the manufacturer does not exist, it throws an exception and lets the user know
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

        //Given a list, get the average MSRP, returns 0 if empty
        public static double AverageMSRP(List<Vehicle> givenList)
        {
            if (givenList.Count == 0)
                return 0;

            int sum = 0;
            foreach (Vehicle car in givenList)
                sum += car.OriginalMSRP;

            return (double) sum / givenList.Count;
        }

        //Given an Inventory, get the average MSRP, returns 0 if empty
        public static double AverageMSRP(Inventory givenInventory)
        {
            if (givenInventory.GetVehicleList().Count == 0)
                return 0;

            int sum = 0;
            foreach (Vehicle car in givenInventory.GetVehicleList())
                sum += car.OriginalMSRP;

            return (double)sum / givenInventory.GetVehicleList().Count;
        }

        //Given a list, get the average mileage, returns 0 if empty
        public static double AverageMileage(List<Vehicle> givenList)
        {
            if (givenList.Count == 0)
                return 0;

            int sum = 0;
            foreach (Vehicle car in givenList)
                sum += car.Mileage;

            return (double)sum / givenList.Count;
        }

        //Given an Inventory, get the average mileage, returns 0 if empty
        public static double AverageMileage(Inventory givenInventory)
        {
            if (givenInventory.GetVehicleList().Count == 0)
                return 0;

            int sum = 0;
            foreach (Vehicle car in givenInventory.GetVehicleList())
                sum += car.Mileage;

            return (double)sum / givenInventory.GetVehicleList().Count;
        }

        //Given a list, get the max MSRP, returns 0 if empty
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

        //Given an Inventory, get the max MSRP, returns 0 if empty
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

        //Given a List, get the min MSRP, returns 0 if empty
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

        //Given an Inventory, get the max MSRP, returns 0 if empty
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

        //Given a List, get the max mileage, returns 0 if empty
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

        //Given an Inventory, get the max mileage, returns 0 if empty
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

        //Given a List, get the min mileage, returns 0 if empty
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

        //Given an Inventory, get the min mileage, returns 0 if empty
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

        //Given a List, get count of the number of vehicles needing an oil change
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

        //Given an Inventory, get count of the number of vehicles needing an oil change
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
