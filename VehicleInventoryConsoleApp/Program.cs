using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory;

namespace VehicleInventoryConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Vehicle car1 = new Vehicle();
            Console.WriteLine("Hello world!");
            Console.WriteLine("\u00a9\n");
            Vehicle car = new Vehicle("1HGCM82633A004352", "Ford", "Taurus", "Maroon", 3300, 2006, 22000, 135000);

            string carInfo = String.Format("VIN: {0}, Make: {1}, Model: {2}, Color: {3}," +
                                "Weight{4}, Year: {5}, Original MSRP: ${6}, Mileage(in Miles): {7}\n",
                                car.Vin, car.Make, car.Model, car.Color, car.Weight, car.Year,
                                car.OriginalMSRP, car.Mileage);
            Console.Write(carInfo);
            Console.ReadLine();
        }
    }
}
