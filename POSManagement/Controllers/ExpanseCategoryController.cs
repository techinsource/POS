using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSManagement.Models.Expanditures.ExpanseCategory;
using POSManagement.Models.Expanditures.ParentCategory;

namespace POSManagement.Controllers
{
    public class ExpanseCategoryController : Controller
    {
        string result = string.Empty;
        public IActionResult AddExpanseCategory()
        {
            ViewBag.Parentcat = new ExpanseCategoryHandler().GetExpanseCategory();


            return View();
        }
        [HttpPost]
        public IActionResult AddExpanseCategory(ExpanseCategory obj, string Parentcat)
        {
            try
            {
                ExpanseCategory cat = new ExpanseCategory();
               // cat.Name = obj.Name;
                cat.Details = obj.Details;
                cat.Status = obj.Status;
                cat.Order = obj.Order;
                cat.Total = "0";

                cat.IsActive = true;
                cat.CreatedBy = "Bilal";
                cat.CreatedOn = DateTime.Now;
                cat.UpdatedBy = "Bilal";
                cat.UpdatedOn = DateTime.Now;
                if(Parentcat== "Select")
                {
                    cat.Name = obj.Name;
                }
                else
                {
                    cat.Name = obj.Name + ">" + Parentcat;
                }
                new ExpanseCategoryHandler().AddExpanseCategory(cat);
                result = "Success";

            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }
            return Json(result);

        }
        public IActionResult GetExpanseCategory()
        {
            try
            {
                List<ExpanseCategory> result = new ExpanseCategoryHelper().GetExpanseCategory();
                return Json(result);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }

        }

        public IActionResult FindExpanseCategory(int id)
        {

            ExpanseCategory fined = new ExpanseCategoryHandler().FindExpanseCategory(id);
            // List<Role> roleresult = new RoleHelper().GetRole();
            return Json(fined);

        }
        public IActionResult UpdateExpanseCategory(ExpanseCategory obj, string Parentcat)
        {
            try
            {
                ExpanseCategory check = new ExpanseCategoryHandler().FindExpanseCategory(obj.Id);
                if (check != null)
                {
                    ExpanseCategory cat = new ExpanseCategory();
                    cat.Id = obj.Id;
                   // cat.Name = obj.Name;
                    cat.Details = obj.Details;
                    cat.Status = obj.Status;
                    cat.Order = obj.Order;
                    cat.Total = "0";
                    if (Parentcat == "Select")
                    {
                        cat.Name = obj.Name;
                    }
                    else
                    {
                        cat.Parent = obj.Name + ">" + Parentcat;
                    }
                    cat.IsActive = true;
                    cat.CreatedBy = "Bilal";
                    cat.CreatedOn = DateTime.Now;
                    cat.UpdatedBy = "Bilal";
                    cat.UpdatedOn = DateTime.Now;
                    cat.Name = Parentcat ;
                    new ExpanseCategoryHandler().UpdateExpanseCategory(cat);
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
        public IActionResult DeleteExpanseCategory(int id)
        {
            ExpanseCategory it = new ExpanseCategoryHandler().FindExpanseCategory(id);
            if (it != null)
            {
                new ExpanseCategoryHandler().DeleteExpanseCategory(it);
                result = "success";
            }
            return Json(result);


        }
    }
}