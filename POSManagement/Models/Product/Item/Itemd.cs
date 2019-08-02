using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSAnventory.Models
{
    public class Itemd
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public double Cost_Price { get; set; }
        public double Retail_Price { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public virtual LineItemDefinition LineItemDefinition { get; set; }

    }
}
