using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoOutings_Repository
{
    public class Outing_Repository
    {
        private readonly List<Outing> _outings = new List<Outing>();

        //Create New Outing
        public void AddOutingToList(Outing outing)
        {
            _outings.Add(outing);
        }

        //Display All Outings
        public List<Outing> DisplayAllOutings()
        {
            return _outings;
        }

        //Display Outings By Type
        public List<Outing> DisplayOutingByType(OutingType outingType)
        {
            List<Outing> listOfOutings = new List<Outing>();

            foreach (Outing outing in _outings)
            {
                if (outing.TypeOfOuting == outingType)
                {
                    listOfOutings.Add(outing);
                }
            }
            return listOfOutings;
        }
    }
}
