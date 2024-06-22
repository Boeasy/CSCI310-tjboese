/*
For this project, you are going to create a simple event manager. 
You will need to have the following requirements implemented:
Classes for customers and orders which either use an interface or abstract class that they inherit some methods from.
A method in orders that when an order comes in for a customer, an event is triggered to notify something
 (it can just be output to the console and this would be similar to the example I created).
You should also create a method that will alert subscribers to when the order is ready to ship and 
need to create a class that subscribes to that event.
Inside of Main, you will create at least 10 customers and demonstrate the 
events trigger when an order is placed for one of the customers and when an order is ready to ship. 
Additionally write some queries using LINQ or lambdas to pull from the list of customers 
(name or other pieces of information for example).
*/

using System;

namespace EventManager
{
    interface CustomerOrders
    {
        //METHODS
        public static Task PlaceOrder()
        {
            return Task.Run(() => Console.WriteLine("Order Placed"));
        }
        public static Task OrderReadyToShip()
        {
            return Task.Run(() => Console.WriteLine("Order Ready to Ship"));
        }
        public static Task OrderShipped()
        {
            return Task.Run(() => Console.WriteLine("Order Shipped"));
        }
    }

    class Customer : CustomerOrders
    {
        //Customer Properties
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CustomerID { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //METHODS 
        public static Task PlaceOrder()
        {
            return Task.Run(() => Console.WriteLine("Your Order has Been Placed!"));
        }
        public static Task OrderReadyToShip()
        {
            return Task.Run(() => Console.WriteLine("Order is awaiting shippin!"));
        }
        public static Task OrderShipped()
        {
            return Task.Run(() => Console.WriteLine("Your Order is on the way!"));
        }

        public void OrderStatusEvent(object source, OrderStatusEventArgs args)
        {
            Console.WriteLine($"Customer {CustomerID} Order Status Event Triggered: {args.Status}");
        }


    }

    public class OrderStatusEventArgs : EventArgs
    {
        public int Status { get; set; }
        public OrderStatusEventArgs(int status)
        {
            Status = status;
        }
    }

    class Order : CustomerOrders
    {
        //Order Properties
        public string OrderID { get; set; }
        public Customer Customer { get; set; }
        public string OrderDate { get; set; }
        public string ShipDate { get; set; }
        public string Status { get; set; }

        public Order(string orderID, Customer customer, string shipDate)
        {
            OrderID = orderID;
            Customer = customer;
            OrderDate = DateTime.Now.ToString();
            ShipDate = shipDate;
            Status = "Order Placement Pending";
        }

        //Events
        public delegate void OrderStatusEventHandler(object source, OrderStatusEventArgs args);
        public event OrderStatusEventHandler OrderStatusEvent;

