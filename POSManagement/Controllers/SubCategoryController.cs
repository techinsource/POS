using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSAnventory.Models;
using POSAnventory.Models.Items;
using POSManagement.Models.Items.Category;
using POSManagement.Models.Items.Sub_Category;

namespace POSManagement.Controllers
{
    public class SubCategoryController : Controller
    {
        string result = string.Empty;
        public IActionResult AddSubCategory()
        {
            ViewBag.Categoryd = new CategoryHandler().GetCategory();


            return View();
        }
        [HttpPost]
        public IActionResult AddSubCategory(Sub_Categorys obj, int cat)
        {
            try
            {
                Sub_Categorys scat = new Sub_Categorys();
                scat.Name = obj.Name;
                scat.Code = obj.Code;
                scat.Sortorder = obj.Sortorder;
                scat.Comments = obj.Comments;
                scat.IsActive = true;
                scat.CreatedBy = "Bilal";
                scat.CreatedOn = DateTime.Now;
                scat.UpdatedBy = "Bilal";
                scat.UpdatedOn = DateTime.Now;
                scat.Category = new Categorys { Id = cat };
                new Sub_CategoryHandler().AddSubCategory(scat);
                result = "Success";

            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }
            return Json(result);

        }
        public IActionResult GetSubCategory()
        {
            try
            {
                List<Sub_Categorys> result = new Sub_CategoryHelper().GetSubCategory();
                return Json(result);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }

        }

        public IActionResult FindSubCategory(int id)
        {

            Sub_Categorys fined = new Sub_CategoryHandler().FindSubCategory(id);
            // List<Role> roleresult = new RoleHelper().GetRole();
            return Json(fined);

        }
        public IActionResult UpdateSubCategory(Sub_Categorys obj, int cat)
        {
            try
            {
                Sub_Categorys check = new Sub_CategoryHandler().FindSubCategory(obj.Id);
                if (check != null)
                {

                    Sub_Categorys scat = new Sub_Categorys();
                    scat.Id = obj.Id;
                    scat.Name = obj.Name;
                    scat.Code = obj.Code;
                    scat.Sortorder = obj.Sortorder;
                    scat.Comments = obj.Comments;
                    scat.IsActive = true;
                    scat.CreatedBy = "Bilal";
                    scat.CreatedOn = DateTime.Now;
                    scat.UpdatedBy = "Bilal";
                    scat.UpdatedOn = DateTime.Now;
                    scat.Category = new Categorys { Id = cat };
                    new Sub_CategoryHandler().UpdateSubCategory(scat);
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
        public IActionResult DeleteSubCategory(int id)
        {
            Sub_Categorys it = new Sub_CategoryHandler().FindSubCategory(id);
            if (it != null)
            {
                new Sub_CategoryHandler().DeleteSubCategory(it);
                result = "success";
            }
            return Json(result);


        }
    }
}