using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQS01
{
    internal class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }

        // Navigation property
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
