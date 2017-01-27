using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory
{
    public class Manufacturer
    {
        //Attributes of a Manufacturer
        private string name;
        private string MainAddress { get; set; }
        private string PhoneNumber { get; set; }
        private bool NeedsOilChange { get; set; }
        private int milesPerOilChange;
        private int daysPerOilChange;

        //Constructor for Manufacturer. Takes in the name, address, and phone number
        //Also sets the oil requirements. Automatically sets the Subaru, VW, and Tesla Special conditions
        public Manufacturer(string name, string mainAddress, string phoneNumber)
        {
            this.name = name;
            MainAddress = mainAddress;
            PhoneNumber = phoneNumber;

            //If its a Subaru, sets the oil requirements to its special condition
            if (name == "Subaru")
            {
                NeedsOilChange = true;
                milesPerOilChange = 7000;
                daysPerOilChange = 180;
            }
            //If its a Volkswagen, sets the oil requirements to its special condition
            else if (name == "Volkswagen")
            {
                NeedsOilChange = true;
                milesPerOilChange = 8000;
                daysPerOilChange = 210;
            }
            //If its a Tesla, sets the oil requirements to its special condition
            else if (name == "Tesla")
            {
                NeedsOilChange = false;
            }
            //Anything else has its oil requirements set to the default
            else
            {
                NeedsOilChange = true;
                milesPerOilChange = 3000;
                daysPerOilChange = 90;
            }
        }

        //Function to change the oil requirements for any Manufacturer in case more special conditions pop up
        public void changeManufacturerOilRequirements(bool needOilChange, int milesPerChange, int daysPerChange)
        {
            NeedsOilChange = needOilChange;
            milesPerOilChange = milesPerChange;
            daysPerOilChange = daysPerChange;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int MilesPerOilChange
        {
            get { return milesPerOilChange; }
            set { milesPerOilChange = value; }
        }

        public int DaysPerOilChange
        {
            get { return daysPerOilChange; }
            set { daysPerOilChange = value; }
        }

        //Returns a Manufacturer object's info as a formatted string
        public override string ToString()
        {
            return String.Format("Name: {0}, Main Address: {1}, Telephone: {2}\n", Name, MainAddress, PhoneNumber);
        }
    }
}
