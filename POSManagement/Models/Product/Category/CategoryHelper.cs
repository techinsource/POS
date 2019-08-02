using POSAnventory.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Items.Category
{
    public class CategoryHelper { 
    public List<Categorys> GetCategory()
    {
        List<Categorys> result = new CategoryHandler().GetCategory();
        return result;
    }
}
}
