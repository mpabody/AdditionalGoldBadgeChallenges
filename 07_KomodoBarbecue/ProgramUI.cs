using _07_KomodoBarbecue_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_KomodoBarbecue
{
    class ProgramUI
    {
        private Barbecue_Repository _barbecueRepo = new Barbecue_Repository();

        //Start/Run the app
        public void Run()
        {
            SeedBarbecueList();
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
                    "1. Create a new Barbecue\n" +
                    "2. View all Barbecues\n" +
                    "3. View a Barbecue by Venue\n" +
                    "4. Update Existing Barbecue\n" +
                    "5. Delete Existing Barbecue\n" +
                    "6. Exit");

                //Take user input and act accordingly
                switch (Console.ReadLine())
                {
                    case "1":
                        //Create New Barbecue
                        CreateNewBarbecue();
                        break;
                    case "2":
                        //View All Barbecues
                        DisplayAllBarbecues();
                        break;
                    case "3":
                        //View Barbecue By Venue
                        DisplayBarbecueByVenue();
                        break;
                    case "4":
                        //Update Existing Barbecue
                        UpdateExistingBarbecue();
                        break;
                    case "5":
                        //Delete Existing Barbecue
                        DeleteExistingBarbecue();
                        break;
                    case "6":
                        //Exit
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }

                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Create new Barbecue
        private void CreateNewBarbecue()
        {
            Console.Clear();
            Barbecue newBarbecue = new Barbecue();

            //Date
            Console.WriteLine("Enter the date of the barbecue. (YYYY, MM, DD):");
            string dateAsString = Console.ReadLine();
            DateTime dateAsDate = Convert.ToDateTime(dateAsString);
            newBarbecue.Date = dateAsDate;

            //Venue
            Console.WriteLine("Enter the venue of the barbecue");
            newBarbecue.Venue = Console.ReadLine();

            //Meat Burgers Sold
            Console.WriteLine("How man Meat Burgers were sold at this barbecue?");
            string meatAsString = Console.ReadLine();
            newBarbecue.MeatBurgersSold = int.Parse(meatAsString);

            //Vegie Burgers Sold
            Console.WriteLine("How man Veggie Burgers were sold at this barbecue?");
            string veggieAsString = Console.ReadLine();
            newBarbecue.VeggieBurgersSold = int.Parse(veggieAsString);

            //Hot Dogs Sold
            Console.WriteLine("How many Hot Dogs were sold at the barbecue?");
            string dogsAsString = Console.ReadLine();
            newBarbecue.HotDogsSold = int.Parse(dogsAsString);

            //Ice Creams Sold
            Console.WriteLine("How many Ice Creams were sold at the barbecue?");
            string iceAsString = Console.ReadLine();
            newBarbecue.IceCreamsSold = int.Parse(iceAsString);

            _barbecueRepo.AddBarbecueToList(newBarbecue);
        }

        //View All Barbecues
        private void DisplayAllBarbecues()
        {
            Console.Clear();
            List<Barbecue> listOfBarbecues = _barbecueRepo.GetBarbecueList();

            foreach (Barbecue barbecue in listOfBarbecues)
            {
                Console.WriteLine($"Date: {barbecue.Date}\n" +
                    $"Venue: {barbecue.Venue}\n" +
                    $"Total Cost: {barbecue.TotalBarbecueCost}");
            }
        }

        //View Barbecue By Venue
        private void DisplayBarbecueByVenue()
        {
            Console.Clear();
            DisplayAllBarbecues();
            Console.WriteLine("Enter Venue of the Barbecue you'd like to view");

            string venue = Console.ReadLine();

            Barbecue barbecue = _barbecueRepo.GetBarbecueByVenue(venue);

            if(barbecue != null)
            {
                Console.WriteLine($"Date: {barbecue.Date}\n" +
                    $"Venue: {barbecue.Venue}\n" +
                    $"Meat Burgers Sold: {barbecue.MeatBurgersSold}\n" +
                    $"Veggie Burgers Sold: {barbecue.VeggieBurgersSold}\n" +
                    $"Hot Dogs Sold: {barbecue.HotDogsSold}\n" +
                    $"Ice Creams Sold: {barbecue.HotDogsSold}\n\n" +
                    $"Tickets collected from Burger booth: {barbecue.BurgerBoothTicketsTaken}\n" +
                    $"Tickets collected from Ice Cream booth: {barbecue.IceCreamBoothTicketsTaken}\n\n" +
                    $"Miscelaneous Cost for the Barbecue: {barbecue.TotalMiscCost}\n" +
                    $"Total Cost of the Barbecue: {barbecue.TotalMiscCost}");
            }
            else
            {
                Console.WriteLine("No Barbecues match that date");
            }
        }

        //Update Existing Barbecue
        private void UpdateExistingBarbecue()
        {
            DisplayAllBarbecues();

            Console.WriteLine("Enter the venue of the Barbecue you'd like to update");

            string oldVenue = Console.ReadLine();

            Barbecue newBarbecue = new Barbecue();

            //Date
            Console.WriteLine("Enter the date of the barbecue. (YYYY, MM, DD):");
            string dateAsString = Console.ReadLine();
            DateTime dateAsDate = Convert.ToDateTime(dateAsString);
            newBarbecue.Date = dateAsDate;

            //Venue
            Console.WriteLine("Enter the venue of the barbecue");
            newBarbecue.Venue = Console.ReadLine();

            //Meat Burgers Sold
            Console.WriteLine("How man Meat Burgers were sold at this barbecue?");
            string meatAsString = Console.ReadLine();
            newBarbecue.MeatBurgersSold = int.Parse(meatAsString);

            //Vegie Burgers Sold
            Console.WriteLine("How man Veggie Burgers were sold at this barbecue?");
            string veggieAsString = Console.ReadLine();
            newBarbecue.VeggieBurgersSold = int.Parse(veggieAsString);

            //Hot Dogs Sold
            Console.WriteLine("How many Hot Dogs were sold at the barbecue?");
            string dogsAsString = Console.ReadLine();
            newBarbecue.HotDogsSold = int.Parse(dogsAsString);

            //Ice Creams Sold
            Console.WriteLine("How many Ice Creams were sold at the barbecue?");
            string iceAsString = Console.ReadLine();
            newBarbecue.IceCreamsSold = int.Parse(iceAsString);

            //Verify that it worked
            bool wasUpdated = _barbecueRepo.UpdateExistingBarbecue(oldVenue, newBarbecue);

            if (wasUpdated)
            {
                Console.WriteLine("The Barbecue was successfully updated");
            }
            else
            {
                Console.WriteLine("The Barbecue could not be updated");
            }
        }

        //Delete Existing Content
        private void DeleteExistingBarbecue()
        {
            DisplayAllBarbecues();

            Console.WriteLine("\nEnter the venue of the Barbecue you'd like to delete");

            string venue = Console.ReadLine();

            bool wasDeleted = _barbecueRepo.RemoveBarbecueFromList(venue);

            if (wasDeleted)
            {
                Console.WriteLine("The Barbecue was successfully deleted");
            }
            else
            {
                Console.WriteLine("The Barbecue could not be deleted");
            }
        }

        //Seed Method
        private void SeedBarbecueList()
        {
            DateTime dateOne = new DateTime(2020, 04, 11);
            Barbecue park = new Barbecue(dateOne, "park", 50, 20, 30, 100);

            DateTime dateTwo = new DateTime(2020, 05, 01);
            Barbecue conferenceRoom = new Barbecue(dateTwo, "Conference Room", 20, 10, 15, 50);

            DateTime dateThree = new DateTime(2020, 06, 10);
            Barbecue street = new Barbecue(dateThree, "Street", 20, 20, 20, 60);

            DateTime dateFour = new DateTime(2020, 07, 04);
            Barbecue yard = new Barbecue(dateFour, "Yard", 40, 40, 40, 120);

            _barbecueRepo.AddBarbecueToList(park);
            _barbecueRepo.AddBarbecueToList(conferenceRoom);
            _barbecueRepo.AddBarbecueToList(street);
            _barbecueRepo.AddBarbecueToList(yard);
        }
    }
}
