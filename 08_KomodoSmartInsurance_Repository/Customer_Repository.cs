using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_KomodoSmartInsurance_Repository
{
    public class Customer_Repository
    {
        private List<Customer> _listOfCustomers = new List<Customer>();

        //Create
        public void AddCustomerToList(Customer customer)
        {
            _listOfCustomers.Add(customer);
        }

        //Read
        public List<Customer> GetCustomerList()
        {
            return _listOfCustomers;
        }

        //Update
        public bool UpdateExistingCustomer(string originalLastName, Customer newCustomer)
        {
            //Find customer
            Customer oldCustomer = GetCustomerByLastName(originalLastName);
            
            //Update customer
            if(oldCustomer != null)
            {
                oldCustomer.FirstName = newCustomer.FirstName;
                oldCustomer.LastName = newCustomer.LastName;
                oldCustomer.FollowSpeedLimitSkill = newCustomer.FollowSpeedLimitSkill;
                oldCustomer.StayInLaneSkill = newCustomer.StayInLaneSkill;
                oldCustomer.FullStopSkill = newCustomer.FullStopSkill;
                oldCustomer.FollowingDistanceSkill = newCustomer.FollowingDistanceSkill;

                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveCustomerFromList(string lastName)
        {
            Customer customer = GetCustomerByLastName(lastName);

            if (customer == null)
            {
                return false;
            }

            int initialCount = _listOfCustomers.Count;
            _listOfCustomers.Remove(customer);

            if (initialCount > _listOfCustomers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper
        public Customer GetCustomerByLastName(string lastName)
        {
            foreach (Customer customer in _listOfCustomers)
            {
                if(customer.LastName.ToLower() == lastName.ToLower())
                {
                    return customer;
                }
            }

            return null;
        }
    }
}
