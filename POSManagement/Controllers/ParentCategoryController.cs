using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSManagement.Models.Expanditures.ParentCategory;

namespace POSManagement.Controllers
{
    public class ParentCategoryController : Controller
    {
        string result = string.Empty;
        public IActionResult AddParentCategory()
        {
            //ViewBag.LineItem = new LineitemdefinitionHandler().GetLineitemdefinition();


            return View();
        }
        [HttpPost]
        public IActionResult AddParentCategory(ParentCategorys obj)
        {
            try
            {
                ParentCategorys cat = new ParentCategorys();
                cat.Name = obj.Name;
               
                cat.IsActive = true;
                cat.CreatedBy = "Bilal";
                cat.CreatedOn = DateTime.Now;
                cat.UpdatedBy = "Bilal";
                cat.UpdatedOn = DateTime.Now;
               
                new ParentCategoryHandler().AddParentCategory(cat);
                result = "Success";

            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }
            return Json(result);

        }
        public IActionResult GetParentCategory()
        {
            try
            {
                List<ParentCategorys> result = new ParentCategoryHelper().GetParentCategory();
                return Json(result);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }

        }

        public IActionResult FindParentCategory(int id)
        {

            ParentCategorys fined = new ParentCategoryHandler().FindParentCategory(id);
            // List<Role> roleresult = new RoleHelper().GetRole();
            return Json(fined);

        }
        public IActionResult UpdateParentCategory(ParentCategorys obj)
        {
            try
            {
                ParentCategorys check = new ParentCategoryHandler().FindParentCategory(obj.Id);
                if (check != null)
                {
                    ParentCategorys cat = new ParentCategorys();
                    cat.Id = obj.Id;
                    cat.Name = obj.Name;
                    
                    cat.IsActive = true;
                    cat.CreatedBy = "Bilal";
                    cat.CreatedOn = DateTime.Now;
                    cat.UpdatedBy = "Bilal";
                    cat.UpdatedOn = DateTime.Now;
                    
                    new ParentCategoryHandler().UpdateParentCategory(cat);
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
        public IActionResult DeleteParentCategory(int id)
        {
            ParentCategorys it = new ParentCategoryHandler().FindParentCategory(id);
            if (it != null)
            {
                new ParentCategoryHandler().DeleteParentCategory(it);
                result = "success";
            }
            return Json(result);


        }
    }
}