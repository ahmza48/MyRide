namespace LocationClassLibrary
{
    public class Location
    {
        float longitude;
        float latitude;
        
        //properties
        public Location()
        {
            longitude = 0.0f;
            latitude = 0.0f;
        }
        public float Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude = value;
            }
        }
        public float Latitude 
        {
            get
            {
                return latitude;
            } 
            set
            {
                latitude = value;
            }
        }
        //parameterized constructor
        public Location(float _latitude, float _longitude)
        {
            bool invalidInput = true;
            do
            {

                if (_longitude < -180 || _longitude > 180)
                {
                    Console.WriteLine("Longitude should be between -180 and 180.");
                    Console.WriteLine("Enter valid value for longitude: ");
                    _longitude = float.Parse(Console.ReadLine());
                }
                else if (_latitude < -90 || _latitude > 90)
                {
                    Console.WriteLine("Latitude should be between -90 and 90.");
                    Console.WriteLine("Enter valid value for latitude: ");
                    _latitude = float.Parse(Console.ReadLine());
                }
                else
                {
                    latitude = _latitude;
                    longitude = _longitude;
                    invalidInput = false;
                }
            } while (invalidInput);
        }
        //property
        public void setLocation(float _latitude, float _longitude)
        {
            bool invalidInput = true;
            do
            {

                if (_longitude < -180 || _longitude > 180)
                {
                    Console.WriteLine("Longitude should be between -180 and 180.");
                    Console.WriteLine("Enter valid value for longitude: ");
                    _longitude = float.Parse(Console.ReadLine());
                }
                else if (_latitude < -90 || _latitude > 90)
                {
                    Console.WriteLine("Latitude should be between -90 and 90.");
                    Console.WriteLine("Enter valid value for latitude: ");
                    _latitude = float.Parse(Console.ReadLine());
                }
                else
                {
                    latitude = _latitude;
                    longitude = _longitude;
                    invalidInput = false;
                }
            } while (invalidInput);
        }
    }
}