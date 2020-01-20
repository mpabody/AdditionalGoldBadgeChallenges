using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_KomodoBarbecue_Repository
{
    public class Barbecue
    {
        public DateTime Date { get; set; }
        public string Venue { get; set; }
        public int MeatBurgersSold { get; set; }
        public int VeggieBurgersSold { get; set; }
        public int HotDogsSold { get; set; }
        public int IceCreamsSold { get; set; }
        public MeatBurger MeatBurger { get; set; } = new MeatBurger();
        public VeggieBurger VeggieBurger { get; set; }
        public HotDog HotDog { get; set; }
        public IceCream IceCream { get; set; }
        public int IceCreamBoothTicketsTaken
        {
            get
            {
                return IceCreamsSold;
            }
        }
        public int BurgerBoothTicketsTaken
        {
            get
            {
                int totalTickets = MeatBurgersSold + VeggieBurgersSold + HotDogsSold;
                return totalTickets;
            }
        }
        public int TotalTicketsTaken
        {
            get
            {
                int totalTickets = IceCreamBoothTicketsTaken + BurgerBoothTicketsTaken;
                return totalTickets;
            }
        }
        public double TotalMiscCost
        {
            get
            {
                double totalMiscCost = (MeatBurgersSold * MeatBurger.MiscCost) + (VeggieBurgersSold * VeggieBurger.MiscCost) + (HotDogsSold * HotDog.MiscCost) + (IceCreamsSold * IceCream.MiscCost);
                return totalMiscCost;
            }
        }
        public double TotalBarbecueCost
        {
            get
            {
                double totalCost = (MeatBurgersSold * MeatBurger.Cost) + (VeggieBurgersSold * VeggieBurger.Cost) + (HotDogsSold * HotDog.Cost) + (IceCreamsSold * IceCream.Cost) + TotalMiscCost;
                return totalCost;
            }
        }

        public Barbecue() 
        {
            VeggieBurger = new VeggieBurger();
            HotDog = new HotDog();
            IceCream = new IceCream();
        }

        public Barbecue(DateTime date, string venue, int meatBurgersSold, int veggieBurgersSold, int hotDogsSold, int iceCreamsSold)
        {
            Date = date;
            Venue = venue;
            MeatBurgersSold = meatBurgersSold;
            VeggieBurgersSold = veggieBurgersSold;
            HotDogsSold = hotDogsSold;
            IceCreamsSold = iceCreamsSold;
            VeggieBurger = new VeggieBurger();
            HotDog = new HotDog();
            IceCream = new IceCream();
        }
    }

    public class MeatBurger
    {
        public double Cost => 4.0;
        public double MiscCost => 1.0;
    }

    public class VeggieBurger
    {
        public double Cost => 5.0;
        public double MiscCost => 1.0;
    }

    public class HotDog
    {
        public double Cost => 3.0;
        public double MiscCost => .50;
    }

    public class IceCream
    {
        public double Cost => 2.5;
        public double MiscCost => .50;
    }
}
