using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreet_Repository
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
        public bool UpdateExistingCustomer(string oldLastName, Customer newCustomerInfo)
        {
            //Find Customer
            Customer oldCustoemrInfo = GetCustomerByLastName(oldLastName);

            //Update the customer
            if(oldCustoemrInfo != null)
            {
                oldCustoemrInfo.FirstName = newCustomerInfo.FirstName;
                oldCustoemrInfo.LastName = newCustomerInfo.LastName;
                oldCustoemrInfo.TypeOfCustomer = newCustomerInfo.TypeOfCustomer;

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
                if (customer.LastName.ToLower() == lastName.ToLower())
                {
                    return customer;
                }
            }
            return null;
        }
    }
}
