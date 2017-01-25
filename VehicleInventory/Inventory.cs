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

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
