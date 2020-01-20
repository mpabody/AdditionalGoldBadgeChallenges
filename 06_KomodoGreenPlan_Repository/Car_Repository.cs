using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreenPlan_Repository
{
    public class Car_Repository
    {
        private List<Car> _listOfCars = new List<Car>();

        //Create
        public void AddCarToList(Car car)
        {
            _listOfCars.Add(car);
        }

        //Read
        public List<Car> GetAllCars()
        {
            return _listOfCars;
        }

        //Display Cars by Type
        public List<Car> DisplayCarsByType(CarType carType)
        {
            List<Car> listOfCars = new List<Car>();

            foreach (Car car in _listOfCars)
            {
                if(car.TypeOfCar == carType)
                {
                    listOfCars.Add(car);
                }
            }
            return listOfCars;
        }

        //Update
        public bool UpdateExistingCar(string originalModel, Car newCar)
        {
            //Target specific car -- could build in more exact targeting (ID?)
            Car oldCar = GetCarByModel(originalModel);

            //Update Car
            if (oldCar != null)
            {
                oldCar.TypeOfCar = newCar.TypeOfCar;
                oldCar.Make = newCar.Make;
                oldCar.Model = newCar.Model;
                oldCar.Color = newCar.Color;
                oldCar.MPG = newCar.MPG;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveCarFromList(string model)
        {
            Car car = GetCarByModel(model);

            if(car == null)
            {
                return false;
            }

            int initialCount = _listOfCars.Count;
            _listOfCars.Remove(car);

            if (initialCount > _listOfCars.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper
        public Car GetCarByModel(string model)
        {
            foreach(Car car in _listOfCars)
            {
                if (car.Model.ToLower() == model.ToLower())
                {
                    return car;
                }
            }
            return null;
        }
    }
}
