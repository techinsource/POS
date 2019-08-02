using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSAnventory.Models;
using POSAnventory.Models.Items;

namespace POSAnventory.Controllers
{
    public class LineitemdefinitionController : Controller
    {
        
        string result = string.Empty;
        public IActionResult AddLineitemdefinition()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddLineitemdefinition(LineItemDefinition obj)
        {
            try
            {
                LineItemDefinition LID = new LineItemDefinition();
                LID.Name = obj.Name;
                LID.Barcode = obj.Barcode;
                LID.Sortorder = obj.Sortorder;
                LID.Comments = obj.Comments;
                LID.IsActive = true;
                LID.CreatedBy = "Bilal";
                LID.CreatedOn = DateTime.Now;
                LID.UpdatedBy = "Bilal";
                LID.UpdatedOn = DateTime.Now;
                new LineitemdefinitionHandler().AddLineitemdefinition(LID);
                result = "Success";

            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }
            return Json(result);

        }
        public IActionResult GetLineitemdefinition()
        {
            try
            {
                List<LineItemDefinition> result = new LineitemdefinitionHelper().GetLineitemdefinition();
                return Json(result);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }

        }

        public IActionResult FindLineitemdefinition(int id)
        {

            LineItemDefinition fined = new LineitemdefinitionHandler().FindLineitemdefinition(id);
            // List<Role> roleresult = new RoleHelper().GetRole();
            return Json(fined);

        }
        public IActionResult UpdateLineitemdefinition(LineItemDefinition obj)
        {
            try
            {
                LineItemDefinition check = new LineitemdefinitionHandler().FindLineitemdefinition(obj.Id);
                if (check != null)
                {
                    LineItemDefinition LID = new LineItemDefinition();
                    LID.Id = obj.Id;
                    LID.Name = obj.Name;

                    LID.Barcode = obj.Barcode;
                    LID.Sortorder = obj.Sortorder;
                    LID.Comments = obj.Comments;
                    LID.IsActive = true;
                    LID.CreatedBy = "Bilal";
                    LID.CreatedOn = DateTime.Now;
                    LID.UpdatedBy = "Bilal";
                    LID.UpdatedOn = DateTime.Now;
                    new LineitemdefinitionHandler().UpdateLineitemdefinition(LID);
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
        public IActionResult DeleteLineitemdefinition(int id)
        {
            LineItemDefinition cat = new LineitemdefinitionHandler().FindLineitemdefinition(id);
            if (cat != null)
            {
                new LineitemdefinitionHandler().DeleteLineitemdefinition(cat);
                result = "success";
            }
            return Json(result);


        }
    }
}