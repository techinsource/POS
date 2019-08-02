using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.System.Store
{
    public class StoressHelper
    {
        public List<Storess> GetStoress()
        {
            List<Storess> result = new StoressHandler().GetStoress();
            return result;
        }
    }
}
