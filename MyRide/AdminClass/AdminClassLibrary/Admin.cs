using DriverClassLibrary;
using LocationClassLibrary;
using VehicleClassLibrary;
using System.Reflection;
using System.ComponentModel;
using System;

namespace AdminClassLibrary
{
    public class Admin
    {
        List<Driver> drivers;
        int count;

        public Admin()
        {
            drivers = new List<Driver>();
            count = 0;
        }

        //properties
        public void AddDriver(Driver driver)
        {
            drivers.Add(driver);
            //Console.WriteLine("Added Succesfully");
        }
        public void print()
        {
            foreach (Driver driver in drivers)
            {
                Console.WriteLine($"ID: {driver.ID},  Name: { driver.Name}");
            }
        }
        public Driver FindDriverByIdAndName(int id, string name)
        {
            foreach (Driver driver in drivers)
            {
                if (driver.ID == id && driver.Name == name)
                {
                    // Return the driver if found
                    return driver;
                }
            }
            // Return null if no driver was found with the given ID and name
            return null;
        }
        public List<Driver> List
        {
            get { return drivers; }
        }

        public void addDriver()
        {
            Console.Write("Enter driver's Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter driver's Age: ");
            int age;
            // Validating age
            while (!int.TryParse(Console.ReadLine(), out age) || age < 15)
            {
                Console.WriteLine("Invalid age. Please enter a positive integer value for age:");
            }
            Console.Write("Enter driver's Gender: ");
            string gender = Console.ReadLine();
            //validating gnder
            while (gender != "Male" && gender != "male" && gender != "Female" && gender != "female")
            {
                Console.WriteLine("Enter Valid Gender!");
                gender = Console.ReadLine();
            }

            Console.Write("Enter driver's Address: ");
            string address = Console.ReadLine();
            
            Console.Write("Enter driver phone number: ");
            string phoneNumber = Console.ReadLine();
            // Validating phone number
            while (phoneNumber.Length != 11 || !phoneNumber.All(char.IsDigit))
            {
                Console.WriteLine("Enter a valid 11 digit Phone Number!");
                phoneNumber = Console.ReadLine();
            }
            Console.Write("Enter vehicle type (Bike/Rickshaw/Car): ");
            string vehicleType = Console.ReadLine();
            //Vehicle Type Validation
            while (vehicleType!="Rickshaw" && vehicleType!="rickshaw" && vehicleType!="Car" && vehicleType!="car" && vehicleType!="Bike" && vehicleType!="bike")
            {
                Console.WriteLine("Enter Valid Vehicle Type!");
                vehicleType = Console.ReadLine();
            }
            Console.Write("Enter vehicle model: ");
            string vehicleModel = Console.ReadLine();
            //Vehicle Model Validation
            while (vehicleModel.Length!=4 || !vehicleModel.All(Char.IsDigit))
            {
                Console.WriteLine("Enter Valid Vehicle Model!");
                vehicleModel = Console.ReadLine();
            }
            Console.Write("Enter vehicle License: ");
            string vehicleLisence = Console.ReadLine();
            //Vehicle Model Validation
            string[] plateNo = vehicleLisence.Split(' ');

            if (plateNo.Length == 2 && plateNo[0].Length > 2 && plateNo[0].Length <= 3 && plateNo[0].All(Char.IsLetter) && plateNo[1].Length >= 1 && plateNo[1].Length <= 4 && plateNo[1].All(Char.IsDigit))
            {
                vehicleLisence=vehicleLisence;
            }
            else
            {
                bool flag = true;
                do
                {
                    Console.WriteLine("Enter Valid License No of vehicle.");
                    vehicleLisence = Console.ReadLine();
                    plateNo = vehicleLisence.Split(' ');
                    if (plateNo.Length == 2 && plateNo[0].Length > 2 && plateNo[0].Length <= 3 && plateNo[0].All(Char.IsLetter) && plateNo[1].Length >= 1 && plateNo[1].Length <= 4 && plateNo[1].All(Char.IsDigit))
                    {
                        vehicleLisence=vehicleLisence;
                        flag = false;
                    }
                } while (flag);
            }
            
            Location location = new Location();
            Vehicle vehicle = new Vehicle(vehicleType,vehicleModel,vehicleLisence);
            count++;
            Driver lastDriver = List.Last();
            int lastDriverId = lastDriver.ID;
            int id = lastDriverId+1;
            // Creating driver object and add to list
            Driver driver = new Driver(id, name, age, gender, address, phoneNumber, location, vehicle);
            drivers.Add(driver);

            Console.WriteLine($"Driver added successfully with ID: {driver.ID}");
        }
        public int Count
        {
            get
            {
                return count;
            }
        }
        public void updateDriver(int driverId)
        {
            Driver driverToUpdate = null;
            foreach (Driver driver in drivers)
            {
                if (driver.ID == driverId)
                {
                    driverToUpdate = driver;
                    Console.WriteLine($"\t-------------Driver with ID {driverId} exists-------------");
                    break;
                }
            }
            if (driverToUpdate == null)
            {
                Console.WriteLine($"Driver with ID {driverId} not found.");
                return;
            }
            Console.WriteLine("Enter new driver details. Leave field empty to keep the original value.");

            Console.Write("Enter Driver's Name: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                driverToUpdate.Name = name;
            }

            Console.Write("Enter Driver Age: ");
            string ageString = Console.ReadLine();
            if (!string.IsNullOrEmpty(ageString))
            {
                int age;
                while(!int.TryParse(ageString, out age) || age<15)
                {
                    if (string.IsNullOrEmpty(ageString))
                    {
                        break;
                    }
                    Console.WriteLine("Invalid Age. Age should be an integer greater than equal to 15.");
                    ageString = Console.ReadLine();
                }
                driverToUpdate.Age = age;
            }

            Console.Write("Enter driver contact number: ");
            string phoneNumber = Console.ReadLine().Trim();
            if (!string.IsNullOrEmpty(phoneNumber))
            {

                driverToUpdate.PhoneNo = phoneNumber;
            }

            Console.Write("Enter vehicle type (Bike, Rickshaw, Car): ");
            string vehicleTypeString = Console.ReadLine();
            if (!string.IsNullOrEmpty(vehicleTypeString))
            {
                driverToUpdate.Vehicle.Type = vehicleTypeString;
            }

            Console.Write("Enter vehicle registration number: ");
            string plateNo = Console.ReadLine();
            if (!string.IsNullOrEmpty(plateNo))
            {
                driverToUpdate.Vehicle.LicensePlate = plateNo;
            }

            Console.WriteLine("Driver details updated successfully.");
            
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Name\t\tAge\tGender\tV.Type\tV.Model\tV.License");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"{driverToUpdate.Name}\t\t{driverToUpdate.Age}\t{driverToUpdate.Gender}\t{driverToUpdate.Vehicle.Type}\t{driverToUpdate.Vehicle.Model}\t{driverToUpdate.Vehicle.LicensePlate}");


        }
        public void removeDriver()
        {
            int id;
            while (true)
            {
                Console.Write("Enter driver ID to remove: ");
                if (int.TryParse(Console.ReadLine(), out id))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid ID format. ID should be an integer.");
                }
            }

