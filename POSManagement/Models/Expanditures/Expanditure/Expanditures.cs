using POSAnventory.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Expanditures
{
    public class Expanditures
    {
        public int Id { get; set; }
        public int Refno { get; set; }
        public string Whatfor { get; set; }
        public double Amount { get; set; }
        public string Returnable { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public virtual Categorys Categorys { get; set; }
    }
}
