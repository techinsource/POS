using POSAnventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Item
{
    public class ItemHelper
    {
        public List<Itemd> GetItem()
        {
            List<Itemd> result = new ItemHandler().GetItem();
            return result;
        }

    }
}
