using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreenPlan_Repository
{
    public enum CarType
    {
        Gas = 1,
        Electric,
        Hybrid
    }

    //POCO
    public class Car
    {
        public CarType TypeOfCar { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double MPG { get; set; }

        public Car() { }

        public Car(CarType typeOfCar, string make, string model, string color, double mpg)
        {
            TypeOfCar = typeOfCar;
            Make = make;
            Model = model;
            Color = color;
            MPG = mpg;
        }
    }
}
