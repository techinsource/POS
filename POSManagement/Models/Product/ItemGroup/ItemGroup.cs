﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSAnventory.Models.Items
{
    public class ItemGroups
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public int SortItem { get; set; }
        public string Comments { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public virtual LineItemDefinition LineItemDefinition { get; set; }
    }
}
