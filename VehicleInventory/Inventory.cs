using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory
{
    class Inventory
    {
        List<Vehicle> vehicleList;
        public Inventory()
        {
            vehicleList = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle car)
        {

        }

        public void RemoveVehicle(Vehicle car)
        {

        }

        public List<Vehicle> GetVehicleList()
        {
            return new List<Vehicle>();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
