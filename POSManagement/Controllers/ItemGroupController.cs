using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSAnventory.Models;
using POSAnventory.Models.Items;
using POSManagement.Models.Items.ItemGroup;

namespace POSManagement.Controllers
{
    public class ItemGroupController : Controller
    {
        string result = string.Empty;
        public IActionResult AddItemGroup()
        {
            ViewBag.LineItem = new LineitemdefinitionHandler().GetLineitemdefinition();


            return View();
        }
        [HttpPost]
        public IActionResult AddItemGroup(ItemGroups obj, int litm)
        {
            try
            {
                ItemGroups itmg = new ItemGroups();
                itmg.Name = obj.Name;
                itmg.Code = obj.Code;
                itmg.SortItem = obj.SortItem;
                itmg.Comments = obj.Comments;
                itmg.IsActive = true;
                itmg.CreatedBy = "Bilal";
                itmg.CreatedOn = DateTime.Now;
                itmg.UpdatedBy = "Bilal";
                itmg.UpdatedOn = DateTime.Now;
                itmg.LineItemDefinition = new LineItemDefinition { Id = litm };
                new ItemGroupHandler().AddItemGroup(itmg);
                result = "Success";

            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }
            return Json(result);

        }
        public IActionResult GetItemGroup()
        {
            try
            {
                List<ItemGroups> result = new ItemGroupHelper().GetItemGroup();
                return Json(result);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }

        }

        public IActionResult FindItemGroup(int id)
        {

            ItemGroups fined = new ItemGroupHandler().FindItemGroup(id);
            // List<Role> roleresult = new RoleHelper().GetRole();
            return Json(fined);

        }
        public IActionResult UpdateItemGroup(ItemGroups obj, int litm)
        {
            try
            {
                ItemGroups check = new ItemGroupHandler().FindItemGroup(obj.Id);
                if (check != null)
                {
                    ItemGroups itmg = new ItemGroups();
                    itmg.Id = obj.Id;
                    itmg.Name = obj.Name;
                    itmg.Code = obj.Code;
                    itmg.SortItem = obj.SortItem;
                    itmg.Comments = obj.Comments;
                    itmg.IsActive = true;
                    itmg.CreatedBy = "Bilal";
                    itmg.CreatedOn = DateTime.Now;
                    itmg.UpdatedBy = "Bilal";
                    itmg.UpdatedOn = DateTime.Now;
                    itmg.LineItemDefinition = new LineItemDefinition { Id = litm };
                    new ItemGroupHandler().UpdateItemGroup(itmg);
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
        public IActionResult DeleteItemGroup(int id)
        {
            ItemGroups it = new ItemGroupHandler().FindItemGroup(id);
            if (it != null)
            {
                new ItemGroupHandler().DeleteItemGroup(it);
                result = "success";
            }
            return Json(result);


        }
    }
}