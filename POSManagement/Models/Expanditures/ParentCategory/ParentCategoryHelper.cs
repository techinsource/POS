using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Expanditures.ParentCategory
{
    public class ParentCategoryHelper
    {
        public List<ParentCategorys> GetParentCategory()
        {
            List<ParentCategorys> result = new ParentCategoryHandler().GetParentCategory();
            return result;
        }
    }
}
