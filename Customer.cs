using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_PartB
{
    class Customer
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }

        public Customer(string fName, string lName, string phNo)
        {
            this.firstName = fName;
            this.lastName = lName;
            this.phone = phNo;
        }

        public string getCustomer()
        {
            string customerDetails = firstName + "\t" + lastName + "\t" + phone;
            return customerDetails;
        }

    }
}
