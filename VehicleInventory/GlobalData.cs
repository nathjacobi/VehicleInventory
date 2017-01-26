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
    }
}
