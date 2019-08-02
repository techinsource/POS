using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSAnventory.Models;
using POSAnventory.Models.Items;
using POSManagement.Models.Item;

namespace POSManagement.Controllers
{
    public class ItemController : Controller
    {
        string result = string.Empty;
        public IActionResult AddItem()
        {
            ViewBag.LineItem = new LineitemdefinitionHandler().GetLineitemdefinition();
            

            return View();
        }
        [HttpPost]
        public IActionResult AddItem(Itemd obj,int litm)
        {
            try
            {
                Itemd itm = new Itemd();
                itm.Name = obj.Name;
                itm.Code = obj.Code;
                itm.Cost_Price = obj.Cost_Price;
                itm.Retail_Price = obj.Retail_Price;
                itm.IsActive = true;
                itm.CreatedBy = "Bilal";
                itm.CreatedOn = DateTime.Now;
                itm.UpdatedBy = "Bilal";
                itm.UpdatedOn = DateTime.Now;
                itm.LineItemDefinition = new LineItemDefinition { Id = litm };
                new ItemHandler().AddItem(itm);
                result = "Success";

            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }
            return Json(result);

        }
        public IActionResult GetItem()
        {
            try
            {
                List<Itemd> result = new ItemHelper().GetItem();
                return Json(result);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }

        }

        public IActionResult FindItem(int id)
        {

            Itemd fined = new ItemHandler().FindItem(id);
            // List<Role> roleresult = new RoleHelper().GetRole();
            return Json(fined);

        }
        public IActionResult UpdateItem(Itemd obj,int litm)
        {
            try
            {
                Itemd check = new ItemHandler().FindItem(obj.Id);
                if (check != null)
                {
                    Itemd itm = new Itemd();
                    itm.Id = obj.Id;
                    itm.Name = obj.Name;
                    itm.Code = obj.Code;
                    itm.Cost_Price = obj.Cost_Price;
                    itm.Retail_Price = obj.Retail_Price;
                    itm.IsActive = true;
                    itm.CreatedBy = "Bilal";
                    itm.CreatedOn = DateTime.Now;
                    itm.UpdatedBy = "Bilal";
                    itm.UpdatedOn = DateTime.Now;
                    itm.LineItemDefinition = new LineItemDefinition { Id = litm };
                    new ItemHandler().UpdateItem(itm);
                    result = "success";
                }
                return Json(result);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }


        }
        public IActionResult DeleteItem(int id)
        {
            Itemd it = new ItemHandler().FindItem(id);
            if (it != null)
            {
                new ItemHandler().DeleteItem(it);
                result = "success";
            }
            return Json(result);


        }
    }
}