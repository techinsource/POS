using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSAnventory.Models.Items;
using POSManagement.Models.Expanditures;
using POSManagement.Models.Items.Category;

namespace POSManagement.Controllers
{
    public class ExpandituresController : Controller
    {
        string result = string.Empty;
        public IActionResult AddExpanditures()
        {
            ViewBag.Category = new CategoryHandler().GetCategory();


            return View();
        }
        [HttpPost]
        public IActionResult AddExpanditures(Expanditures obj, int cat)
        {
            try
            {
                Expanditures exp = new Expanditures();
                exp.Refno = obj.Refno;
                exp.Whatfor = obj.Whatfor;
                exp.Amount = obj.Amount;
                exp.Returnable = obj.Returnable;
                exp.Notes = obj.Notes;
                exp.Refno = obj.Refno;
                exp.IsActive = true;
                exp.CreatedBy = "Bilal";
                exp.CreatedOn = DateTime.Now;
                exp.UpdatedBy = "Bilal";
                exp.UpdatedOn = DateTime.Now;
                exp.Categorys = new Categorys { Id = cat };
                new ExpandituresHandler().AddExpanditures(exp);
                result = "Success";

            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }
            return Json(result);

        }
        public IActionResult GetExpanditures()
        {
            try
            {
                List<Expanditures> result = new ExpandituresHelper().GetExpanditures();
                return Json(result);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }

        }

        public IActionResult FindExpanditures(int id)
        {

            Expanditures fined = new ExpandituresHandler().FindExpanditures(id);
            // List<Role> roleresult = new RoleHelper().GetRole();
            return Json(fined);

        }
        public IActionResult UpdateExpanditures(Expanditures obj, int cat)
        {
            try
            {
                Expanditures check = new ExpandituresHandler().FindExpanditures(obj.Id);
                if (check != null)
                {
                    Expanditures exp = new Expanditures();
                    exp.Id = obj.Id;
                    exp.Refno = obj.Refno;
                    exp.Whatfor = obj.Whatfor;
                    exp.Amount = obj.Amount;
                    exp.Returnable = obj.Returnable;
                    exp.Notes = obj.Notes;
                    exp.Refno = obj.Refno;
                    exp.IsActive = true;
                    exp.CreatedBy = "Bilal";
                    exp.CreatedOn = DateTime.Now;
                    exp.UpdatedBy = "Bilal";
                    exp.UpdatedOn = DateTime.Now;
                    exp.Categorys = new Categorys { Id = cat };
                    new ExpandituresHandler().UpdateExpanditures(exp);
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
        public IActionResult DeleteExpanditures(int id)
        {
            Expanditures it = new ExpandituresHandler().FindExpanditures(id);
            if (it != null)
            {
                new ExpandituresHandler().DeleteExpanditures(it);
                result = "success";
            }
            return Json(result);


        }
    }
}