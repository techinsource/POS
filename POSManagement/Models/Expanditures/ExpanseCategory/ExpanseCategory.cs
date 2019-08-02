using POSManagement.Models.Expanditures.ParentCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Expanditures.ExpanseCategory
{
    public class ExpanseCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
        public string Order { get; set; }
        public string Total { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }

        public string Parent { get; set; }


    }
}
