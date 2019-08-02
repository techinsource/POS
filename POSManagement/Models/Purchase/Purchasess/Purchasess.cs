using POSAnventory.Models;
using POSManagement.Models.Purchasess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Purchase.PurchaseItem
{
    public class Purchasess
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Referenceno { get; set; }
        public string Notes { get; set; }
        public int Quantity { get; set; }
        public double Totalamount { get; set; }
        public virtual Supplierss Suppliers { get; set; }
        public virtual Itemd Item { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }


    }
}
