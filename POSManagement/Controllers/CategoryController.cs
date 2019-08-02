using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSAnventory.Models;
using POSAnventory.Models.Items;
using POSManagement.Models.Items.Category;

namespace POSManagement.Controllers
{
    public class CategoryController : Controller
    {
        string result = string.Empty;
        public IActionResult AddCategory()
        {
            ViewBag.LineItem = new LineitemdefinitionHandler().GetLineitemdefinition();


            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Categorys obj, int litm)
        {
            try
            {
                Categorys cat = new Categorys();
                cat.Name = obj.Name;
                cat.Code = obj.Code;
                cat.Sortorder = obj.Sortorder;
                cat.Comments = obj.Comments;
                cat.IsActive = true;
                cat.CreatedBy = "Bilal";
                cat.CreatedOn = DateTime.Now;
                cat.UpdatedBy = "Bilal";
                cat.UpdatedOn = DateTime.Now;
                cat.LineItemDefinition = new LineItemDefinition { Id = litm };
                new CategoryHandler().AddCategory(cat);
                result = "Success";

            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }
            return Json(result);

        }
        public IActionResult GetCategory()
        {
            try
            {
                List<Categorys> result = new CategoryHelper().GetCategory();
                return Json(result);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }

        }

        public IActionResult FindCategory(int id)
        {

            Categorys fined = new CategoryHandler().FindCategory(id);
            // List<Role> roleresult = new RoleHelper().GetRole();
            return Json(fined);

        }
        public IActionResult UpdateCategory(Categorys obj, int litm)
        {
            try
            {
                Categorys check = new CategoryHandler().FindCategory(obj.Id);
                if (check != null)
                {
                    Categorys cat = new Categorys();
                    cat.Id = obj.Id;
                    cat.Name = obj.Name;
                    cat.Code = obj.Code;
                    cat.Sortorder = obj.Sortorder;
                    cat.Comments = obj.Comments;
                    cat.IsActive = true;
                    cat.CreatedBy = "Bilal";
                    cat.CreatedOn = DateTime.Now;
                    cat.UpdatedBy = "Bilal";
                    cat.UpdatedOn = DateTime.Now;
                    cat.LineItemDefinition = new LineItemDefinition { Id = litm };
                    new CategoryHandler().UpdateCategory(cat);
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
        public IActionResult DeleteCategory(int id)
        {
            Categorys it = new CategoryHandler().FindCategory(id);
            if (it != null)
            {
                new CategoryHandler().DeleteCategory(it);
                result = "success";
            }
            return Json(result);


        }
    }
}