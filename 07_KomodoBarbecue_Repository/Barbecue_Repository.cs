using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_KomodoBarbecue_Repository
{
    public class Barbecue_Repository
    {
        private List<Barbecue> _listOfBarbecues = new List<Barbecue>();

        //Create new Barbecue
        public void AddBarbecueToList(Barbecue barbecue)
        {
            _listOfBarbecues.Add(barbecue);
        }

        //Read
        public List<Barbecue> GetBarbecueList()
        {
            return _listOfBarbecues;
        }

        //Update
        public bool UpdateExistingBarbecue(string originalVenue, Barbecue newBarbecue)
        {
            //target correct barbecue
            Barbecue oldBarbecue = GetBarbecueByVenue(originalVenue);

            //Update barbecue
            if(oldBarbecue != null)
            {
                oldBarbecue.Date = newBarbecue.Date;
                oldBarbecue.Venue = newBarbecue.Venue;
                oldBarbecue.MeatBurgersSold = newBarbecue.MeatBurgersSold;
                oldBarbecue.VeggieBurgersSold = newBarbecue.VeggieBurgersSold;
                oldBarbecue.HotDogsSold = newBarbecue.HotDogsSold;
                oldBarbecue.IceCreamsSold = newBarbecue.IceCreamsSold;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveBarbecueFromList(string venue)
        {
            Barbecue barbecue = GetBarbecueByVenue(venue);

            if(barbecue == null)
            {
                return false;
            }

            int initialCount = _listOfBarbecues.Count;
            _listOfBarbecues.Remove(barbecue);

            if(initialCount > _listOfBarbecues.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper
        public Barbecue GetBarbecueByVenue (string venue)
        {
            foreach(Barbecue barbecue in _listOfBarbecues)
            {
                if (barbecue.Venue.ToLower() == venue.ToLower())
                {
                    return barbecue;
                }
            }

            return null;
        }
    }
}
