using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Timers;
using LocationClassLibrary;
using VehicleClassLibrary;
namespace DriverClassLibrary
{
    public class Driver
    {
        //attributes
        int Id;
        string name;
        int age;
        string gender;
        string address;
        string phoneNo;
        Location currLocation;
        Vehicle vehicle;
        List<double> rating;
        bool availability;

        //properties

        public Driver(int id, string name, int age, string gender, string address, string phoneNo, Location currLocation, Vehicle vehicle)
        {
            this.Id = id;
            this.name = name;

            // Age Validation
            while (age < 15)
            {
                Console.WriteLine("Enter Valid Age!");
                age = int.Parse(Console.ReadLine());
            }
            this.age = age;

            // Gender Validation
            while (gender != "Male" && gender != "male" && gender != "Female" && gender != "female")
            {
                Console.WriteLine("Enter Valid Gender!");
                gender = Console.ReadLine();
            }
            this.gender = gender;

            this.address = address;

            // Phone Number Validation
            while (phoneNo.Length != 11 || !phoneNo.All(char.IsDigit))
            {
                Console.WriteLine("Enter a valid 11 digit Phone Number!");
                phoneNo = Console.ReadLine();
            }

            this.phoneNo = phoneNo;
            this.currLocation = currLocation;
            this.vehicle = vehicle;
            this.rating = new List<double>();
            this.availability = true;
            //Console.WriteLine("Created successfully");
        }
        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name=value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 15)
                {
                    bool isInValidAge = true;
                    do
                    {
                        Console.WriteLine("Enter Valid Age!");
                        value=Console.Read();
                        if (value>15) { isInValidAge = false; }
                    } while (isInValidAge);
                    //throw new Exception();
                }
                else
                {
                    age = value;
                }

            }
        }
        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                if (value != "Male" && value != "male" && value != "Female" && value != "female")
                {
                    bool isInValid = true;
                    do
                    {
                        Console.Write("Enter Valid Gender! ");
                        value=Console.ReadLine();
                        if (value == "Male" && value == "male" && value == "Female" && value == "female") { isInValid = false; }
                    } while (isInValid);
                    //throw new Exception();
                }
                else
                {
                    gender = value;
                }
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
        public string PhoneNo
        {
            get
            {
                return phoneNo;
            }
            set
            {
                while (value.Length != 11 || !value.All(char.IsDigit))
                {
                    Console.WriteLine("Enter a valid 11 digit Phone Number!");
                    value = Console.ReadLine();
                }
                phoneNo=value;
            }
        }
        public Location CurrLocation
        {
            get
            {
                return currLocation;
            }
            set
            {
                currLocation= value;
            }
        }
        public Vehicle Vehicle
        {
            get
            {
                return vehicle;
            }
            set
            {
                vehicle= value;
            }
        }
        public List<double> Rating
        {
            get
            { 
                return rating;
            }
            //set
            //{
            //    rating= value;
            //}
        }
        public void addRating(double _rating)
        {
            rating.Add( _rating );
        }
        public double getRating()
        {
            if (rating==null)
            {
                return 0.0;
            }
            else
            {
                double totalRatings = 0.0;
                foreach (var item in rating)
                {
                    totalRatings+= item;
                }
                return totalRatings/rating.Count;
            }
        }
        public bool Availablity
        {
            get
            {
                return availability;
            }
            set
            {
                availability=value;
            }
        }
        public void UpdateAvailability()
        {
            Console.WriteLine("Are you currently Available for ride? Y/N ");
            Console.WriteLine("Press 'Y' for Available and 'N' for Not Available.");
            //char choice = Console.ReadKey().KeyChar;
            string isAvailable = Console.ReadLine();
            //Console.WriteLine("");
            if (isAvailable!="Y" && isAvailable!="y" && isAvailable!="N" && isAvailable!="n")
            {
                bool availabilityFlag = true;
                do
                {
                    Console.WriteLine("Enter a Valid choice for Availability! Y/N. Y for Yes, and N for No.");
                    Console.WriteLine();
                    isAvailable = Console.ReadLine();
                    Console.WriteLine();
                    if (isAvailable=="Y" || isAvailable=="y" || isAvailable=="N" || isAvailable=="n")
                    {
                        availabilityFlag=false;
                    }
                } while (availabilityFlag);
            }
            if (isAvailable=="Y"||isAvailable=="y")
            {
                availability=true;
                Console.WriteLine("\tYou are now Available for ride.");
            }
            else
            {
                availability=false;
                Console.WriteLine("Your availability has now been updated to Not Available.");
            }

        }
        //public void setLocation(Location location)
        //{
        //    currLocation=location;
        //}
        public void UpdateLocation()
        {
            bool isValidLocation = false;
            while (!isValidLocation)
            {
                Console.Write("Enter Location (latitude,longitude): ");
                string input = Console.ReadLine();
                string[] coordinates = input.Split(',');

                if (coordinates.Length != 2)
                {
                    Console.WriteLine("Invalid input. Please Correctly Enter location coordinates (latitude,longitude)");
                    continue;
                }

                float _longitude, _latitude;
                if (!float.TryParse(coordinates[0], out _latitude) || !float.TryParse(coordinates[1], out _longitude))
                {
                    Console.WriteLine("Invalid input. Please enter valid values for start location.");
                    continue;
                }

                try
                {
                    currLocation = new Location(_latitude,_longitude);
                    isValidLocation = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input. " + e.Message);
                }
            }

        }
        public override string ToString()
        {
            return $"Id: {Id} Name:  {name} PhoneNumber: {phoneNo}";
        }
    }
}

