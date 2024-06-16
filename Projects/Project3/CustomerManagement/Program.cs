/*

Create a program with the following requirements:

1) You must read in information from a file and create objects from the file. For instance, your file may look like this:
Bergen, Jeremy, 123456, Some Business, 123-456-7890
Skywalker, Luke, 542142, Rebel Alliance, 123-456-7890

where each field in the file corresponds to: last name, first name, customer id, business name, phone number

2) Read the file with at least 4 entries into some sort of collection (List, LinkedList, Dictionary, etc) 
and the collection should store the customers as objects.

3) create a class for customers with the variables(fields) that match what is in your 
input file with corresponding get and set for each one. Also you should have a constructor.

4) create an interface that your class inherits from with at least 2 methods you have to implement.

5) Your class should have a ToString and CompareTo (that you have to implement from IComparable or IComparer)

6) Demonstrate you mini customer database functioning and write out to a new file a formatted list for your customers, 

for example:
Last name: Bergen
First name: Jeremy
ID: 123456
Business: Some Business
Phone: 123-456-7890

*/

using System;

namespace CustomerManagement
{

    interface CustomerInterface
    {
        Customer NewCustomer();
        int EnterCustomerID();
    }
    class Customer : IComparable<Customer>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int CustomerId { get; set; }
        public string BusinessName { get; set; }
        public string PhoneNumber { get; set; }

        public Customer(string lastName, string firstName, int customerId, string businessName, string phoneNumber)
        {
            LastName = lastName;
            FirstName = firstName;
            CustomerId = customerId;
            BusinessName = businessName;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            //phone number syntax from stackoverflow.com/questions/188510/how-to-format-a-string-as-a-telephone-number-in-c-sharp
            return string.Format("Last name: {0}\nFirst name: {1}\nID: {2}\nBusiness: {3}\nPhone: {4}\n", LastName, FirstName, CustomerId, BusinessName, string.Format("{0:(###) ###-####}", Convert.ToInt64(PhoneNumber)));
        }
        public int CompareTo(Customer other)
        {
            return this.BusinessName.CompareTo(other.BusinessName);
        }
        void AddCustomer()
        {
            throw new NotImplementedException();
        }
        void RemoveCustomer()
        {
            throw new NotImplementedException();
        }
    }
    class Program : CustomerInterface
    {
        static void printMenu()
        {
            Console.WriteLine("1. Add a customer");
            Console.WriteLine("2. Remove a customer");
            Console.WriteLine("3. Display all customers");
            Console.WriteLine("4. Read File");
            Console.WriteLine("5. Write to File");
            Console.WriteLine("6. Exit");
        }

        Customer CustomerInterface.NewCustomer()
        {
            Console.WriteLine("Enter the customer's last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter the customer's first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the customer's ID: ");
            int customerId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the customer's business name: ");
            string businessName = Console.ReadLine();
            Console.WriteLine("Enter the customer's phone number: ");
            string phoneNumber = Console.ReadLine();
            Customer newCustomer = new Customer(lastName, firstName, customerId, businessName, phoneNumber);
            return newCustomer;
        }

        int CustomerInterface.EnterCustomerID()
        {
            Console.WriteLine("Enter the customer's ID: ");
            int customerId = Convert.ToInt32(Console.ReadLine());
            return customerId;
        }





        static void Main(string[] args)
        {
            CustomerInterface customerInterface = new Program();
            int temp = 0;
            string lastName, firstName, businessName, phoneNumber, fileName;
            int customerId;

            List<Customer> customers = new List<Customer>();

            Console.WriteLine("Welcome to the Customer Database!");
            while (temp != 6)
            {
            printMenu();
            temp = Convert.ToInt32(Console.ReadLine());
            switch (temp)
            {
                case 1:
                    customers.Add(customerInterface.NewCustomer());
                    break;
                case 2:
                    customerId = customerInterface.EnterCustomerID();
                    customers.RemoveAll(customer => customer.CustomerId == customerId);
                    break;
                case 3:
                    foreach (var customer in customers)
                    {
                        Console.WriteLine(customer.ToString());
                    }
                    break;
                case 4:
                    // Console.WriteLine("Enter the file name: ");
                    fileName = "entries.txt";
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] customerInfo = line.Split(", ");
                            lastName = customerInfo[0];
                            firstName = customerInfo[1];
                            customerId = Convert.ToInt32(customerInfo[2]);
                            businessName = customerInfo[3];
                            phoneNumber = customerInfo[4].Replace("-", ""); //remove dashes from phone number
                            Customer newCustomer = new Customer(lastName, firstName, customerId, businessName, phoneNumber);
                            customers.Add(newCustomer);
                        }
                    }
                    break;
                case 5:
                    fileName = "output.txt";
                    customers.Sort((c1, c2) => c1.CompareTo(c2));
                    using (StreamWriter sw = new StreamWriter(fileName))
                    {
                        foreach (var customer in customers)
                        {
                            sw.WriteLine(customer.ToString());
                        }
                    }
                    break;
                case 6:
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid input");
                    break;

                }
            }
        }
}
}