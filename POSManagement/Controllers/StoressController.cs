using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using POSManagement.Models.System.Store;
using POSManagement.Models.User;

namespace POSManagement.Controllers
{
    public class StoressController : Controller
    {
        string result = string.Empty;
        public IActionResult AddStoress()
        {
            ViewBag.Userss = new UserssHandler().GetUserss();


            return View();
        }
        [HttpPost]
        public IActionResult AddStoress(Storess obj, int Userss)
        {
            try
            {
                Storess sto = new Storess();
                sto.Name = obj.Name;
                sto.Country = obj.Country;
                sto.Mobile = obj.Mobile;
                sto.Email = obj.Email;
                sto.Zipcode = obj.Zipcode;
                sto.Address = obj.Address;
                sto.VantRegno = obj.VantRegno;
                sto.Timezo = obj.Timezo;

                sto.Text = obj.Text;
                sto.Stockalertq = obj.Stockalertq;
                sto.Itemlimit = obj.Itemlimit;
                sto.Soundeffect = obj.Soundeffect;
                sto.IsActive = true;
                sto.CreatedBy = "Bilal";
                sto.CreatedOn = DateTime.Now;
                sto.UpdatedBy = "Bilal";
                sto.UpdatedOn = DateTime.Now;
                sto.Userss = new Userss { Id = Userss };
                new StoressHandler().AddStoress(sto);
                result = "Success";

            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }
            return Json(result);

        }
        public IActionResult GetStoress()
        {
            try
            {
                List<Storess> result = new StoressHelper().GetStoress();
                return Json(result);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
                throw;
            }

        }

        public IActionResult FindStoress(int id)
        {

            Storess fined = new StoressHandler().FindStoress(id);
            // List<Role> roleresult = new RoleHelper().GetRole();
            return Json(fined);

        }
        public IActionResult UpdateItem(Storess obj, int Userss)
        {
            try
            {
                Storess check = new StoressHandler().FindStoress(obj.Id);
                if (check != null)
                {
                    Storess sto = new Storess();
                    sto.Id = obj.Id;
                    sto.Name = obj.Name;
                    sto.Country = obj.Country;
                    sto.Mobile = obj.Mobile;
                    sto.Email = obj.Email;
                    sto.Zipcode = obj.Zipcode;
                    sto.Address = obj.Address;
                    sto.VantRegno = obj.VantRegno;
                    sto.Timezo = obj.Timezo;

                    sto.Text = obj.Text;
                    sto.Stockalertq = obj.Stockalertq;
                    sto.Itemlimit = obj.Itemlimit;
                    sto.Soundeffect = obj.Soundeffect;
                    sto.IsActive = true;
                    sto.CreatedBy = "Bilal";
                    sto.CreatedOn = DateTime.Now;
                    sto.UpdatedBy = "Bilal";
                    sto.UpdatedOn = DateTime.Now;
                    sto.Userss = new Userss { Id = Userss };
                    new StoressHandler().UpdateStoress(sto);
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
        public IActionResult DeleteStoress(int id)
        {
            Storess it = new StoressHandler().FindStoress(id);
            if (it != null)
            {
                new StoressHandler().DeleteStoress(it);
                result = "success";
            }
            return Json(result);


        }
    }
}