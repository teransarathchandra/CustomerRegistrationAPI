using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerRegistration.Modules
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public Int32 PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
