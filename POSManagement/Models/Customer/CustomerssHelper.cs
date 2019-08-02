using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Customer
{
    public class CustomerssHelper
    {
        public List<Customerss> GetCustomerss()
        {
            List<Customerss> result = new CustomerssHandler().GetCustomerss();
            return result;
        }
    }
}
