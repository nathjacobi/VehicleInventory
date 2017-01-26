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

        //Override of the ToString function so the Inventory will output lists information
        public override string ToString()
        {
            //Empty string to append to
            string listToString = "";

            //Go through each vehicle in the list
            foreach(Vehicle car in vehicleList)
            {
                //Add this formatted string to the and of the entire List's string
                //It newlines at the beginning of a vehicle's string
                listToString += String.Format("\nVIN: {0}, Make: {1}, Model: {2}, Color: {3}," +
                                " Weight(in lbs): {4}, Year: {5}, Original MSRP: ${6}, Mileage(in Miles): {7}",
                                car.Vin, car.Make, car.Model, car.Color, car.Weight, car.Year,
                                car.OriginalMSRP, car.Mileage);
                //The BMW's require a disclaimer at the end, the unicode symbol is the copyright symbol
                if (car.Make == "BMW")
                    listToString += ", \u00a9 Copyright BMW AG, Munich, Germany";
            }

            //Returns the finished string
            return listToString;
        }
    }
}
