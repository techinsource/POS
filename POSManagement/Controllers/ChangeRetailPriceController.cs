using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSAnventory.Models;
using POSManagement.Models.Item;
using POSManagement.Models.Items.ViewModel;

namespace POSManagement.Controllers
{
    public class ChangeRetailPriceController : Controller
    {
        string result = string.Empty;
        public IActionResult ChageRetailPrice()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddChageRetailPrice(Models.Items.ChangeRetailPrice.ChangeRetailPrices crp)
        {
            //drp = crp.Id;
            // value = 10;
            // ViewBag.value = 10;
            // var check = ViewBag.value;
            
            return View();
        }
        public IActionResult GetChageRetailPrice(int value)
        {
            try
            {

                // List<double> Rtp=new List<double>();
                List<Itemd> result = new ItemHelper().GetItem();
           
                List<NewPriceVM> newPrices = new List<NewPriceVM>();
              //  double value = 0;
               // var value =Convert.ToDouble( TempData["Value"]);

                foreach (var item in result)
                {
                    
                    newPrices.Add(new NewPriceVM()
                    {
                        Name = item.Name,
                        Retail_Price = item.Retail_Price,
                        NewPrice = item.Retail_Price * value,
                        Code = item.Code,
                        Cost_Price = item.Cost_Price,

                    });


                }






                return Json(newPrices);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }

        }
    }
}