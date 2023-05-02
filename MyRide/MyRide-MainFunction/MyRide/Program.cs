using DriverClassLibrary;
using VehicleClassLibrary;
using LocationClassLibrary;
using AdminClassLibrary;
using RideClassLibrary;
using PassengerClassLibrary;
using System.Xml.Linq;
using Microsoft.VisualBasic;

Admin admin = new Admin();
Driver driver1 = new Driver(1, "John", 30, "Male", "123 Main St", "12345678901", new Location(2f,3f), new Vehicle("car", "2010", "ABC 123"));
Driver driver2 = new Driver(2, "Jake", 21, "Male", "456 Main St", "04345678902", new Location(56f,77f), new Vehicle("Car", "2014", "XYZ 456"));
Driver driver3 = new Driver(3, "Chris", 30, "Male", "789 Main St", "32145678903", new Location(), new Vehicle("Car", "2020", "LMN 789"));


admin.AddDriver(driver1);
admin.AddDriver(driver2);
admin.AddDriver(driver3);
//admin.print();


Console.WriteLine("--------------------------------------------------------------");
Console.WriteLine($"                     WELCOME TO MYRIDE                    ");
Console.WriteLine("--------------------------------------------------------------");

int choice = -1;

while (choice!=0)
{
    bool isValidInput = false;
    

    while (!isValidInput)
    {
        Console.WriteLine("\t1. Book a Ride");
        Console.WriteLine("\t2. Enter as Driver");
        Console.WriteLine("\t3. Enter as Admin");
        Console.WriteLine("\t0. To Exit.");
        Console.Write("Press 1 to 3 to select an option: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out choice))
        {
            // Check if input is within valid range
            if (choice >= 0 && choice <= 3)
            {
                isValidInput = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please select a choice between numbers 1 and 3.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    // Handle selected option
    switch (choice)
    {
        case 1:
            // Book a ride
            Console.WriteLine($"              BOOKING RIDE.");
            Ride newRide = new Ride();
            newRide.bookRide(admin.List);
            break;
        case 2:
            Console.WriteLine($"              ENTERED AS DRIVER.");
            bool isValid = false;
            while (!isValid)
            {
                Console.Write("Enter ID: ");
                string id = Console.ReadLine();
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                if (name.All(Char.IsLetter) && id.All(Char.IsDigit))
                {
                    isValid=true;
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                    if (!name.All(Char.IsLetter))
                    {
                        Console.WriteLine("Name should contain valid letters.");
                    }
                    if (!id.All(Char.IsDigit))
                    {
                        Console.WriteLine("ID should contain integers only.");
                    }
                }
                if (isValid)
                {
                    int driver_id = int.Parse(id);
                    string driver_name = name;
                    Driver driver = admin.FindDriverByIdAndName(driver_id, driver_name);
                    if (driver==null)
                    {
                        Console.WriteLine("Driver not found. Please try again.");
                        break;
                    }
                    Console.WriteLine($"Hello {driver.Name}!");
                    Console.WriteLine("Enter your current Location (in the format of latitude,longitude):");
                    driver.UpdateLocation();

                    int driverChoice = 0;
                    bool driverInputFlag = false;


                    while (!driverInputFlag)
                    {
                        Console.WriteLine("Select an option:");
                        Console.WriteLine("1. Change Availability");
                        Console.WriteLine("2. Change Location");
                        Console.WriteLine("3. Exit as Driver");

                        if (!int.TryParse(Console.ReadLine(), out driverChoice) || driverChoice < 1 || driverChoice > 3)
                        {
                            Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                        }
                        else
                        {
                            driverInputFlag = true;
                        }
                    }
                    if (driverChoice==1)
                    {
                        // Updating Availability
                        Console.WriteLine("Enter your availability");
                        driver.UpdateAvailability();
                        return;
                    }
                    if (driverChoice==2)
                    {
                        // Updating Location
                        Console.WriteLine("Enter your new Location");
                        driver.UpdateLocation();
                        Console.WriteLine("Location updated successfully.");
                        return;
                    }
                    if (driverChoice==3)
                    {
                        continue;
                    }

                }

            }
            break;
        case 3:
            Console.WriteLine("              ENTERED AS ADMIN.");
            int adminOption = 0;
            bool input = false;

            while (!input)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add Driver");
                Console.WriteLine("2. Remove Driver");
                Console.WriteLine("3. Update Driver");
                Console.WriteLine("4. Search Driver");
                Console.WriteLine("5. Exit as Admin");

                if (!int.TryParse(Console.ReadLine(), out adminOption) || adminOption < 1 || adminOption > 5)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                }
                else
                {
                    input = true;
                }
            }


            if (adminOption==1)
            {
                // Adding driver
                admin.addDriver();
            }
            if (adminOption==2)
            {
                // Removing driver
                admin.removeDriver();
            }
            if (adminOption==3)
            {
                // Updating Driver
                Console.WriteLine("Enter Id of Driver you want to update.");
                int _driverId = 0;
                bool idFlag = false;

                while (!idFlag)
                {

                    if (!int.TryParse(Console.ReadLine(), out _driverId))
                    {
                        Console.WriteLine("Invalid input. Please enter a number for ID.");
                    }
                    else
                    {
                        idFlag = true;
                    }
                }
                // Calling Function for Updation
                admin.updateDriver(_driverId);
            }
            if (adminOption==4)
            {
                // Searching Driver
                admin.searchDriver();
            }
            if (adminOption==5)
            {
                continue;
            }

            break;
    }
}
