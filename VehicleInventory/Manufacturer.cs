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
        private string mainAddress;
        private string phoneNumber;

        //Constructor for Manufacturer. Takes in the name, address, and phone number
        public Manufacturer(string name, string mainAddress, string phoneNumber)
        {
            this.name = name;
            this.mainAddress = mainAddress;
            this.phoneNumber = phoneNumber;
        }

        //Get set for name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        //Get set for mainAddress
        public string MainAddress
        {
            get { return mainAddress; }
            set { mainAddress = value; }
        }

        //Get set for phoneNumber
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        //Returns a Manufacturer object's info as a formatted string
        public override string ToString()
        {
            return String.Format("Name: {0}, Main Address: {1}, Telephone: {2}\n", name, mainAddress, phoneNumber);
        }
    }
}
