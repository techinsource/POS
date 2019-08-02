using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSAnventory.Models.Items
{
    public class Item_Template
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public int Sortorder { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public virtual LineItemDefinition  LineItemDefinition {get;set;}
    }
}
