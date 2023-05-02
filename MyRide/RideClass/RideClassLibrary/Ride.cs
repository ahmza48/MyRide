using PassengerClassLibrary;
using DriverClassLibrary;
using LocationClassLibrary;
using VehicleClassLibrary;
using System.Diagnostics;

namespace RideClassLibrary
{
    public class Ride
    {
        Location start_location;    //Satrting Location of Ride
        Location end_location;  //Destination of Ride
        int price;  //Price for Ride
        Driver driver;  //Assigned Driver
        Passenger passenger;    //Passenger who booked ride

        //functions
        public Ride()
        {
            this.start_location = new Location();
            this.end_location = new Location();
            this.price = 0;
            this.driver = null;
            this.passenger = null;
        }

        public void getLocations()
        {
            // Get start location
            bool isValidStartLocation = false;
            Location startLocation = null;
            while (!isValidStartLocation)
            {
                Console.Write("Enter Start Location (latitude,longitude): ");
                string input = Console.ReadLine();
                string[] coordinates = input.Split(',');

                if (coordinates.Length != 2)
                {
                    Console.WriteLine("Invalid input. Please Correctly Enter Start location coordinates (latitude,longitude)");
                    continue;
                }

                float longitude, latitude;
                if (!float.TryParse(coordinates[0], out latitude) || !float.TryParse(coordinates[1], out longitude))
                {
                    Console.WriteLine("Invalid input. Please enter valid values for start location.");
                    continue;
                }

                try
                {
                    startLocation = new Location(latitude, longitude);
                    isValidStartLocation = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input. " + e.Message);
                }
            }

            // Get end location
            bool isValidEndLocation = false;
            Location endLocation = null;
            while (!isValidEndLocation)
            {
                Console.Write("Enter End Location (latitude,longitude): ");
                string input = Console.ReadLine();
                string[] coordinates = input.Split(',');

                if (coordinates.Length != 2)
                {
                    Console.WriteLine("Invalid input. Please Correctly Enter End location coordinates (latitude,longitude)");
                    continue;
                }

                float longitude, latitude;
                if (!float.TryParse(coordinates[0], out latitude) || !float.TryParse(coordinates[1], out longitude))
                {
                    Console.WriteLine("Invalid input. Please enter valid values for End location.");
                    continue;
                }

                try
                {
                    endLocation = new Location(latitude, longitude);
                    isValidEndLocation = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input. " + e.Message);
                }
            }

            start_location = startLocation;
            end_location = endLocation;
        }

        public  Location Start_Location
        {
            get { return start_location; }
            set { start_location = value; }
        }

        public Location End_Location
        {
            get { return end_location; }
            set { end_location = value; }
        }
        public void assignPassenger()
        {
            // Create a new passenger object
            Passenger _passenger = new Passenger();

            // Get the passenger's name
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            _passenger.Name = name;

            // Get the passenger's phone number
            Console.Write("Enter your phone number: ");
            string phoneNumber = Console.ReadLine();
            _passenger.PhoneNo = phoneNumber;

            //Console.WriteLine("Passenger assigned: " + _passenger.Name);


            //Passenger _passenger = new Passenger(name,phoneNo);
            passenger = _passenger;
        }
        //public void assignPassenger(string name, string phone)
        //{
        //    // Create a new passenger object
        //    Passenger _passenger = new Passenger(name,phone);
        //    passenger = _passenger;
        //    Console.WriteLine("Passenger assigned: " + _passenger.Name);

        //}
 
