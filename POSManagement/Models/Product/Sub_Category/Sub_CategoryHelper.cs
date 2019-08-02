using POSAnventory.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Items.Sub_Category
{
    public class Sub_CategoryHelper
    {
        public List<Sub_Categorys> GetSubCategory()
        {
            List<Sub_Categorys> result = new Sub_CategoryHandler().GetSubCategory();
            return result;
        }
    }
}
