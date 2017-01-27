using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory
{
    public class Vehicle //:IComparable<Vehicle>
    {
        private string vin;
        private string make;
        private string model;
        private string color;
        private int weight; //In lbs
        private int year;
        private int originalMSRP;
        private int mileage; //In miles

        public Vehicle(string vin, string make, string model, string color, int weight, int year, int originalMSRP, int mileage)
        {
            this.vin = vin;
            this.make = make;
            this.model = model;
            this.color = color;
            this.weight = weight;
            this.year = year;
            this.originalMSRP = originalMSRP;
            this.mileage = mileage;
        }

        public Manufacturer ManufacturerInformation()
        {
            Manufacturer makerInfo;
            if (GlobalData.ManufacturerDictionary.TryGetValue(make, out makerInfo))
                return makerInfo;
            else
                return null;
        }

        public string Vin
        {
            get { return vin; }
            set { vin = value; }
        }

        public string Make
        {
            get { return make; }
            set { make = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public int OriginalMSRP
        {
            get { return originalMSRP; }
            set { originalMSRP = value; }
        }

        public int Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }

        public override string ToString()
        {
            string vehicleToString = "";
            vehicleToString += String.Format("\nVIN: {0}, Make: {1}, Model: {2}, Color: {3}," +
                                " Weight(in lbs): {4}, Year: {5}, Original MSRP: ${6}, Mileage(in Miles): {7}",
                                vin, make, model, color, weight, year, originalMSRP, mileage);
            //The BMW's require a disclaimer at the end, the unicode symbol is the copyright symbol
            if (make == "BMW")
                vehicleToString += ", \u00a9 Copyright BMW AG, Munich, Germany";

            return vehicleToString;
        }
    }
}
