using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSAnventory.Models;
using POSAnventory.Models.Items;
using POSManagement.Models.Items.ItemTemplate;

namespace POSManagement.Controllers
{
    public class ItemTemplateController : Controller
    {
        string result = string.Empty;
        public IActionResult AddItemTemplate()
        {
            ViewBag.LineItem = new LineitemdefinitionHandler().GetLineitemdefinition();


            return View();
        }
        [HttpPost]
        public IActionResult AddItemTemplate(Item_Template obj, int litm)
        {
            try
            {
                Item_Template itmg = new Item_Template();
                itmg.Name = obj.Name;
                itmg.Code = obj.Code;
                itmg.Sortorder = obj.Sortorder;
                
                itmg.IsActive = true;
                itmg.CreatedBy = "Bilal";
                itmg.CreatedOn = DateTime.Now;
                itmg.UpdatedBy = "Bilal";
                itmg.UpdatedOn = DateTime.Now;
                itmg.LineItemDefinition = new LineItemDefinition { Id = litm };
                new ItemTemplateHandler().AddItemTemplate(itmg);
                result = "Success";

            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }
            return Json(result);

        }
        public IActionResult GetItemTemplate()
        {
            try
            {
                List<Item_Template> result = new ItemTemplateHelper().GetItemTemplate();
                return Json(result);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }

        }

        public IActionResult FindItemTemplate(int id)
        {

            Item_Template fined = new ItemTemplateHandler().FindItemTemplate(id);
            // List<Role> roleresult = new RoleHelper().GetRole();
            return Json(fined);

        }
        public IActionResult UpdateItemTemplate(Item_Template obj, int litm)
        {
            try
            {
                Item_Template check = new ItemTemplateHandler().FindItemTemplate(obj.Id);
                if (check != null)
                {
                    Item_Template itmg = new Item_Template();
                    itmg.Id = obj.Id;
                    itmg.Name = obj.Name;
                    itmg.Code = obj.Code;
                    itmg.Sortorder = obj.Sortorder;
                    
                    itmg.IsActive = true;
                    itmg.CreatedBy = "Bilal";
                    itmg.CreatedOn = DateTime.Now;
                    itmg.UpdatedBy = "Bilal";
                    itmg.UpdatedOn = DateTime.Now;
                    itmg.LineItemDefinition = new LineItemDefinition { Id = litm };
                    new ItemTemplateHandler().UpdateItemTemplate(itmg);
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
        public IActionResult DeleteIItemTemplate(int id)
        {
            Item_Template it = new ItemTemplateHandler().FindItemTemplate(id);
            if (it != null)
            {
                new ItemTemplateHandler().DeleteItemTemplate(it);
                result = "success";
            }
            return Json(result);


        }
    }
}