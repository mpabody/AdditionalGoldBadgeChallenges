using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoOutings_Repository
{
    public enum OutingType
    {
        Golf = 1,
        Bowling,
        Amusment_Park,
        Concert
    }
    public class Outing
    {
        public OutingType TypeOfOuting { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime Date { get; set; }
        public double CostPerPerson { get; set; }
        public double TotalCostOfOuting
        {
            get
            {
                double totalCost = CostPerPerson * NumberOfPeople;

                return totalCost;
            }
        }

        public Outing() { }

        public Outing(OutingType outingType, int numberOfPeople, DateTime date, double costPerPerson)
        {
            TypeOfOuting = outingType;
            NumberOfPeople = numberOfPeople;
            Date = date;
            CostPerPerson = costPerPerson;
        }
    }
}
