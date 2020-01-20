using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoGreet_Repository
{
    public enum CustomerType
    {
        Current = 1,
        Past,
        Potential
    }
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType TypeOfCustomer { get; set; }
        public string Email
        {
            get
            {
                if (TypeOfCustomer == CustomerType.Current)
                {
                    return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                }
                else if (TypeOfCustomer == CustomerType.Past)
                {
                    return "It's been a long time since we've heard from you. We want you back.";
                }
                else if (TypeOfCustomer == CustomerType.Potential)
                {
                    return "We currently have the lowest rates on Helicopter Insurance!";
                }
                else
                {
                    return "Something went wrong. I don't know which message to send.";
                }
            }
        }

        public Customer() { }

        public Customer(string firstName, string lastName, CustomerType typeOfCustomer)
        {
            FirstName = firstName;
            LastName = lastName;
            TypeOfCustomer = typeOfCustomer;
        }
    }
}
