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
        private string Name { get; set; }
        private string MainAddress { get; set; }
        private string PhoneNumber { get; set; }
        private bool NeedsOilChange { get; set; }
        private int MilesPerOilChange { get; set; }
        private int DaysPerOilChange { get; set; }

        //Constructor for Manufacturer. Takes in the name, address, and phone number
        //Also sets the oil requirements. Automatically sets the Subaru, VW, and Tesla Special conditions
        public Manufacturer(string name, string mainAddress, string phoneNumber)
        {
            Name = name;
            MainAddress = mainAddress;
            PhoneNumber = phoneNumber;

            //If its a Subaru, sets the oil requirements to its special condition
            if (name == "Subaru")
            {
                NeedsOilChange = true;
                MilesPerOilChange = 7000;
                DaysPerOilChange = 180;
            }
            //If its a Volkswagen, sets the oil requirements to its special condition
            else if (name == "Volkswagen")
            {
                NeedsOilChange = true;
                MilesPerOilChange = 8000;
                DaysPerOilChange = 210;
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
                MilesPerOilChange = 3000;
                DaysPerOilChange = 90;
            }
        }

        //Function to change the oil requirements for any Manufacturer in case more special conditions pop up
        public void changeManufacturerOilRequirements(bool needOilChange, int milesPerChange, int daysPerChange)
        {
            NeedsOilChange = needOilChange;
            MilesPerOilChange = milesPerChange;
            DaysPerOilChange = daysPerChange;
        }

        //Returns a Manufacturer object's info as a formatted string
        public override string ToString()
        {
            return String.Format("Name: {0}, Main Address: {1}, Telephone: {2}\n", Name, MainAddress, PhoneNumber);
        }
    }
}
