using KomodoGreet_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoGreet_Console
{
    class ProgramUI
    {
        private Customer_Repository _customerRepo = new Customer_Repository();

        //Start the app
        public void Run()
        {
            SeedCustomerList();
            Menu();
        }

        //Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display options
                Console.WriteLine("Select a menu option:\n" +
                    "1. Add a Customer to the list\n" +
                    "2. View all existing customers\n" +
                    "3. View customer by last name\n" +
                    "4. Update an existing customer\n" +
                    "5. Delete an existing Customer\n" +
                    "6. Exit");

                //Take user input and act accordingly
                switch (Console.ReadLine())
                {
                    case "1":
                        //Create New Customer
                        CreateNewCustomer();
                        break;
                    case "2":
                        //View All Customers
                        DisplayAllCustomers();
                        break;
                    case "3":
                        //Display Customer By Last Name
                        DisplayCustomerByLastName();
                        break;
                    case "4":
                        //Update Existing Customer
                        UpdateExistingCustomer();
                        break;
                    case "5":
                        //Delete Existing Customer
                        DeleteExistingCustomer();
                        break;
                    case "6":
                        //Exit
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Create New Customer
        private void CreateNewCustomer()
        {
            Console.Clear();
            Customer newCustomer = new Customer();

            //FistName
            Console.WriteLine("What is the first name of this customer?");
            newCustomer.FirstName = Console.ReadLine();

            //LastName
            Console.WriteLine("What is the last name of this customer?");
            newCustomer.LastName = Console.ReadLine();

            //Type of Customer
            Console.WriteLine("Enter the number of the Customer Type.\n" +
                "1. Current\n" +
                "2. Past\n" +
                "3. Potential");

            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newCustomer.TypeOfCustomer = (CustomerType)typeAsInt;

            _customerRepo.AddCustomerToList(newCustomer);
        }

        //View all existing Customers
        private void DisplayAllCustomers()
        {
            Console.Clear();
            List<Customer> listOfCustomers = _customerRepo.GetCustomerList();

            foreach (Customer customer in listOfCustomers)
            {
                Console.WriteLine($"Fist Name: {customer.FirstName}\n" +
                    $"Last Name: {customer.LastName}\n");
            }
        }

        //View Existing Customer By Last Name
        private void DisplayCustomerByLastName()
        {
            Console.Clear();

            //Ask for last name
            DisplayAllCustomers();
            Console.WriteLine("Enter the last name of the customer you'd like to view.");

            //Get input and find content
            Customer customer = _customerRepo.GetCustomerByLastName(Console.ReadLine().ToLower());

            //Display Customer if it isn't null
            if (customer != null)
            {
                Console.WriteLine($"Fist Name: {customer.FirstName}\n" +
                    $"Last Name: {customer.LastName}\n" +
                    $"Type of Customer: {customer.TypeOfCustomer}\n" +
                    $"Email that will be sent: {customer.Email}");
            }
            else
            {
                Console.WriteLine("There are no customers by that last name.");
            }
        }

        //Update Existing Customer
        private void UpdateExistingCustomer()
        {
            //Display all customer
            DisplayAllCustomers();

            //Ask for last name of customer
            Console.WriteLine("Enter the last name of the customer you'd like to update.");

            //catch last name
            string oldLastName = Console.ReadLine();

            //Build new object
            Customer newCustomer = new Customer();

            //FirstName
            Console.WriteLine("Enter the first name of the customer");
            newCustomer.FirstName = Console.ReadLine();

            //Last Name
            Console.WriteLine("Enter the last name of the customer");
            newCustomer.LastName = Console.ReadLine();

            //Customer Type
            Console.WriteLine("Enter the number of the Customer Type.\n" +
                "1. Current\n" +
                "2. Past\n" +
                "3. Potential");

            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newCustomer.TypeOfCustomer = (CustomerType)typeAsInt;

            //Verify the update worked
            bool wasUpdated = _customerRepo.UpdateExistingCustomer(oldLastName, newCustomer);

            if (wasUpdated)
            {
                Console.WriteLine("Customer was successfully updated");
            }
            else
            {
                Console.WriteLine("Customer could not be updated");
            }
        }

        //Delete Existing Customer
        private void DeleteExistingCustomer()
        {
            DisplayAllCustomers();

            //Get Last Name of customer they want to delete
            Console.WriteLine("\nEnter the last name of the customer you want to delete");

            string input = Console.ReadLine();

            //Call delete method
            bool wasDeleted = _customerRepo.RemoveCustomerFromList(input);

            //If content was deleted, say so
            //Otherwise state that it couldn't be
            if (wasDeleted)
            {
                Console.WriteLine("The customer was successfully deleted");
            }
            else
            {
                Console.WriteLine("Customer could not be deleted");
            }
        }

        //Seed method
        private void SeedCustomerList()
        {
            Customer michael = new Customer("Michael", "Pabody", CustomerType.Current);
            Customer trevor = new Customer("Trevor", "Babcock", CustomerType.Past);
            Customer james = new Customer("James", "Dickinson", CustomerType.Potential);

            _customerRepo.AddCustomerToList(michael);
            _customerRepo.AddCustomerToList(trevor);
            _customerRepo.AddCustomerToList(james);
        }
    }
}
