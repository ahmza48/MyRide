namespace VehicleClassLibrary
{
    public class Vehicle
    {
        string type;
        string model;
        string licensePlate;
        //Constructor
        public Vehicle()
        {
            type="";
            model="";
            licensePlate="";
        }
        public Vehicle(string type, string model, string licensePlate)
        {
            // Type validation
            if (type == "Rickshaw" || type == "rickshaw" || type == "Bike" || type == "bike" || type == "Car" || type == "car")
            {
                this.type = type;
            }
            else
            {
                bool flag = true;
                do
                {
                    Console.WriteLine("Enter a Valid Vehicle Type (Bike,Car,Rickshaw).");
                    type = Console.ReadLine();
                    if (type == "Rickshaw" || type == "rickshaw" || type == "Bike" || type == "bike" || type == "Car" || type == "car")
                    {
                        this.type = type;
                        flag = false;
                    }
                } while (flag);
            }

            // Model validation
            if (model.Length == 4 && model.All(Char.IsDigit))
            {
                this.model = model;
            }
            else
            {
                bool flag = true;
                do
                {
                    Console.WriteLine("Enter Valid Model of Vehicle.");
                    model = Console.ReadLine();
                    if (model.Length == 4 && model.All(Char.IsDigit))
                    {
                        this.model = model;
                        flag = false;
                    }
                } while (flag);
            }

            // License plate validation
            string[] plateNo = licensePlate.Split(' ');
            if (plateNo.Length == 2 && plateNo[0].Length > 2 && plateNo[0].Length <= 3 && plateNo[0].All(Char.IsLetter) && plateNo[1].Length >= 1 && plateNo[1].Length <= 4 && plateNo[1].All(Char.IsDigit))
            {
                this.licensePlate = licensePlate;
            }
            else
            {
                bool flag = true;
                do
                {
                    Console.WriteLine("Enter Valid License No of vehicle.");
                    licensePlate = Console.ReadLine();
                    plateNo = licensePlate.Split(' ');
                    if (plateNo.Length == 2 && plateNo[0].Length > 2 && plateNo[0].Length <= 3 && plateNo[0].All(Char.IsLetter) && plateNo[1].Length >= 1 && plateNo[1].Length <= 4 && plateNo[1].All(Char.IsDigit))
                    {
                        this.licensePlate = licensePlate;
                        flag = false;
                    }
                } while (flag);
            }
        }


        public string Type
        {
            get { return type; }
            set
            {
                if (value=="Rickshaw"||value=="rickshaw"||value=="Bike"||value=="bike"||value=="Car"||value=="car")
                {
                    type =  value;
                }
                else
                {
                    bool flag = true;
                    do
                    {
                        Console.WriteLine("Enter a Valid Vehicle Type (Bike,Car,Rickshaw).");
                        value = Console.ReadLine();
                        if (value=="Rickshaw"||value=="rickshaw"||value=="Bike"||value=="bike"||value=="Car"||value=="car")
                        {
                            type=value;
                            flag=false;
                        }

                    } while (flag);
                }
            }
        }
        public string Model
        {
            get { return model;}
            set
            {
                if (value.Length==4  && value.All(Char.IsDigit))
                {
                    model=value;
                }
                else
                {
                    bool flag = true;
                    do
                    {
                        Console.WriteLine("Enter Valid Model of Vehicle.");
                        value=Console.ReadLine();
                        if (value.Length==4  && value.All(Char.IsDigit))
                        {
                            model=value;
                            flag = false;
                        }

                    } while (flag);
                }
            }
        }
        public string LicensePlate
        {
            get { return licensePlate; }
            set
            {
                string[] plateNo = value.Split(' ');
                if (plateNo.Length==2 && plateNo[0].Length>2 && plateNo[0].Length<=3 && plateNo[0].All(Char.IsLetter) && plateNo[1].Length>=1 && plateNo[1].Length<=4 && plateNo[1].All(Char.IsDigit))
                {
                    model=value;
                }
                else
                {
                    bool flag = true;
                    do
                    {
                        Console.WriteLine("Enter Valid License No of vehicle.");
                        value=Console.ReadLine();
                        if (plateNo.Length==2 && plateNo[0].Length>2 && plateNo[0].Length<=3 && plateNo[0].All(Char.IsLetter) && plateNo[1].Length>=1 && plateNo[1].Length<=4 && plateNo[1].All(Char.IsDigit))
                        {
                            model=value;
                            flag = false;
                        }
                    } while (flag);
                }
            }

        }


    }
}