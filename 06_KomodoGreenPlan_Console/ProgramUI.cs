using _06_KomodoGreenPlan_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreenPlan_Console
{
    class ProgramUI
    {
        private Car_Repository _carRepo = new Car_Repository();

        //Start the app
        public void Run()
        {
            SeedCarsToList();
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
                    "1. Add a mew car\n" +
                    "2. View all cars\n" +
                    "3. View a car by the model\n" +
                    "4. View cars by type\n" +
                    "5. Update an existing car\n" +
                    "6. Delete a car\n" +
                    "7. Exit");

                //take in user's input and act accordingly
                switch (Console.ReadLine())
                {
                    case "1":
                        //CreateNewCar
                        CreateNewCar();
                        break;
                    case "2":
                        //ViewAllCars
                        DisplayAllCars();
                        break;
                    case "3":
                        //ViewCarByModel
                        DisplayCarByModel();
                        break;
                    case "4":
                        //View Cars by type
                        ViewCarsByType();
                        break;
                    case "5":
                        //UpdateExistingCar
                        UpdateExistingCar();
                        break;
                    case "6":
                        //DeleteExistingCar
                        DeleteExistingCar();
                        break;
                    case "7":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option.");
                        break;
                }
                Console.WriteLine("\nPlease press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //Create New Car
        private void CreateNewCar()
        {
            Console.Clear();
            Car newCar = new Car();

            //Type
            Console.WriteLine("Enter the number of the Type of Car\n" +
                "1. Gas\n" +
                "2. Electric\n" +
                "3. Hybrid");

            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newCar.TypeOfCar = (CarType)typeAsInt;

            _carRepo.AddCarToList(newCar);

            //Make
            Console.WriteLine("Enter the Make of the car.");
            newCar.Make = Console.ReadLine();

            //Model
            Console.WriteLine("Enter the Model of the car.");
            newCar.Model = Console.ReadLine();

            //Color
            Console.WriteLine("Enter the Color of the car.");
            newCar.Color = Console.ReadLine();

            //MPG
            Console.WriteLine("Enter the MPG of the car.");
            string mpgAsString = Console.ReadLine();
            newCar.MPG = double.Parse(mpgAsString);

            _carRepo.AddCarToList(newCar);
        }

        //ViewAllCars
        private void DisplayAllCars()
        {
            Console.Clear();
            List<Car> listOfCars = _carRepo.GetAllCars();

            Console.WriteLine("Make   Model\n");
            foreach (Car car in listOfCars)
            {
                Console.WriteLine($"{car.Make} {car.Model}");
            }
        }

        //View Car by Model
        private void DisplayCarByModel()
        {
            Console.Clear();
            //ask for model
            Console.WriteLine("Enter the model of the car you'd like to view");

            //Take input
            string model = Console.ReadLine();

            //Find Content
            Car car = _carRepo.GetCarByModel(model);

            //Display if it isn't null
            if(car != null)
            {
                Console.WriteLine($"Type: {car.TypeOfCar}\n" +
                    $"Make: {car.Make}\n" +
                    $"Model: {car.Model}\n" +
                    $"Color: {car.Color}\n" +
                    $"MPG: {car.MPG}\n");
            }
            else
            {
                Console.WriteLine("No cars found of that Model");
            }
        }

        //View Cars by type
        private void ViewCarsByType()
        {
            Console.Clear();

            Console.WriteLine("Enter the number of the Type of Car you'd like to view\n" +
                "1. Gas\n" +
                "2. Electric\n" +
                "3. Hybrid");

            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            CarType carType = (CarType)typeAsInt;

            List<Car> listOfCars = _carRepo.DisplayCarsByType(carType);

            Console.WriteLine($"\nAll {carType} cars:\n");

            foreach (Car car in listOfCars)
            {
                if(car.TypeOfCar == carType)
                {
                    Console.WriteLine($"Make: {car.Make}\n" +
                        $"Model: {car.Model}\n" +
                        $"Color: {car.Color}\n" +
                        $"MPG: {car.MPG}\n");
                }
                if(listOfCars.Count < 1)
                {
                    Console.WriteLine("There are no Cars of that type to display.");
                }
            }
        }

        private void UpdateExistingCar()
        {
            //Display all to choose from
            DisplayAllCars();

            //Ask for model of car to update
            Console.WriteLine("Enter the model of the car you'd like to update");

            //Get input
            string oldModel = Console.ReadLine();

            //Build new object
            Car newCar = new Car();

            //Type
            Console.WriteLine("Enter the number of the Type of Car\n" +
                "1. Gas\n" +
                "2. Electric\n" +
                "3. Hybrid");

            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newCar.TypeOfCar = (CarType)typeAsInt;

            _carRepo.AddCarToList(newCar);

            //Make
            Console.WriteLine("Enter the Make of the car.");
            newCar.Make = Console.ReadLine();

            //Model
            Console.WriteLine("Enter the Model of the car.");
            newCar.Model = Console.ReadLine();

            //Color
            Console.WriteLine("Enter the Color of the car.");
            newCar.Color = Console.ReadLine();

            //MPG
            Console.WriteLine("Enter the MPG of the car.");
            string mpgAsString = Console.ReadLine();
            newCar.MPG = double.Parse(mpgAsString);

            //Verify the update worked
            bool wasUpdated = _carRepo.UpdateExistingCar(oldModel, newCar);

            if (wasUpdated)
            {
                Console.WriteLine("The Car was successfully updated.");
            }
            else
            {
                Console.WriteLine("The Car could not be updated.");
            }
        }

        //Delete Existing Car
        private void DeleteExistingCar()
        {
            //Display All Cars to choose from
            DisplayAllCars();

            //Get model
            Console.WriteLine("\nEnter the model of the Car you'd like to delete");

            string input = Console.ReadLine();

            //Call delete method
            bool wasDeleted = _carRepo.RemoveCarFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The Car was successfully deleted");
            }
            else
            {
                Console.WriteLine("The car could not be deleted");
            }
        }

        //Seed Method
        private void SeedCarsToList()
        {
            Car gasCar = new Car(CarType.Gas, "Honda", "Accord", "Silver", 32);
            Car electricCar = new Car(CarType.Electric, "Tesla", "T1", "White", 500);
            Car hybridCar = new Car(CarType.Hybrid, "Toyota", "Prius", "Blue", 45);

            _carRepo.AddCarToList(gasCar);
            _carRepo.AddCarToList(electricCar);
            _carRepo.AddCarToList(hybridCar);
        }
    }
}
