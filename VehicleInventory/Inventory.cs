using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory
{
    public class Inventory
    {
        //List to hold all of the vehicles
        private List<Vehicle> vehicleList;
        private SortedDictionary<string,Manufacturer> manufacturerDictionary;

        //Constructor, creates an empty list
        public Inventory()
        {
            vehicleList = new List<Vehicle>();
        }

        //Adds the given vehicle to the list
        public void AddVehicle(Vehicle car)
        {
            vehicleList.Add(car);
        }

        //Removes the given vehicle to the list
        public void RemoveVehicle(Vehicle car)
        {
            vehicleList.Remove(car);
        }

        //Returns the vehicle list as a List object
        public List<Vehicle> GetVehicleList()
        {
            return vehicleList;
        }

        public List<Vehicle> GetVehicleList(int option)
        {
            List<Vehicle> copyVehicleList = vehicleList;
            if (option == 0)
            {
                copyVehicleList.Sort(delegate (Vehicle x, Vehicle y) { return x.Vin.CompareTo(y.Vin); });
            }
            else if (option == 1)
            {
                copyVehicleList.Sort(delegate (Vehicle x, Vehicle y) { return x.Make.CompareTo(y.Make); });
                return SortByModel(copyVehicleList);
            }
            else if (option == 2)
            {
                copyVehicleList.Sort(delegate (Vehicle x, Vehicle y) { return x.Year.CompareTo(y.Year); });
            }
            else
            {
                Console.WriteLine("No valid option selected. Original list returned.");
            }
            return copyVehicleList;
        }

        private List<Vehicle> SortByModel(List<Vehicle> carList)
        {
            List<Vehicle> sortedVehicleList = new List<Vehicle>();
            List<Vehicle> tempList = new List<Vehicle>();

            foreach (Vehicle car in carList)
            {
                if (tempList.Count == 0)
                {
                    tempList.Add(car);
                }
                else if (tempList[0].Make == car.Make)
                {
                    tempList.Add(car);
                }
                else
                {
                    tempList.Sort(delegate (Vehicle x, Vehicle y) { return x.Make.CompareTo(y.Make); });
                    sortedVehicleList.AddRange(tempList);
                    tempList.Clear();
                    tempList.Add(car);
                }
            }

            return sortedVehicleList;
        }

        //Override of the ToString function so the Inventory will output lists information
        public override string ToString()
        {
            //Empty string to append to
            string listToString = "";

            //Go through each vehicle in the list
            foreach (Vehicle car in vehicleList)
                listToString += car.ToString();

            //Returns the finished string
            return listToString;
        }
    }
}
