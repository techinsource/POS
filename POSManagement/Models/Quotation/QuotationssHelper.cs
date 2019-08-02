using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Quotation
{
    public class QuotationssHelper
    {
        public List<Quotationss> GetQuotationss()
        {
            List<Quotationss> result = new QuotationssHandler().GetQuotationss();
            return result;
        }
    }
}
