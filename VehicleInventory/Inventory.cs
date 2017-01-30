using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory
{
    public class Inventory
    {
        //List to hold all of the vehicles
        private List<Vehicle> vehicleList;

        //Constructor, creates an empty list
        public Inventory()
        {
            vehicleList = new List<Vehicle>();
        }

        //Adds the given vehicle to the list
        public void AddVehicle(Vehicle car)
        {
            vehicleList.Add(car);
        }

        //Removes the given vehicle to the list
        public void RemoveVehicle(Vehicle car)
        {
            vehicleList.Remove(car);
        }

        //Returns the vehicle list as a List object
        public List<Vehicle> GetVehicleList()
        {
            return vehicleList;
        }
        
        /*
        Alternate get list function that can sort the list in the Inventory
        The parameter is an integer that corresponds to an option that is available.
            option = 0, Sort by the VIN number of all vehicles
            option = 1, Sort by the Make then Model of all vehicles (Ex. Sorted would be BMW A, Ford A, Ford B, Nissan A)
            option = 2, Sort by the Year of all vehicles
        */
        public List<Vehicle> GetVehicleList(int option)
        {
            List<Vehicle> copyVehicleList = vehicleList;
            //Sort the list by VIN number
            if (option == 0)
            {
                copyVehicleList.Sort(delegate (Vehicle x, Vehicle y) { return x.Vin.CompareTo(y.Vin); });
            }
            //Sort the list by make then model
            else if (option == 1)
            {
                //After sorting by Make, it then calls helper function to sort by model
                copyVehicleList.Sort(delegate (Vehicle x, Vehicle y) { return x.Make.CompareTo(y.Make); });
                return SortByModel(copyVehicleList);
            }
            //Sort the list by year
            else if (option == 2)
            {
                copyVehicleList.Sort(delegate (Vehicle x, Vehicle y) { return x.Year.CompareTo(y.Year); });
            }
            //Temp, may have it throw exception
            else
            {
                throw new Exception("Invalid option for GetVehicleList(int option) function.");
            }

            //Returns the sorted list
            return copyVehicleList;
        }


        //Private function for option = 1 for GetVehicleList
        //Sorts the list by model after being sorted by make
        private List<Vehicle> SortByModel(List<Vehicle> carList)
        {
            //Make a List for the final sort and a list to temporarily hold the vehicles
            List<Vehicle> sortedVehicleList = new List<Vehicle>();
            List<Vehicle> tempList = new List<Vehicle>();

            foreach (Vehicle car in carList)
            {
                //If the tempList is empty, add the car to it
                if (tempList.Count == 0)
                {
                    tempList.Add(car);
                }
                //If its not empty and the Makes match, add the car to the list
                else if (tempList[0].Make == car.Make)
                {
                    tempList.Add(car);
                }
                //If not empty and the makes do not match
                else
                {
                    //Sort the tempList by Model
                    tempList.Sort(delegate (Vehicle x, Vehicle y) { return x.Model.CompareTo(y.Model); });

                    //Add the sorted list to the end of sortedVehicleList
                    sortedVehicleList.AddRange(tempList);

                    //Clear the tempList
                    tempList.Clear();

                    //Add car to the tempList
                    tempList.Add(car);
                }
            }
            sortedVehicleList.AddRange(tempList);
            //Return the final sorted list
            return sortedVehicleList;
        }

        //Override of the ToString function so the Inventory will output lists information
        public override string ToString()
        {
            //Empty string to append to
            string listToString = "";

            //Go through each vehicle in the list and append its string form to the Inventory's string
            foreach (Vehicle car in vehicleList)
                listToString += car.ToString();

            //Returns the finished string
            return listToString;
        }
    }
}
