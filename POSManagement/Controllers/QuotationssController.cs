using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSAnventory.Models;
using POSManagement.Models.Customer;
using POSManagement.Models.Item;
using POSManagement.Models.Purchasess;
using POSManagement.Models.Quotation;

namespace POSManagement.Controllers
{
    public class QuotationssController : Controller
    {
        string result = string.Empty;

        public IActionResult AddQuotationss()
        {
           ViewBag.Suppliers = new SuppliersHandler().GetSuppliers();
            ViewBag.Customer = new CustomerssHandler().GetCustomerss();

            //    return View();
            return View();

        }

        public IActionResult PurchasessItemf(int id)
        {
            //int idd;
            Itemd fined=null;
            // Itemd combine = ;
            ArrayList finedd = new ArrayList();
            var result = new ItemHelper().GetItem();

            foreach (var pro in result)
            {
                if (pro.Code == id)
                {

                    //pur.Id = obj.Id;
                   // var idd = pro.Id;
                      fined = new ItemHandler().FindItem(pro.Id);
                   // fined = new ItemHandler().GetItem();
                    // finedd.Add(fined.Name);
                    // List<Role> roleresult = new RoleHelper().GetRole();

                }

            }

            return Json(fined);

        }

        [HttpPost]
        public IActionResult AddQuotationss(Quotationss obj, int Suppliers,int Customer)
        {


            try
            {
                Quotationss quo = new Quotationss();
                quo.Date = obj.Date;
                quo.Refeno = obj.Refeno;
                quo.Notes = obj.Notes;
                quo.Status = obj.Status;
                quo.Biller = "Admin";
                quo.Date = obj.Date;
                quo.Total =obj.Total;

                quo.Suppllierss = new Supplierss { Id = Suppliers };
                quo.Customerss= new Customerss { Id = Customer };

                quo.IsActive = true;
                quo.CreatedBy = "Bilal";
                quo.CreatedOn = DateTime.Now;
                quo.UpdatedBy = "Bilal";
                quo.UpdatedOn = DateTime.Now;
                
                new QuotationssHandler().AddQuotationss(quo);
                result = "success";

            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }
            return Json(result);

        }
        public IActionResult GetQuotationss()
        {
            try
            {
                List<Quotationss> result = new QuotationssHelper().GetQuotationss();
                return Json(result);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }

        }

        public IActionResult FindQuotationss(int id)
        {

            Quotationss fined = new QuotationssHandler().FindQuotationss(id);
            // List<Role> roleresult = new RoleHelper().GetRole();
            return Json(fined);

        }

        public IActionResult UpdateQuotationss(Quotationss obj, int Suppliers, int Customer)
        {
            try
            {
                Quotationss purc = new QuotationssHandler().FindQuotationss(obj.Id);
                if (purc != null)
                {
                    Quotationss quo = new Quotationss();
                    quo.Id = obj.Id;
                    quo.Date = obj.Date;
                    quo.Refeno = obj.Refeno;
                    quo.Notes = obj.Notes;
                    quo.Status = obj.Status;
                    quo.Biller = "Admin";
                    quo.Date = obj.Date;
                    quo.Total = obj.Total;

                    quo.Suppllierss = new Supplierss { Id = Suppliers };
                    quo.Customerss = new Customerss { Id = Customer };

                    quo.IsActive = true;
                    quo.CreatedBy = "Bilal";
                    quo.CreatedOn = DateTime.Now;
                    quo.UpdatedBy = "Bilal";
                    quo.UpdatedOn = DateTime.Now;


                    new QuotationssHandler().UpdateQuotationss(quo);
                    



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
        public IActionResult DeleteQuotationss(int id)
        {
            Quotationss pur = new QuotationssHandler().FindQuotationss(id);
            if (pur != null)
            {
                new QuotationssHandler().DeleteQuotationss(pur);
                result = "success";
            }
            return Json(result);


        }
    }
    }