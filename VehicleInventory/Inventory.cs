using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory
{
    public class Inventory
    {
        private IList<Vehicle> vehicleList;

        public Inventory()
        {
            vehicleList = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle car)
        {
            vehicleList.Add(car);
        }

        public void RemoveVehicle(Vehicle car)
        {
            vehicleList.Remove(car);
        }

        public IList<Vehicle> GetVehicleList()
        {
            return vehicleList;
        }

        /*VIN: 1HGCM82633A001010, Make: Tesla, Model: Roadster, Color: Silver, 
                Weight(in lbs): 2500, 
                Year: 2006, Original MSRP: $45000,
                Mileage(in miles): 75000\n";*/

        public override string ToString()
        {
            string listToString = "";

            foreach(Vehicle car in vehicleList)
            {
                listToString += String.Format("\nVIN: {0}, Make: {1}, Model: {2}, Color: {3}," +
                                " Weight(in lbs): {4}, Year: {5}, Original MSRP: ${6}, Mileage(in Miles): {7}",
                                car.Vin, car.Make, car.Model, car.Color, car.Weight, car.Year,
                                car.OriginalMSRP, car.Mileage);
                if (car.Make == "BMW")
                    listToString += ", \u00a9 Copyright BMW AG, Munich, Germany";
            }

            return listToString;
        }
    }
}
