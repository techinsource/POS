using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSAnventory.Models;
using POSManagement.Models.Item;
using POSManagement.Models.Purchase.PurchaseItem;
using POSManagement.Models.Purchasess;
//using POSManagement.Models.Supliers;
//using POSManagement.Models.;
namespace POSManagement.Controllers
{
    public class PurchaseController : Controller
    {
        string result = string.Empty;

        public IActionResult AddPurchasess()
        {
            ViewBag.Suppliers = new SuppliersHandler().GetSuppliers();
            //    return View();
            return View();

        }

        [HttpPost]
        public IActionResult AddPurchasess(Purchasess obj, int Suppliers, int Code)
        {


            try
            {
                var result = new ItemHelper().GetItem();
                foreach (var pro in result)
                {
                    if (pro.Code == Code)
                    {
                        Purchasess pur = new Purchasess();

                        pur.Quantity = obj.Quantity;
                        var price=pro.Cost_Price;
                        pur.Date = obj.Date;
                        pur.Referenceno = obj.Referenceno;
                        pur.Notes = obj.Notes;
                        pur.Totalamount = obj.Quantity * price;
                        pur.Suppliers = new Supplierss { Id = Suppliers };
                        pur.Item = new Itemd { Id = pro.Id };

                        pur.IsActive = true;
                        pur.CreatedBy = "Bilal";
                        pur.CreatedOn = DateTime.Now;
                        pur.UpdatedBy = "Bilal";
                        pur.UpdatedOn = DateTime.Now;


                        new PurchasessHandler().AddPurchasess(pur);

                    }

                }
                string resultt = "success";

            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }
            return Json(result);

        }
        public IActionResult GetPurchasess()
        {
            
            try
            {
                List<Purchasess> result = new PurchasessHelper().GetPurchasess();
                return Json(result);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }
           

        }

        public IActionResult FindPurchasess(int id)
        {

            Purchasess fined = new PurchasessHandler().FindPurchasess(id);
            // List<Role> roleresult = new RoleHelper().GetRole();
            return Json(fined);

        }
        public IActionResult PurchasessItemf(int id)
        {
            //int idd;
            Itemd fined = null;
            var result = new ItemHelper().GetItem();
            foreach (var pro in result)
            {
                if (pro.Code == id)
                {

                    //pur.Id = obj.Id;
                    var idd = pro.Id;
                    fined = new ItemHandler().FindItem(idd);
                    // List<Role> roleresult = new RoleHelper().GetRole();

                }

            }
            return Json(fined);

        }
        public IActionResult UpdatePurchageInvoice(Purchasess obj, int Suppliers, int Code)
        {
            try
            {
                Purchasess purc = new PurchasessHandler().FindPurchasess(obj.Id);
                if (purc != null)
                {
                    var result = new ItemHelper().GetItem();
                    foreach (var pro in result)
                    {
                        if (pro.Code == Code)
                        {
                            Purchasess pur = new Purchasess();
                            pur.Id = obj.Id;
                            pur.Quantity = obj.Quantity;
                            var price = pro.Cost_Price;
                            pur.Date = obj.Date;
                            pur.Referenceno = obj.Referenceno;
                            pur.Notes = obj.Notes;
                            pur.Totalamount = obj.Quantity * price;
                            pur.Suppliers = new Supplierss { Id = Suppliers };
                            pur.Item = new Itemd { Id = pro.Id };

                            pur.IsActive = true;
                            pur.CreatedBy = "Bilal";
                            pur.CreatedOn = DateTime.Now;
                            pur.UpdatedBy = "Bilal";
                            pur.UpdatedOn = DateTime.Now;



                            new PurchasessHandler().UpdatePurchasess(pur);

                        }

                    }



                }
                result = "success";
                return Json(result);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }


        }
        public IActionResult DeletePurchasess(int id)
        {
            Purchasess pur = new PurchasessHandler().FindPurchasess(id);
            if (pur != null)
            {
                new PurchasessHandler().DeletePurchasess(pur);
                result = "success";
            }
            return Json(result);


        }
    }
}