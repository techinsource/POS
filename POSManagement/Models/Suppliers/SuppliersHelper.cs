using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Purchasess
{
    public class SuppliersHelper
    {
        public List<Supplierss> GetSuppliers()
        {
            List<Supplierss> result = new SuppliersHandler().GetSuppliers();
            return result;
        }
    }
}
