using POSAnventory.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Items.ItemTemplate
{
    public class ItemTemplateHelper
    {
        public List<Item_Template> GetItemTemplate()
        {
            List<Item_Template> result = new ItemTemplateHandler().GetItemTemplate();
            return result;
        }
    }
}