        public void assignDriver(List<Driver> listOfDrivers,string ride)
        {
            List<Driver> availableDrivers = new List<Driver>();
            foreach (Driver isAvailableDriver in listOfDrivers)
            {
                if (isAvailableDriver.Availablity  && isAvailableDriver.Vehicle.Type==ride)
                {
                    availableDrivers.Add(isAvailableDriver);
                }

            }
            if (availableDrivers == null || availableDrivers.Count == 0)
            {
                Console.WriteLine("No drivers available.");
                return;
            }

            double smallestDistance = double.MaxValue;
            Driver closestDriver = null;
            foreach (Driver driver in availableDrivers)
            {
                double distance = Math.Sqrt(Math.Pow(driver.CurrLocation.Latitude - start_location.Latitude, 2) +
                                   Math.Pow(driver.CurrLocation.Longitude - start_location.Longitude, 2));

                if (distance < smallestDistance)
                {
                    smallestDistance = distance;
                    closestDriver = driver;
                }
            }

            if (closestDriver == null)
            {
                Console.WriteLine("No available drivers.");
                return;
            }

            closestDriver.Availablity = false;
            this.driver = closestDriver;
            Console.WriteLine($"Driver {driver.Name} with ID ({driver.ID}) has been assigned to the ride.");
        }
        public int calculatePrice()
        {
            double distance = Math.Sqrt(Math.Pow(start_location.Latitude-end_location.Latitude, 2)+Math.Pow(start_location.Longitude-end_location.Longitude, 2));
            double fuel_price = 272;
            double commission = 0.0;

            // Calculate commission based on vehicle type
            if (driver.Vehicle.Type == "Bike" || driver.Vehicle.Type == "bike")
            {
                commission = 0.05;
                price = (int)((distance * fuel_price / 50));
                price = (int)(price + (price * commission));
            }
            else if (driver.Vehicle.Type == "Rickshaw" || driver.Vehicle.Type == "rickshaw")
            {
                commission = 0.1;
                price = (int)((distance * fuel_price / 35));
                price = (int)(price + (price * commission));
            }
            else if (driver.Vehicle.Type == "Car" || driver.Vehicle.Type == "car")
            {
                commission = 0.2;
                price = (int)((distance * fuel_price / 15));
                price = (int)(price + (price * commission));
            }
            return price;
        }
        public void giveRating()
        {
            double rating=0.0;
            bool isValidRating = false;

            while (!isValidRating)
            {
                Console.Write("Please Rate the Ride (0-5): ");
                if (double.TryParse(Console.ReadLine(), out rating) && rating >= 0.0 && rating <= 5.0)
                {
                    isValidRating = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Rating should be between 0 and 5.");
                }
            }
            // Add rating to driver's list of ratings

            driver.addRating(rating);
        }

        public void bookRide(List<Driver> driversList)
        {

            //Console.Write("Enter Name");
            //string name = Console.ReadLine();
            assignPassenger();

            getLocations();
            Console.WriteLine("Enter Ride Type");

            string ride = "";
            bool validRideInput = false;

            while (!validRideInput)
            {
                Console.Write("Enter your ride (Rickshaw, Bike or Car): ");
                ride = Console.ReadLine();

                if (ride == "Rickshaw" || ride == "rickshaw" || ride == "Bike" || ride == "bike" || ride == "Car" || ride == "car")
                {
                    validRideInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid ride.");
                }
            }

            assignDriver(driversList, ride);
            if (driver != null)
            {
                int charges = calculatePrice();
                char choice;
                bool validInput = false;
                Console.WriteLine("--------------Thank You--------------");
                Console.WriteLine($"Price for this ride is: {charges}");
                while (!validInput)
                {
                    Console.Write("Enter Y for yes or N for no.");
                    choice = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    // Check if the input is valid (i.e. Y or N)
                    if (choice == 'Y' || choice == 'y' || choice == 'N' || choice == 'n')
                    {
                        if (choice=='Y'||choice=='y')
                        {
                            driver.Availablity=false;
                            Console.WriteLine("Ride booked successfully.");
                            Console.WriteLine("Happy Travel....!");
                            giveRating();
                            validInput = true;
                        }
                        else
                        {
                            driver.Availablity=true;
                            driver=null;
                            return;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter Y or N.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Ride Couldn't be Booked.");
            }
            
        }


    }
}