            Driver driverToRemove = null;
            foreach (Driver driver in drivers)
            {
                if (driver.ID == id)
                {
                    driverToRemove = driver;
                    break;
                }
            }
            if (driverToRemove != null)
            {
                drivers.Remove(driverToRemove);
                count--;
                Console.WriteLine($"Driver with ID {id} Removed Successfully.");
            }
            else
            {
                Console.WriteLine($"Driver with ID {id} Couldn't Found.");
            }
        }
        public void searchDriver()
        {
            // Collect search parameters from admin
            Console.Write("Enter Driver ID: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID format. ID should be an integer.");
                Console.Write("Enter Driver ID: ");
            }
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Age: ");
            string ageString = Console.ReadLine();
            Console.Write("Enter Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Enter Address: ");
            string address = Console.ReadLine();
            Console.Write("Enter Vehicle Type: ");
            string vehicleTypeString = Console.ReadLine();
            Console.Write("Enter Vehicle Model: ");
            string vehicleModel = Console.ReadLine();
            Console.Write("Enter Vehicle License Plate: ");
            string vehicleLicensePlate = Console.ReadLine();
            
            int age;
            int.TryParse(ageString, out age);
   
            List<Driver> searchResults = new List<Driver>();

            // Search for matching drivers based on the input parameters
            foreach (Driver driver in drivers)
            {
                if ((id == 0 || driver.ID == id)
                    && (string.IsNullOrEmpty(name) || driver.Name==name)
                    && (age == 0 || driver.Age == age)
                    && (string.IsNullOrEmpty(gender) || driver.Gender==gender)
                    && (string.IsNullOrEmpty(address) || driver.Address == address)
                    && (vehicleTypeString == "" || driver.Vehicle.Type == vehicleTypeString)
                    && (string.IsNullOrEmpty(vehicleModel) || driver.Vehicle.Model==vehicleModel)
                    && (string.IsNullOrEmpty(vehicleLicensePlate) || driver.Vehicle.LicensePlate == vehicleLicensePlate))
                {
                    searchResults.Add(driver);
                }
            }

            // Display search results in a table format
            if (searchResults.Count > 0)
            {
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Name\t\tAge\tGender\tV.Type\tV.Model\tV.License");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------");
                foreach (Driver driver in searchResults)
                {
                    Console.WriteLine($"{driver.Name}\t\t{driver.Age}\t{driver.Gender}\t{driver.Vehicle.Type}\t{driver.Vehicle.Model}\t{driver.Vehicle.LicensePlate}");
                }

                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("No Drivers Found.");
            }
        }



    }
}


