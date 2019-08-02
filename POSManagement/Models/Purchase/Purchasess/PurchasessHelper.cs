using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Purchase.PurchaseItem
{
    public class PurchasessHelper
    {
        public List<Purchasess> GetPurchasess()
        {
            List<Purchasess> result = new PurchasessHandler().GetPurchasess();
            return result;
        }
    }
}
