using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Customer
{
    public class Customerss
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Creditbalance { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
      
        public int Order { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
