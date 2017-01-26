using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory
{
    public class Manufacturer
    {
        private string name;
        private string mainAddress;
        private string phoneNumber;

        public Manufacturer(string name, string mainAddress, string phoneNumber)
        {
            this.name = name;
            this.mainAddress = mainAddress;
            this.phoneNumber = phoneNumber;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string MainAddress
        {
            get { return mainAddress; }
            set { mainAddress = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
    }
}
