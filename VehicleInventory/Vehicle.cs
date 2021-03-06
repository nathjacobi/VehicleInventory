﻿using System;
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
        private int weight;
        private int year;
        private int originalMSRP;
        private int mileage;

        private DateTime dateOfLastOilChange;
        private int mileageOfLastOilChange;

        //Constructor that sets all values given and sets the default oil change values
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

            //Default oil change values are Jan 1st of the year of the vehicle and 0 miles.
            dateOfLastOilChange = new DateTime(year, 1, 1);
            mileageOfLastOilChange = 0;
        }

        //Function that allows you to change the last oil change information
        //Will store the date and the mileage the change occurred
        public void UpdateOilChangeInformation(int year, int month, int day, int mileageAtOilChange)
        {
            dateOfLastOilChange = new DateTime(year, month, day);
            mileageOfLastOilChange = mileageAtOilChange;
        }

        //Checks if the car currently needs an oil change. Uses the current day
        public bool NeedOilChange()
        {
            //Gets the manufacturer's info to know what requirements an oil change has
            Manufacturer makerInfo;
            makerInfo = Methods.GetManufacturer(make);

            //Gets the days since and miles since an oil change
            int daysSinceOilChange = (int) (DateTime.Now - dateOfLastOilChange).TotalDays;
            int milesSinceOilChange = mileage - mileageOfLastOilChange;

            //If the manufacturer requires an oil change and the days or miles since are greater than the requirement
            //Then return true, else no need
            if (makerInfo.RequiresOilChanges && 
                (daysSinceOilChange >= makerInfo.DaysPerOilChange || milesSinceOilChange >= makerInfo.MilesPerOilChange))
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

        public DateTime DateOfLastOilChange
        {
            get { return dateOfLastOilChange; }
        }

        public int MileageOfLastOilChange
        {
            get { return mileageOfLastOilChange; }
        }

        //ToString method for the vehicles that returns a formatted string of its info
        public override string ToString()
        {
            string vehicleToString = "";

            //Formatted string that lists all of its info
            vehicleToString += String.Format("\nVIN: {0}, Make: {1}, Model: {2}, Color: {3}," +
                                " Weight: {4}, Year: {5}, Original MSRP: {6}, Mileage: {7}",
                                vin, make, model, color, weight, year, originalMSRP, mileage);
            //The BMW's require a disclaimer at the end, the unicode symbol is the copyright symbol
            if (make == "BMW")
                vehicleToString += ", \u00a9 Copyright BMW AG, Munich, Germany";

            //Return the final string
            return vehicleToString;
        }
    }
}
