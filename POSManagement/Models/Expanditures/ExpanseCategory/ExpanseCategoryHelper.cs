using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Expanditures.ExpanseCategory
{
    public class ExpanseCategoryHelper
    {
        public List<ExpanseCategory> GetExpanseCategory()
        {
            List<ExpanseCategory> result = new ExpanseCategoryHandler().GetExpanseCategory();
            return result;
        }
    }
}
