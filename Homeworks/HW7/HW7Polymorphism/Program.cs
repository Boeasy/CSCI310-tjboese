/*
- Create a base class called Vehicle that has a number of methods and variables. 
- Derive that class into two different classes (Car and Truck for example) 
where each one will override at least two of the methods from Vehicle. 
- Create objects in Main and demonstrate the classes.
*/

using System;
using System.Runtime.CompilerServices;

namespace HW7Polymorphism
{
    public abstract class Vehicle
    {
        private string make;
        private string model;

        private string color;

        private int year;

        public Vehicle(string make, string model, string color, int year)
        {
            this.make = make;
            this.model = model;
            this.color = color;
            this.year = year;
        }

        public string Make
        {
            get
            {
                return make;
            }
            set
            {
                make = value;
            }
        }
        
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }

        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

        public virtual void PrintVehicle()
        {
        }

        public virtual void SearchVehicle()
        {

        }

    }

    public class Car : Vehicle
    {
        private int numDoors;
        private int numSeats;

        public Car(string make, string model, string color, int year, int numDoors, int numSeats) : base(make, model, color, year)
        {
            this.numDoors = numDoors;
            this.numSeats = numSeats;
        }

        public int NumDoors
        {
            get
            {
                return numDoors;
            }
            set
            {
                numDoors = value;
            }
        }

        public int NumSeats
        {
            get
            {
                return numSeats;
            }
            set
            {
                numSeats = value;
            }
        }

        public override void PrintVehicle()
        {
            Console.WriteLine("Car Make: " + Make);
            Console.WriteLine("Car Model: " + Model);
            Console.WriteLine("Car Color: " + Color);
            Console.WriteLine("Car Year: " + Year);
            Console.WriteLine("Number of Doors: " + NumDoors);
            Console.WriteLine("Number of Seats: " + NumSeats);
        }

        public override void SearchVehicle()
        {
            string tempstring;
            Console.WriteLine("Enter in the make, model, color, and year of the car you are searching for. To leave a field blank enter #. ");
            tempstring = Console.ReadLine();
            string[] parsed_tempstring = tempstring.Split(',');

            using (var reader = new StreamReader("Cars.csv"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parsed_line = line.Split(',');
                    if (parsed_tempstring[0] == parsed_line[0] || parsed_tempstring[0] == "#")
                    {
                        if (parsed_tempstring[1] == parsed_line[1] || parsed_tempstring[1] == "#")
                        {
                            if (parsed_tempstring[2] == parsed_line[2] || parsed_tempstring[2] == "#")
                            {
                                if (parsed_tempstring[3] == parsed_line[3] || parsed_tempstring[3] == "#")
                                {
                                    Console.WriteLine("Car found: ");
                                    Console.WriteLine("Make: " + parsed_line[0]);
                                    Console.WriteLine("Model: " + parsed_line[1]);
                                    Console.WriteLine("Color: " + parsed_line[2]);
                                    Console.WriteLine("Year: " + parsed_line[3]);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public class Truck : Vehicle
    {
        private int numDoors;
        private int numSeats;

        private int bedLength;

        public Truck(string make, string model, string color, int year, int numDoors, int numSeats, int bedLength) : base(make, model, color, year)
        {
            this.numDoors = numDoors;
            this.numSeats = numSeats;
            this.bedLength = bedLength;
        }

        public int NumDoors
        {
            get
            {
                return numDoors;
            }
            set
            {
                numDoors = value;
            }
        }

        public int NumSeats
        {
            get
            {
                return numSeats;
            }
            set
            {
                numSeats = value;
            }
        }

        public int BedLength
        {
            get
            {
                return bedLength;
            }
            set
            {
                bedLength = value;
            }
        }

        public override void PrintVehicle()
        {
            Console.WriteLine("Truck Make: " + Make);
            Console.WriteLine("Truck Model: " + Model);
            Console.WriteLine("Truck Color: " + Color);
            Console.WriteLine("Truck Year: " + Year);
            Console.WriteLine("Number of Doors: " + NumDoors);
            Console.WriteLine("Number of Seats: " + NumSeats);
            Console.WriteLine("Bed Length: " + BedLength);
        }

        public override void SearchVehicle()
        {
            string tempstring;
            Console.WriteLine("Enter in the make, model, color, and year of the truck you are searching for. To leave a field blank enter #. ");
            tempstring = Console.ReadLine();
            string[] parsed_tempstring = tempstring.Split(',');

            using (var reader = new StreamReader("Trucks.csv"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parsed_line = line.Split(',');
                    if (parsed_tempstring[0] == parsed_line[0] || parsed_tempstring[0] == "#")
                    {
                        if (parsed_tempstring[1] == parsed_line[1] || parsed_tempstring[1] == "#")
                        {
                            if (parsed_tempstring[2] == parsed_line[2] || parsed_tempstring[2] == "#")
                            {
                                if (parsed_tempstring[3] == parsed_line[3] || parsed_tempstring[3] == "#")
                                {
                                    Console.WriteLine("Truck found: ");
                                    Console.WriteLine("Make: " + parsed_line[0]);
                                    Console.WriteLine("Model: " + parsed_line[1]);
                                    Console.WriteLine("Color: " + parsed_line[2]);
                                    Console.WriteLine("Year: " + parsed_line[3]);
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter in the make, model, color, year, number of doors, and number of seats for a car (separated by commas): ");
            string tempstring = Console.ReadLine();
            string[] parsed_tempstring = tempstring.Split(',');
            Car car = new Car(parsed_tempstring[0], parsed_tempstring[1], parsed_tempstring[2], int.Parse(parsed_tempstring[3]), int.Parse(parsed_tempstring[4]), int.Parse(parsed_tempstring[5]));

            Console.WriteLine("Enter in the make, model, color, year, number of doors, number of seats, and bed length for a truck (separated by commas): ");
            tempstring = Console.ReadLine();
            parsed_tempstring = tempstring.Split(',');
            Truck truck = new Truck(parsed_tempstring[0], parsed_tempstring[1], parsed_tempstring[2], int.Parse(parsed_tempstring[3]), int.Parse(parsed_tempstring[4]), int.Parse(parsed_tempstring[5]), int.Parse(parsed_tempstring[6]));

            car.PrintVehicle();
            truck.PrintVehicle();

            Console.WriteLine("to search for a car in our inventory, enter 1. to search for a truck, enter 2: ");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                car.SearchVehicle();
            }
            else if (choice == 2)
            {
                truck.SearchVehicle();
            }
            
        }
    }
}

