using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSAnventory.Models.Items
{
    public class LineitemdefinitionHelper
    {
        public List<LineItemDefinition> GetLineitemdefinition()
        {
            List<LineItemDefinition> result = new LineitemdefinitionHandler().GetLineitemdefinition();
            return result;
        }
    }
}
