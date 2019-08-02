using POSAnventory.Models;
using POSManagement.Models.Customer;
using POSManagement.Models.Purchasess;
using POSManagement.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Quotation
{
    public class Quotationss
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Refeno { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public string Biller { get; set; }
        public double Total { get; set; }
        public virtual Supplierss Suppllierss { get; set; }
        public virtual Customerss Customerss { get; set; }
        public virtual Itemd Itemd { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }


    }
}
