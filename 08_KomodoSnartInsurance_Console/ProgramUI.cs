using _08_KomodoSmartInsurance_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_KomodoSmartInsurance_Console
{
    class ProgramUI
    {
        private Customer_Repository _customerRepo = new Customer_Repository();

        //Start/Run the app
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
                //Display options to user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create a new Customer\n" +
                    "2. View All Customers\n" +
                    "3. View Customer By Name\n" +
                    "4. Update Existing Customer\n" +
                    "5. Delete Existing Customer\n" +
                    "6. Exit");

                //Get user input and evaluate
                switch (Console.ReadLine())
                {
                    case "1":
                        //Create new customer
                        CreateNewCustomer();
                        break;
                    case "2":
                        //View All Customers
                        DisplayAllCustomers();
                        break;
                    case "3":
                        //View Customer By Name
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
                        Console.WriteLine("Please select a valid number");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Create new Customer
        private void CreateNewCustomer()
        {
            Console.Clear();
            Customer newCustomer = new Customer();

            //First Name
            Console.WriteLine("Enter the first name of the customer");
            newCustomer.FirstName = Console.ReadLine();

            //Last Name
            Console.WriteLine("Enter the last name of the customer");
            newCustomer.LastName = Console.ReadLine();

            //Follow Speed Limit
            Console.WriteLine("How skilled is this customer at following the speed limit? (enter a number between 1(worst) and 10(best))");
            string sppedAsString = Console.ReadLine();
            newCustomer.FollowSpeedLimitSkill = int.Parse(sppedAsString);

            //Stay In Lane
            Console.WriteLine("How skilled is this customer at staying in their lane? (enter a number between 1(worst) and 10(best))");
            string laneAsString = Console.ReadLine();
            newCustomer.StayInLaneSkill = int.Parse(laneAsString);

            //Full Stop
            Console.WriteLine("How skilled is this customer at coming to a full stop at stop signs? (enter a number between 1(worst) and 10(best))");
            string stopAsString = Console.ReadLine();
            newCustomer.FullStopSkill = int.Parse(stopAsString);

            //Following Distance
            Console.WriteLine("How skilled is this customer at leaving the proper following distance? (enter a number between 1(worst) and 10(best))");
            string distanceAsString = Console.ReadLine();
            newCustomer.FollowingDistanceSkill = int.Parse(distanceAsString);

            _customerRepo.AddCustomerToList(newCustomer);

        }

        //View All Current Customers
        private void DisplayAllCustomers()
        {
            Console.Clear();
            List<Customer> listOfCustomers = _customerRepo.GetCustomerList();

            foreach (Customer customer in listOfCustomers)
            {
                Console.WriteLine($"Name: {customer.FullName}\n" +
                    $"Premium: {customer.Premium}");
            }
        }

        //View existing Customers by Name
        private void DisplayCustomerByLastName()
        {
            Console.Clear();
            DisplayAllCustomers();
            Console.WriteLine("Enter the last name of the customer you'd like to view");

            //get input and find content
            string lastName = Console.ReadLine();

            Customer customer = _customerRepo.GetCustomerByLastName(lastName);

            //Display info it customer exists
            if (customer != null)
            {
                Console.WriteLine($"Name: {customer.FullName}\n" +
                    $"Follow the speed limit skill: {customer.FollowSpeedLimitSkill}\n" +
                    $"Stay in their lane skill: {customer.StayInLaneSkill}\n" +
                    $"Full stop at stop sign skill: {customer.FullStopSkill}\n" +
                    $"Following Distance Skill: {customer.FollowingDistanceSkill}");
            }
            else
            {
                Console.WriteLine("No Customer exists by that name");
            }
        }

        //Update Existing Customer
        public void UpdateExistingCustomer()
        {
            //Display all custoemrs
            DisplayAllCustomers();

            //target correct custoemr
            Console.WriteLine("Enter the last name of the customer you want to update");
            string oldLastName = Console.ReadLine();

            //Build New Object
            Customer newCustomer = new Customer();

            //First Name
            Console.WriteLine("Enter the first name of the customer");
            newCustomer.FirstName = Console.ReadLine();

            //Last Name
            Console.WriteLine("Enter the last name of the customer");
            newCustomer.LastName = Console.ReadLine();

            //Follow Speed Limit
            Console.WriteLine("How skilled is this customer at following the speed limit? (enter a number between 1(worst) and 10(best))");
            string sppedAsString = Console.ReadLine();
            newCustomer.FollowSpeedLimitSkill = int.Parse(sppedAsString);

            //Stay In Lane
            Console.WriteLine("How skilled is this customer at staying in their lane? (enter a number between 1(worst) and 10(best))");
            string laneAsString = Console.ReadLine();
            newCustomer.StayInLaneSkill = int.Parse(laneAsString);

            //Full Stop
            Console.WriteLine("How skilled is this customer at coming to a full stop at stop signs? (enter a number between 1(worst) and 10(best))");
            string stopAsString = Console.ReadLine();
            newCustomer.FullStopSkill = int.Parse(stopAsString);

            //Following Distance
            Console.WriteLine("How skilled is this customer at leaving the proper following distance? (enter a number between 1(worst) and 10(best))");
            string distanceAsString = Console.ReadLine();
            newCustomer.FollowingDistanceSkill = int.Parse(distanceAsString);

            // Verify that the update worked
            bool wasUpdated = _customerRepo.UpdateExistingCustomer(oldLastName, newCustomer);

            if (wasUpdated)
            {
                Console.WriteLine("The customer was successfully updated");
            }
            else
            {
                Console.WriteLine("Could not update this customer");
            }
        }

        //Delete Existing Customer
        private void DeleteExistingCustomer()
        {
            DisplayAllCustomers();

            //get name of customer to delete
            Console.WriteLine("\nEnter the last name of the customer you want to delete");

            string input = Console.ReadLine();

            //delete method
            bool wasDeleted = _customerRepo.RemoveCustomerFromList(input);

            //let user know if customer was deleted
            if (wasDeleted)
            {
                Console.WriteLine("The customer was deleted");
            }
            else
            {
                Console.WriteLine("The customer could not be deleted");
            }
        }

        //seed method
        private void SeedCustomerList()
        {
            Customer firstCustomer = new Customer("Michael", "Pabody", 3, 10, 8, 5);
            Customer secondCustomer = new Customer("Anna", "Holt", 8, 8, 9, 9);
            Customer thirdCustomer = new Customer("Laura", "Ryan", 2, 1, 2, 2);

            _customerRepo.AddCustomerToList(firstCustomer);
            _customerRepo.AddCustomerToList(secondCustomer);
            _customerRepo.AddCustomerToList(thirdCustomer);
        }
    }
}
