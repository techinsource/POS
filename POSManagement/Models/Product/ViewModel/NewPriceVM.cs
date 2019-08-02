using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSManagement.Models.Items.ViewModel
{
    public class NewPriceVM
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public double Cost_Price { get; set; }
        public double Retail_Price { get; set; }
        public double NewPrice { get; set; }
    }}
