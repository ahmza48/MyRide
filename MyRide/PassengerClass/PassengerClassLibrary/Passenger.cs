using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace PassengerClassLibrary
{
    public class Passenger
    {
        string name;
        string phoneNo;
        public Passenger()
        {
            name="";
            phoneNo="";
        }
        //Constructor
        public Passenger(string _name, string _phoneNo)
        {
            if(_name.All(Char.IsLetter) && _phoneNo.All(Char.IsDigit) && _phoneNo.Length==11)
            {
                name = _name;
                phoneNo = _phoneNo;
            }
            else
            {
                bool inValidInput = true;
                do
                {
                    Console.WriteLine("Invalid Input for Passenger Info!");
                    Console.WriteLine("Enter Name of Passenger Again: ");
                    _name=Console.ReadLine();
                    Console.WriteLine("Enter Phone Number of Passenger Again: ");
                    _phoneNo=Console.ReadLine();
                    if (_name.All(Char.IsLetter) && _phoneNo.All(Char.IsDigit) && _phoneNo.Length==11)
                    {
                        name = _name;
                        phoneNo = _phoneNo;
                        inValidInput = false;
                    }
                }while(inValidInput);
            }
        }
        //properties
        public string Name
        {
            get { return name; }
            set
            {
                if(value.All(Char.IsLetter)) 
                {
                    name = value;
                }
                else
                {
                    bool inValidInput = true;
                    do
                    {
                        Console.WriteLine("Invalid Input for Passenger Name!");
                        Console.WriteLine("Enter Name of Passenger Again: ");
                        value=Console.ReadLine();
                        if (value.All(Char.IsLetter))
                        {
                            name = value;
                            inValidInput = false;
                        }
                    } while (inValidInput);
                }
            }
        }
        public string PhoneNo
        {
            get { return phoneNo;}
            set
            {
                if (value.All(Char.IsDigit) && value.Length==11)
                {
                    name = value;
                }
                else
                {
                    bool inValidInput = true;
                    do
                    {
                        Console.WriteLine("Invalid Input for Passenger Phone Number!");
                        Console.WriteLine("Enter Phone Number of Passenger Again: ");
                        value=Console.ReadLine();
                        if (value.All(Char.IsDigit) && value.Length==11)
                        {
                            name = value;
                            inValidInput = false;
                        }
                    } while (inValidInput);

                }
            }
        }
    }
}
