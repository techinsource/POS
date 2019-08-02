using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSAnventory.Models.Items
{
    public class Sub_Categorys
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public int Sortorder { get; set; }
        public string Comments { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public virtual Categorys Category { get; set; }
    }
}
