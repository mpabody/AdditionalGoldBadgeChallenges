using _01_KomodoOutings_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Outings_Console
{
    public class ProgramUI
    {
        private Outing_Repository _outingRepo = new Outing_Repository();
        public void Run()
        {
            SeedOutings();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select A Menu Option\n" +
                    "1. Add a new outing\n" +
                    "2. Display all outings\n" +
                    "3. Display outings by Type\n" +
                    "4. Exit");

                //Take in input and act accordingly
                switch (Console.ReadLine())
                {
                    case "1":
                        //Create New Outing
                        CreateNewOuting();
                        break;
                    case "2":
                        //Display All Outings
                        DisplayAllOutings();
                        break;
                    case "3":
                        //Display Outings By Type
                        DisplayOutingsByType();
                        break;
                    case "4":
                        // Exit
                        Console.WriteLine("Later!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Create New Outing
        private void CreateNewOuting()
        {
            Console.Clear();
            Outing newOuting = new Outing();

            // Type Of Outing
            Console.WriteLine("What type of outing do you want to create? (please enter a number)\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusment Park\n" +
                "4. Concert");

            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newOuting.TypeOfOuting = (OutingType)typeAsInt;

            //Number of people
            Console.WriteLine("How many people attended/will attend this outing?");
            newOuting.NumberOfPeople = int.Parse(Console.ReadLine());

            //Date
            Console.WriteLine("Enter the date of the outing. (YYYY, MM, DD):");
            string dateAsString = Console.ReadLine();
            DateTime dateAsDate = Convert.ToDateTime(dateAsString);
            newOuting.Date = dateAsDate;

            //Cost per person
            Console.WriteLine("What is the cost per person of this outing?");
            newOuting.CostPerPerson = double.Parse(Console.ReadLine());

            _outingRepo.AddOutingToList(newOuting);
        }

        //Display All Outings
        private void DisplayAllOutings()
        {
            Console.Clear();
            List<Outing> listOfOutings = _outingRepo.DisplayAllOutings();

            foreach (Outing outing in listOfOutings)
            {
                Console.WriteLine($"Date: {outing.Date}\n" +
                    $"Type Of Outing: {outing.TypeOfOuting}\n" +
                    $"Number Of People: {outing.NumberOfPeople}\n" +
                    $"Cost Per Person: ${outing.CostPerPerson}\n" +
                    $"Total Cost of this Event: ${outing.TotalCostOfOuting}\n\n");
            }
        }

        //Display Outings By Type w/ total $ for that type
        private void DisplayOutingsByType()
        {
            Console.Clear();

            Console.WriteLine("What type of outing do you want to view? (please enter a number)\n\n" +
                "1. Golf\n" +
                "2. Bowling\n" +
                "3. Amusment Park\n" +
                "4. Concert");

            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            OutingType outingType = (OutingType)typeAsInt;

            List<Outing> listOfOutings = _outingRepo.DisplayOutingByType(outingType);
            double totalForType = 0;

            foreach (Outing outing in listOfOutings)
            {
                if (outing.TypeOfOuting == outingType)
                {
                    Console.WriteLine($"Date: {outing.Date}\n" +
                        $"Type Of Outing: {outing.TypeOfOuting}\n" +
                        $"Number Of People: {outing.NumberOfPeople}\n" +
                        $"Cost Per Person: ${outing.CostPerPerson}\n" +
                        $"Total Cost of this Event: ${outing.TotalCostOfOuting}\n\n");
                }
                if(listOfOutings.Count < 1)
                {
                    Console.WriteLine("There are no outings of that type to display");
                }

                 totalForType += outing.TotalCostOfOuting;
                Console.WriteLine($"The total for this type of outing is ${totalForType}");
            }
        }

        //Seed content
        private void SeedOutings()
        {
            DateTime golfDate = new DateTime(2020, 01, 01);
            Outing golf = new Outing(OutingType.Golf, 10, golfDate, 50.00);

            DateTime bowlingDate = new DateTime(2020, 01, 02);
            Outing bowling = new Outing(OutingType.Bowling, 20, bowlingDate, 25.50);

            DateTime amusmentParkDate = new DateTime(2020, 01, 03);
            Outing amusmentPark = new Outing(OutingType.Amusment_Park, 15, amusmentParkDate, 20.00);

            DateTime concertDate = new DateTime(2020, 01, 04);
            Outing concert = new Outing(OutingType.Concert, 10, concertDate, 40.00);

            _outingRepo.AddOutingToList(golf);
            _outingRepo.AddOutingToList(bowling);
            _outingRepo.AddOutingToList(amusmentPark);
            _outingRepo.AddOutingToList(concert);
        }
    }
}