        //METHODS 
        public static Task PlaceOrder(Order newOrder)
        {
            return Task.Run(() => 
            {
                Console.WriteLine("Order Placed");
                newOrder.Status = "Order Placed";
                OrderStatusEventArgs tempArgs = new OrderStatusEventArgs(1);
                newOrder.OnOrderStatusEvent(tempArgs);
            });
        }
        public static Task OrderReadyToShip(Order newOrder)
        {
            return Task.Run(() => 
            {
                Console.WriteLine("Order Ready to Ship");
                newOrder.Status = "Ready to Ship";
                OrderStatusEventArgs tempArgs = new OrderStatusEventArgs(2);
                newOrder.OnOrderStatusEvent(tempArgs);
            }
            );
        }
        public static Task OrderShipped(Order newOrder)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Order Shipped");
                newOrder.Status = "Shipped";
                OrderStatusEventArgs tempArgs = new OrderStatusEventArgs(3);
                newOrder.OnOrderStatusEvent(tempArgs);
            }
            );
        }

        protected virtual void OnOrderStatusEvent(OrderStatusEventArgs args)
        {
            if (OrderStatusEvent != null)
            {
                OrderStatusEvent(this, args);
            }
        }

    }

    class CustomerNotifications
    {
        Customer customer {get; set;}
        Order orders {get; set;}

        //constructor
        public CustomerNotifications(Customer customer, Order orders)
        {
            this.customer = customer;
            this.orders = orders;

            //subscribe to event
            orders.OrderStatusEvent += OrderStatusEvent;
        }

        public void OrderStatusEvent(object source, OrderStatusEventArgs args)
        {
            switch (args.Status)
            {
                case 1:
                    Console.WriteLine($"Customer Notifiications: Order Placed for {customer.CustomerID}");
                    break;
                case 2:
                    Console.WriteLine($"Customer Notifications: {customer.CustomerID} Order Ready to Ship");
                    break;
                case 3:
                    Console.WriteLine($"Customer Notifications: {customer.CustomerID} Order Shipped");
                    break;
                default:
                    Console.WriteLine($"Customer Notifications: {customer.CustomerID} Unknown Order Status Event Triggered");
                    break;
            }
            Console.WriteLine("Customer: Order Status Event Triggered");
        }
    }

    class Program
    {

        static Task<string> readFile()
        {
            //random list generated by chatgpt
            return Task.Run(() =>
            {
            string path = "customerList.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                string txt = sr.ReadToEnd();
                return txt;
            }
            }
            );
        }

        static Task ParseFile(List<Customer> customers)
        {
            return Task.Run(async () =>
            {
                string txt = await readFile();
                string[] lines = txt.Split("\n"); //easily broken by empty lines in file...
                foreach (string line in lines)
                {
                    //DEBUG:
                    // Console.WriteLine(line);
                    string[] customerInfo = line.Split(",");
                    //DEBUG:
                    // Console.WriteLine($"Customer Info: {customerInfo[0]} {customerInfo[1]} {customerInfo[2]} {customerInfo[3]} {customerInfo[4]} {customerInfo[5]} {customerInfo[6]}");
                    Customer customer = new Customer();
                    customer.Name = customerInfo[0].Replace("Name: ", "");
                    customer.Address = customerInfo[1].Replace(" Address: ", "");
                    customer.City = customerInfo[2].Replace(" City: ", "");
                    customer.State = customerInfo[3].Replace(" State: ", "");
                    customer.CustomerID = customerInfo[4].Replace(" CustomerID: ", "");
                    customer.Email = customerInfo[5].Replace(" Email: ", "");
                    customer.Phone = customerInfo[6].Replace(" Phone: ", "");
                    customers.Add(customer);
                }
            }
            );
        }

        static void printCustomers(List<Customer> customers)
        {
            Console.WriteLine("Printing Customers...");
            foreach (Customer customer in customers)
            {
                Console.WriteLine("Name: " + customer.Name);
                Console.WriteLine("Address: " + customer.Address);
                Console.WriteLine("City: " + customer.City);
                Console.WriteLine("State: " + customer.State);
                Console.WriteLine("CustomerID: " + customer.CustomerID);
                Console.WriteLine("Email: " + customer.Email);
                Console.WriteLine("Phone: " + customer.Phone);
                Console.WriteLine();
            }
            Console.WriteLine("End of Customer list.");
        }
        
        static void printOrders(List<Order> orders)
        {
            Console.WriteLine("Printing Orders...");
            foreach (Order order in orders)
            {
                Console.WriteLine("Order ID: " + order.OrderID);
                Console.WriteLine("Customer: " + order.Customer.Name);
                Console.WriteLine("Order Date: " + order.OrderDate);
                Console.WriteLine("Ship Date: " + order.ShipDate);
                Console.WriteLine("Status: " + order.Status);
                Console.WriteLine();
            }
            Console.WriteLine("End of Order list.");
        }

        

        static async Task Main(string[] args)
        {
            string shipDate;
            int tempcounter;
            var customers = new List<Customer>();
            var orders = new List<Order>();
            var customerNotifications = new List<CustomerNotifications>();

            Task parseFile = ParseFile(customers);
            
            //Print out customer list...
            await parseFile;
            printCustomers(customers);

            //adding some fluff orders
            for (int i = 0; i < 10; i++)
            {
                orders.Add(new Order($"Order-a{i}", customers[5*i], DateTime.Now.AddDays(2).ToString()));
            }

            //Create an order for a customer
            while (true)
            {
                Console.WriteLine("Would you like to create an order for a customer? (Y/N): ");
                string response = Console.ReadLine().ToUpper();
                if (response == "N")
                {
                    break;
                }
                
                //Select customerID from list
                Console.WriteLine("Create an order for a customer, select Customer ID: ");
                tempcounter = 0;
                foreach (Customer customer in customers)
                {
                    tempcounter++;
                    Console.WriteLine($"{tempcounter}: {customer.CustomerID}");
                }
                int customerIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                //Create order ID
                Console.WriteLine("Enter Order ID: ");
                string orderID = Console.ReadLine();

                //Create Ship Date
                while (true)
                {
                    Console.WriteLine("Enter Ship Date (MM/DD/YYYY): ");
                    shipDate = Console.ReadLine();
                    if (DateTime.TryParse(shipDate, out DateTime result))
                    {
                        break;
                    }
                    else if (DateTime.Now.AddDays(1) > result)
                    {
                        Console.WriteLine("Not enough time to ship, try again.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Date Format, try again.");
                    }
                }
                
                //Create Order
                Order order = new Order(orderID, customers[customerIndex], shipDate);
                orders.Add(order);
            }

            //Print out order list...
            printOrders(orders);

            //wait for orders to be placed...
            await Task.Delay(500);

            //Place Order - placing every order
            foreach (Order order in orders)
            {
                customerNotifications.Add(new CustomerNotifications(order.Customer, order));
                await Order.PlaceOrder(order);
            }

            //wait for orders to be ready to ship...
            await Task.Delay(500);

            //Order Ready to Ship - lambda to ship every other order
            foreach (Order order in orders.Where((o, index) => index % 2 == 0))
            {
                await Order.OrderReadyToShip(order);
            }

            //wait for orders to be shipped...
            await Task.Delay(500);

            //Order Shipped - shipping the orders that were not shipped in the last step
            foreach (Order order in orders.Where((o, Index) => Index %2 != 0))
            {
                await Order.OrderShipped(order);
            }
            Console.WriteLine();

            Console.WriteLine("Daily business operations complete, printing reports...");

            Console.WriteLine("orders that are ready to ship: ");
            var readyToShipOrders = 
                                        from order in orders
                                        where order.Status == "Ready to Ship"
                                        select order;
            foreach (var order in readyToShipOrders)
            {
                Console.WriteLine($"Order ID: {order.OrderID}");
                Console.WriteLine($"Customer: {order.Customer.Name}");
                Console.WriteLine($"Order Date: {order.OrderDate}");
                Console.WriteLine($"Ship Date: {order.ShipDate}");
                Console.WriteLine($"Status: {order.Status}");
                Console.WriteLine();
            }
            Console.WriteLine("End of Ready to Ship Orders.");
            Console.WriteLine("Orders that have been shipped: ");
            var shippedOrders =
                                        from order in orders
                                        where order.Status == "Shipped"
                                        select order;
            foreach (var order in shippedOrders)
            {
                Console.WriteLine($"Order ID: {order.OrderID}");
                Console.WriteLine($"Customer: {order.Customer.Name}");
                Console.WriteLine($"Order Date: {order.OrderDate}");
                Console.WriteLine($"Ship Date: {order.ShipDate}");
                Console.WriteLine($"Status: {order.Status}");
                Console.WriteLine();
            }
            Console.WriteLine("End of Shipped Orders.");
        
        }
    }

}


