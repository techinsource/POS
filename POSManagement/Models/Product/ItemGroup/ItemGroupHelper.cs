using POSAnventory.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Items.ItemGroup
{
    public class ItemGroupHelper
    {
        public List<ItemGroups> GetItemGroup()
        {
            List<ItemGroups> result = new ItemGroupHandler().GetItemGroup();
            return result;
        }
    }
}
