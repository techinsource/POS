using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Expanditures
{
    public class ExpandituresHelper
    {
        public List<Expanditures> GetExpanditures()
        {
            List<Expanditures> result = new ExpandituresHandler().GetExpanditures();
            return result;
        }
    }
}
