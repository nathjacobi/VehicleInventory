using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory
{
    public class Vehicle
    {
        private string vin;
        private string make;
        private string model;
        private string color;
        private int weight; //In lbs
        private int year;
        private int originalMSRP;
        private int mileage; //In miles

        private DateTime dateOfLastOilChange;
        private int mileageOfLastOilChange;

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

            dateOfLastOilChange = new DateTime(year, 1, 1);
            mileageOfLastOilChange = 0;
        }

        public void UpdateOilChangeInformation(int year, int month, int day, int mileageAtOilChange)
        {
            dateOfLastOilChange = new DateTime(year, month, day);
            mileageOfLastOilChange = mileageAtOilChange;
        }

        public bool NeedOilChange()
        {
            Manufacturer makerInfo;
            makerInfo = Methods.GetManufacturer(make);

            int daysSinceOilChange = (int) (DateTime.Now - dateOfLastOilChange).TotalDays;
            int milesSinceOilChange = mileage - mileageOfLastOilChange;

            if (makerInfo.RequiresOilChanges && daysSinceOilChange <= makerInfo.MilesPerOilChange
                && milesSinceOilChange <= makerInfo.MilesPerOilChange)
                return true;

            return false;
        }

        //Returns the Manufacturer object that matches the vehicles's make
        public Manufacturer ManufacturerInformation()
        {
            //Manufacturer object to hold and return the info
            Manufacturer makerInfo;
            makerInfo = Methods.GetManufacturer(make);

            return makerInfo;
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

        //ToString method for the vehicles that returns a formatted string of its info
        public override string ToString()
        {
            string vehicleToString = "";

            //Formatted string that lists all of its info
            vehicleToString += String.Format("\nVIN: {0}, Make: {1}, Model: {2}, Color: {3}," +
                                " Weight(in lbs): {4}, Year: {5}, Original MSRP: ${6}, Mileage(in Miles): {7}",
                                vin, make, model, color, weight, year, originalMSRP, mileage);
            //The BMW's require a disclaimer at the end, the unicode symbol is the copyright symbol
            if (make == "BMW")
                vehicleToString += ", \u00a9 Copyright BMW AG, Munich, Germany";

            //Return the final string
            return vehicleToString;
        }
    }
}
